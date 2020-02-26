Partial Class RegisterForm
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
		Me.buttonCancel = New System.Windows.Forms.Button()
		Me.buttonAccept = New System.Windows.Forms.Button()
		Me.groupBox1 = New System.Windows.Forms.GroupBox()
		Me.labelUser = New System.Windows.Forms.Label()
		Me.textBox1 = New System.Windows.Forms.TextBox()
		Me.groupBox1.SuspendLayout()
		Me.SuspendLayout()
		' 
		' buttonCancel
		' 
		Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
		Me.buttonCancel.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonCancel.Location = New System.Drawing.Point(0, 65)
		Me.buttonCancel.Name = "buttonCancel"
		Me.buttonCancel.Size = New System.Drawing.Size(292, 46)
		Me.buttonCancel.TabIndex = 0
		Me.buttonCancel.Text = "Cancel"
		Me.buttonCancel.UseVisualStyleBackColor = True
		AddHandler Me.buttonCancel.Click, New System.EventHandler(AddressOf Me.buttonCancel_Click)
		' 
		' buttonAccept
		' 
		Me.buttonAccept.Dock = System.Windows.Forms.DockStyle.Top
		Me.buttonAccept.Location = New System.Drawing.Point(0, 111)
		Me.buttonAccept.Name = "buttonAccept"
		Me.buttonAccept.Size = New System.Drawing.Size(292, 43)
		Me.buttonAccept.TabIndex = 1
		Me.buttonAccept.Text = "Accept"
		Me.buttonAccept.UseVisualStyleBackColor = True
		AddHandler Me.buttonAccept.Click, New System.EventHandler(AddressOf Me.buttonAccept_Click)
		' 
		' groupBox1
		' 
		Me.groupBox1.Controls.Add(Me.labelUser)
		Me.groupBox1.Controls.Add(Me.textBox1)
		Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
		Me.groupBox1.Location = New System.Drawing.Point(0, 0)
		Me.groupBox1.Name = "groupBox1"
		Me.groupBox1.Size = New System.Drawing.Size(292, 65)
		Me.groupBox1.TabIndex = 2
		Me.groupBox1.TabStop = False
		Me.groupBox1.Text = "User Registration"
		' 
		' labelUser
		' 
		Me.labelUser.AutoSize = True
		Me.labelUser.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.labelUser.Location = New System.Drawing.Point(3, 29)
		Me.labelUser.Name = "labelUser"
		Me.labelUser.Size = New System.Drawing.Size(32, 13)
		Me.labelUser.TabIndex = 1
		Me.labelUser.Text = "User:"
		' 
		' textBox1
		' 
		Me.textBox1.Dock = System.Windows.Forms.DockStyle.Bottom
		Me.textBox1.Location = New System.Drawing.Point(3, 42)
		Me.textBox1.Name = "textBox1"
		Me.textBox1.Size = New System.Drawing.Size(286, 20)
		Me.textBox1.TabIndex = 0
		' 
		' RegisterForm
		' 
		Me.AcceptButton = Me.buttonAccept
		Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
		Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
		Me.CancelButton = Me.buttonCancel
		Me.ClientSize = New System.Drawing.Size(292, 183)
		Me.Controls.Add(Me.buttonAccept)
		Me.Controls.Add(Me.buttonCancel)
		Me.Controls.Add(Me.groupBox1)
		Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
		Me.Name = "RegisterForm"
		Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
		Me.Text = "RegisterForm"
		Me.groupBox1.ResumeLayout(False)
		Me.groupBox1.PerformLayout()
		Me.ResumeLayout(False)

	End Sub

	#End Region

	Private buttonCancel As System.Windows.Forms.Button
	Private buttonAccept As System.Windows.Forms.Button
	Private groupBox1 As System.Windows.Forms.GroupBox
	Private labelUser As System.Windows.Forms.Label
	Private textBox1 As System.Windows.Forms.TextBox
End Class
