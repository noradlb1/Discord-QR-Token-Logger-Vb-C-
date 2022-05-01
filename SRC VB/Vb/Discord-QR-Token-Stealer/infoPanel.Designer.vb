Namespace Discord_QR_Token_Stealer
	Partial Public Class infoPanel
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
			Dim resources As New System.ComponentModel.ComponentResourceManager(GetType(infoPanel))
			Me.pictureBox1 = New System.Windows.Forms.PictureBox()
			Me.label1 = New System.Windows.Forms.Label()
			Me.label2 = New System.Windows.Forms.Label()
			DirectCast(Me.pictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' pictureBox1
			' 
			Me.pictureBox1.BackgroundImage = My.Resources.sniffcat
			Me.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
			Me.pictureBox1.Location = New System.Drawing.Point(0, 0)
			Me.pictureBox1.Name = "pictureBox1"
			Me.pictureBox1.Size = New System.Drawing.Size(281, 282)
			Me.pictureBox1.TabIndex = 0
			Me.pictureBox1.TabStop = False
			' 
			' label1
			' 
			Me.label1.Cursor = System.Windows.Forms.Cursors.Hand
			Me.label1.ForeColor = System.Drawing.Color.LightGray
			Me.label1.Location = New System.Drawing.Point(12, 285)
			Me.label1.Name = "label1"
			Me.label1.Size = New System.Drawing.Size(257, 23)
			Me.label1.TabIndex = 1
			Me.label1.Text = "MONSTERMC"
			Me.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.label1.Click += New System.EventHandler(Me.label1_Click_1)
			' 
			' label2
			' 
			Me.label2.Cursor = System.Windows.Forms.Cursors.Hand
			Me.label2.ForeColor = System.Drawing.Color.LightGray
			Me.label2.Location = New System.Drawing.Point(12, 308)
			Me.label2.Name = "label2"
			Me.label2.Size = New System.Drawing.Size(257, 23)
			Me.label2.TabIndex = 2
			Me.label2.Text = "github.com/noradlb1"
			Me.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
'			Me.label2.Click += New System.EventHandler(Me.label2_Click)
			' 
			' infoPanel
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.BackColor = System.Drawing.Color.FromArgb((CInt((CByte(20)))), (CInt((CByte(20)))), (CInt((CByte(20)))))
			Me.ClientSize = New System.Drawing.Size(281, 336)
			Me.Controls.Add(Me.label2)
			Me.Controls.Add(Me.label1)
			Me.Controls.Add(Me.pictureBox1)
			Me.Icon = (DirectCast(resources.GetObject("$this.Icon"), System.Drawing.Icon))
			Me.Name = "infoPanel"
			Me.Text = "QR grabber information"
			DirectCast(Me.pictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region

		Private pictureBox1 As System.Windows.Forms.PictureBox
		Private WithEvents label1 As System.Windows.Forms.Label
		Private WithEvents label2 As System.Windows.Forms.Label
	End Class
End Namespace