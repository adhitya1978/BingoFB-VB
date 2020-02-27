Partial Class BypassForm
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
	Private Sub InitializeComponent()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.buttonLogout = New System.Windows.Forms.Button()
		Me.textBox1 = New System.Windows.Forms.TextBox()
		Me.groupBox4 = New System.Windows.Forms.GroupBox()
		Me.buttonRestart = New System.Windows.Forms.Button()
		Me.buttonDownload = New System.Windows.Forms.Button()
		Me.buttonOPENH = New System.Windows.Forms.Button()
		Me.buttonOpen = New System.Windows.Forms.Button()
		Me.groupBox3 = New System.Windows.Forms.GroupBox()
		Me.comboBoxMode = New System.Windows.Forms.ComboBox()
		Me.groupBox2 = New System.Windows.Forms.GroupBox()
		Me.comboBoxServer = New System.Windows.Forms.ComboBox()
		Me.groupBox1.SuspendLayout()
		Me.groupBox4.SuspendLayout()
		Me.groupBox3.SuspendLayout()
		Me.groupBox2.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.groupBox4)
		Me.groupBox1.Controls.Add(Me.groupBox3)
		Me.groupBox1.Controls.Add(Me.groupBox2)
		Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(462, 276)
		Me.groupBox1.TabIndex = 0
		Me.groupBox1.TabStop = False
		' 
		' buttonLogout
		' 
		Me.buttonLogout.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.buttonLogout.Location = New System.Drawing.Point(0, 312)
		Me.buttonLogout.Name = "buttonLogout"
		Me.buttonLogout.Size = New System.Drawing.Size(462, 32)
		Me.buttonLogout.TabIndex = 4
		Me.buttonLogout.Text = "Logout"
		Me.buttonLogout.UseVisualStyleBackColor = True
		AddHandler Me.buttonLogout.Click, New System.EventHandler(AddressOf Me.buttonLogout_Click)
		' 
		' textBox1
		' 
		Me.textBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.textBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CByte(0))
		Me.textBox1.Location = New System.Drawing.Point(0, 276)
		Me.textBox1.Name = "textBox1"
		Me.textBox1.[ReadOnly] = True
		Me.textBox1.Size = New System.Drawing.Size(462, 20)
		Me.textBox1.TabIndex = 3
		' 
		' groupBox4
		' 
		Me.groupBox4.Controls.Add(Me.buttonRestart)
		Me.groupBox4.Controls.Add(Me.buttonDownload)
		Me.groupBox4.Controls.Add(Me.buttonOPENH)
		Me.groupBox4.Controls.Add(Me.buttonOpen)
		Me.groupBox4.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox4.Location = New System.Drawing.Point(3, 115)
		Me.groupBox4.Name = "groupBox4"
		Me.groupBox4.Size = New System.Drawing.Size(456, 125)
		Me.groupBox4.TabIndex = 2
		Me.groupBox4.TabStop = False
		' 
		' buttonRestart
		' 
		Me.buttonRestart.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonRestart.Location = New System.Drawing.Point(3, 85)
		Me.buttonRestart.Name = "buttonRestart"
		Me.buttonRestart.Size = New System.Drawing.Size(450, 23)
		Me.buttonRestart.TabIndex = 3
		Me.buttonRestart.Text = "Restart"
		Me.buttonRestart.UseVisualStyleBackColor = True
		' 
		' buttonDownload
		' 
		Me.buttonDownload.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonDownload.Location = New System.Drawing.Point(3, 62)
		Me.buttonDownload.Name = "buttonDownload"
		Me.buttonDownload.Size = New System.Drawing.Size(450, 23)
		Me.buttonDownload.TabIndex = 2
		Me.buttonDownload.Text = "Download"
		Me.buttonDownload.UseVisualStyleBackColor = True
		' 
		' buttonOPENH
		' 
		Me.buttonOPENH.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonOPENH.Location = New System.Drawing.Point(3, 39)
		Me.buttonOPENH.Name = "buttonOPENH"
		Me.buttonOPENH.Size = New System.Drawing.Size(450, 23)
		Me.buttonOPENH.TabIndex = 1
		Me.buttonOPENH.Text = "OPEN H"
		Me.buttonOPENH.UseVisualStyleBackColor = True
		' 
		' buttonOpen
		' 
		Me.buttonOpen.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonOpen.Location = New System.Drawing.Point(3, 16)
		Me.buttonOpen.Name = "buttonOpen"
		Me.buttonOpen.Size = New System.Drawing.Size(450, 23)
		Me.buttonOpen.TabIndex = 0
		Me.buttonOpen.Text = "OPEN"
		Me.buttonOpen.UseVisualStyleBackColor = True
		' 
		' groupBox3
		' 
		Me.groupBox3.Controls.Add(Me.comboBoxMode)
		Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox3.Location = New System.Drawing.Point(3, 66)
		Me.groupBox3.Name = "groupBox3"
		Me.groupBox3.Size = New System.Drawing.Size(456, 49)
		Me.groupBox3.TabIndex = 1
		Me.groupBox3.TabStop = False
		Me.groupBox3.Text = "Mode:"
		' 
		' comboBoxMode
		' 
		Me.comboBoxMode.Dock = System.Windows.Forms.DockStyle.Fill
		Me.comboBoxMode.FormattingEnabled = True
		Me.comboBoxMode.Location = New System.Drawing.Point(3, 16)
		Me.comboBoxMode.Name = "comboBoxMode"
		Me.comboBoxMode.Size = New System.Drawing.Size(450, 21)
		Me.comboBoxMode.TabIndex = 0
		' 
		' groupBox2
		' 
		Me.groupBox2.Controls.Add(Me.comboBoxServer)
		Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox2.Location = New System.Drawing.Point(3, 16)
		Me.groupBox2.Name = "groupBox2"
		Me.groupBox2.Size = New System.Drawing.Size(456, 50)
		Me.groupBox2.TabIndex = 0
		Me.groupBox2.TabStop = False
		Me.groupBox2.Text = "Server:"
		' 
		' comboBoxServer
		' 
		Me.comboBoxServer.Dock = System.Windows.Forms.DockStyle.Fill
		Me.comboBoxServer.FormattingEnabled = True
		Me.comboBoxServer.Location = New System.Drawing.Point(3, 16)
		Me.comboBoxServer.Name = "comboBoxServer"
		Me.comboBoxServer.Size = New System.Drawing.Size(450, 21)
		Me.comboBoxServer.TabIndex = 0
		' 
		' BypassForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(462, 344)
		Me.Controls.Add(Me.textBox1)
		Me.Controls.Add(Me.buttonLogout)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "BypassForm"
		Me.Text = "BypassForm"
		AddHandler Me.Load, New System.EventHandler(AddressOf Me.BypassForm_Load)
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox4.ResumeLayout(False)
		Me.groupBox3.ResumeLayout(False)
		Me.groupBox2.ResumeLayout(False)
		Me.ResumeLayout(False)
		Me.PerformLayout()

	End Sub

	#End Region

	Private groupBox1 As System.Windows.Forms.GroupBox
	Private groupBox4 As System.Windows.Forms.GroupBox
	Private buttonRestart As System.Windows.Forms.Button
	Private buttonDownload As System.Windows.Forms.Button
	Private buttonOPENH As System.Windows.Forms.Button
	Private buttonOpen As System.Windows.Forms.Button
	Private groupBox3 As System.Windows.Forms.GroupBox
	Private comboBoxMode As System.Windows.Forms.ComboBox
	Private groupBox2 As System.Windows.Forms.GroupBox
	Private comboBoxServer As System.Windows.Forms.ComboBox
	Private textBox1 As System.Windows.Forms.TextBox
	Private buttonLogout As System.Windows.Forms.Button
End Class
