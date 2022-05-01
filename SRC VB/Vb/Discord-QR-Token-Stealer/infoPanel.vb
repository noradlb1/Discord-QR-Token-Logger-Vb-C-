Imports System
Imports System.Windows.Forms
Imports System.Diagnostics

Namespace Discord_QR_Token_Stealer
	Partial Public Class infoPanel
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub openUrl(ByVal url As String)
			Dim proc = New Process()
			Dim info = New ProcessStartInfo()
			info.FileName = url
			proc.StartInfo = info
			proc.Start()
		End Sub

		Private Sub label1_Click_1(ByVal sender As Object, ByVal e As EventArgs) Handles label1.Click
			openUrl("https://verlox.cc")

		End Sub

		Private Sub label2_Click(ByVal sender As Object, ByVal e As EventArgs) Handles label2.Click
			openUrl("https://github.com/verlox")
		End Sub
	End Class
End Namespace
