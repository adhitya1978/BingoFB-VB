<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class LoggerForm
	''' <summary>
	''' Required designer variable.
	''' </summary>
	Private components As System.ComponentModel.IContainer = Nothing

	''' <summary>
	''' Clean up any resources being used.
	''' </summary>
	''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
	Protected Overrides Sub Dispose(disposing As Boolean)
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
	<System.Diagnostics.DebuggerStepThrough()> _
	Private Sub InitializeComponent()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.listBox1 = New System.Windows.Forms.ListBox()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.listBox1)
		Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(455, 97)
		Me.groupBox1.TabIndex = 0
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "Log"
		' 
		' listBox1
		' 
		Me.listBox1.BackColor = System.Drawing.SystemColors.MenuText
		Me.listBox1.Dock = System.Windows.Forms.DockStyle.Fill
		Me.listBox1.FormattingEnabled = True
		Me.listBox1.Location = New System.Drawing.Point(3, 16)
		Me.listBox1.Name = "listBox1"
		Me.listBox1.Size = New System.Drawing.Size(449, 78)
		Me.listBox1.TabIndex = 0
		' 
		' Logger
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(455, 97)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "Logger"
		Me.Text = "Logger"
		Me.groupBox1.ResumeLayout(False)
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private groupBox1 As System.Windows.Forms.GroupBox
	Private listBox1 As System.Windows.Forms.ListBox
End Class
