Namespace Discord_QR_Token_Stealer
	Partial Public Class setHook
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(setHook))
			Me.hook = New System.Windows.Forms.TextBox()
			Me.set = New System.Windows.Forms.Button()
			Me.SuspendLayout()
			' 
			' hook
			' 
			Me.hook.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.hook.ForeColor = System.Drawing.Color.LightGray
			Me.hook.Location = New System.Drawing.Point(12, 12)
			Me.hook.Name = "hook"
			Me.hook.Size = New System.Drawing.Size(610, 20)
			Me.hook.TabIndex = 0
			' 
			' set
			' 
			Me.set.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(40)))), (CInt((CByte(40)))), (CInt((CByte(40)))))
			Me.set.FlatStyle = System.Windows.Forms.FlatStyle.Popup
			Me.set.ForeColor = System.Drawing.Color.LightGray
			Me.set.Location = New System.Drawing.Point(12, 38)
			Me.set.Name = "set"
			Me.set.Size = New System.Drawing.Size(610, 23)
			Me.set.TabIndex = 1
			Me.set.Text = "Set webhhook"
			Me.set.UseVisualStyleBackColor = False
'			Me.set.Click += New System.EventHandler(Me.set_Click)
			' 
			' setHook
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(20)))), (CInt((CByte(20)))), (CInt((CByte(20)))))
			Me.ClientSize = New System.Drawing.Size(634, 77)
			Me.Controls.Add(Me.set)
			Me.Controls.Add(Me.hook)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "setHook"
			Me.Text = "Set Discord webhook"
			Me.ResumeLayout(False)
			Me.PerformLayout()

		End Sub

		#End Region

		Private hook As System.Windows.Forms.TextBox
		Private WithEvents set As System.Windows.Forms.Button
	End Class
End Namespace