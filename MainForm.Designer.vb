Partial Class MainForm
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
		Me.textBoxUser = New System.Windows.Forms.TextBox()
		Me.buttonLogin = New System.Windows.Forms.Button()
		Me.buttonRegister = New System.Windows.Forms.Button()
		Me.buttonDemo = New System.Windows.Forms.Button()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.textBoxUser)
		Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(292, 75)
		Me.groupBox1.TabIndex = 0
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "User:"
		' 
		' textBoxUser
		' 
		Me.textBoxUser.Dock = System.Windows.Forms.DockStyle.Fill
		Me.textBoxUser.Location = New System.Drawing.Point(3, 16)
		Me.textBoxUser.Name = "textBoxUser"
		Me.textBoxUser.Size = New System.Drawing.Size(286, 20)
		Me.textBoxUser.TabIndex = 0
		' 
		' buttonLogin
		' 
		Me.buttonLogin.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonLogin.Location = New System.Drawing.Point(0, 75)
		Me.buttonLogin.Name = "buttonLogin"
		Me.buttonLogin.Size = New System.Drawing.Size(292, 40)
		Me.buttonLogin.TabIndex = 1
		Me.buttonLogin.Text = "Login"
		Me.buttonLogin.UseVisualStyleBackColor = True
		AddHandler Me.buttonLogin.Click, New System.EventHandler(AddressOf Me.buttonLogin_Click)
		' 
		' buttonRegister
		' 
		Me.buttonRegister.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonRegister.Location = New System.Drawing.Point(0, 115)
		Me.buttonRegister.Name = "buttonRegister"
		Me.buttonRegister.Size = New System.Drawing.Size(292, 34)
		Me.buttonRegister.TabIndex = 2
		Me.buttonRegister.Text = "Register"
		Me.buttonRegister.UseVisualStyleBackColor = True
		AddHandler Me.buttonRegister.Click, New System.EventHandler(AddressOf Me.buttonRegister_Click)
		' 
		' buttonDemo
		' 
		Me.buttonDemo.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonDemo.Location = New System.Drawing.Point(0, 149)
		Me.buttonDemo.Name = "buttonDemo"
		Me.buttonDemo.Size = New System.Drawing.Size(292, 34)
		Me.buttonDemo.TabIndex = 3
		Me.buttonDemo.Text = "DEMO"
		Me.buttonDemo.UseVisualStyleBackColor = True
		' 
		' MainForm
		' 
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.ClientSize = New System.Drawing.Size(292, 177)
		Me.Controls.Add(Me.buttonDemo)
		Me.Controls.Add(Me.buttonRegister)
		Me.Controls.Add(Me.buttonLogin)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "MainForm"
		Me.Text = "MainForm"
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private groupBox1 As System.Windows.Forms.GroupBox
	Private textBoxUser As System.Windows.Forms.TextBox
	Private buttonLogin As System.Windows.Forms.Button
	Private buttonRegister As System.Windows.Forms.Button
	Private buttonDemo As System.Windows.Forms.Button
End Class
