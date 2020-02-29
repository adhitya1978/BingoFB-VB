<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class BypassForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.groupBox1 = New System.Windows.Forms.GroupBox()
        Me.groupBox4 = New System.Windows.Forms.GroupBox()
        Me.buttonRestart = New System.Windows.Forms.Button()
        Me.buttonDownload = New System.Windows.Forms.Button()
        Me.buttonOPENH = New System.Windows.Forms.Button()
        Me.buttonOpen = New System.Windows.Forms.Button()
        Me.groupBox3 = New System.Windows.Forms.GroupBox()
        Me.comboBoxMode = New System.Windows.Forms.ComboBox()
        Me.groupBox2 = New System.Windows.Forms.GroupBox()
        Me.comboBoxServer = New System.Windows.Forms.ComboBox()
        Me.textBox1 = New System.Windows.Forms.TextBox()
        Me.buttonLogout = New System.Windows.Forms.Button()
        Me.groupBox1.SuspendLayout()
        Me.groupBox4.SuspendLayout()
        Me.groupBox3.SuspendLayout()
        Me.groupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.groupBox4)
        Me.groupBox1.Controls.Add(Me.groupBox3)
        Me.groupBox1.Controls.Add(Me.groupBox2)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox1.Location = New System.Drawing.Point(0, 0)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(421, 249)
        Me.groupBox1.TabIndex = 1
        Me.groupBox1.TabStop = False
        '
        'groupBox4
        '
        Me.groupBox4.Controls.Add(Me.buttonRestart)
        Me.groupBox4.Controls.Add(Me.buttonDownload)
        Me.groupBox4.Controls.Add(Me.buttonOPENH)
        Me.groupBox4.Controls.Add(Me.buttonOpen)
        Me.groupBox4.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox4.Location = New System.Drawing.Point(3, 115)
        Me.groupBox4.Name = "groupBox4"
        Me.groupBox4.Size = New System.Drawing.Size(415, 125)
        Me.groupBox4.TabIndex = 2
        Me.groupBox4.TabStop = False
        '
        'buttonRestart
        '
        Me.buttonRestart.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonRestart.Location = New System.Drawing.Point(3, 85)
        Me.buttonRestart.Name = "buttonRestart"
        Me.buttonRestart.Size = New System.Drawing.Size(409, 23)
        Me.buttonRestart.TabIndex = 3
        Me.buttonRestart.Text = "Restart"
        Me.buttonRestart.UseVisualStyleBackColor = True
        '
        'buttonDownload
        '
        Me.buttonDownload.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonDownload.Location = New System.Drawing.Point(3, 62)
        Me.buttonDownload.Name = "buttonDownload"
        Me.buttonDownload.Size = New System.Drawing.Size(409, 23)
        Me.buttonDownload.TabIndex = 2
        Me.buttonDownload.Text = "Download"
        Me.buttonDownload.UseVisualStyleBackColor = True
        '
        'buttonOPENH
        '
        Me.buttonOPENH.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonOPENH.Location = New System.Drawing.Point(3, 39)
        Me.buttonOPENH.Name = "buttonOPENH"
        Me.buttonOPENH.Size = New System.Drawing.Size(409, 23)
        Me.buttonOPENH.TabIndex = 1
        Me.buttonOPENH.Text = "OPEN H"
        Me.buttonOPENH.UseVisualStyleBackColor = True
        '
        'buttonOpen
        '
        Me.buttonOpen.Dock = System.Windows.Forms.DockStyle.Top
        Me.buttonOpen.Location = New System.Drawing.Point(3, 16)
        Me.buttonOpen.Name = "buttonOpen"
        Me.buttonOpen.Size = New System.Drawing.Size(409, 23)
        Me.buttonOpen.TabIndex = 0
        Me.buttonOpen.Text = "OPEN"
        Me.buttonOpen.UseVisualStyleBackColor = True
        '
        'groupBox3
        '
        Me.groupBox3.Controls.Add(Me.comboBoxMode)
        Me.groupBox3.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox3.Location = New System.Drawing.Point(3, 66)
        Me.groupBox3.Name = "groupBox3"
        Me.groupBox3.Size = New System.Drawing.Size(415, 49)
        Me.groupBox3.TabIndex = 1
        Me.groupBox3.TabStop = False
        Me.groupBox3.Text = "Mode:"
        '
        'comboBoxMode
        '
        Me.comboBoxMode.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comboBoxMode.FormattingEnabled = True
        Me.comboBoxMode.Location = New System.Drawing.Point(3, 16)
        Me.comboBoxMode.Name = "comboBoxMode"
        Me.comboBoxMode.Size = New System.Drawing.Size(409, 21)
        Me.comboBoxMode.TabIndex = 0
        '
        'groupBox2
        '
        Me.groupBox2.Controls.Add(Me.comboBoxServer)
        Me.groupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox2.Location = New System.Drawing.Point(3, 16)
        Me.groupBox2.Name = "groupBox2"
        Me.groupBox2.Size = New System.Drawing.Size(415, 50)
        Me.groupBox2.TabIndex = 0
        Me.groupBox2.TabStop = False
        Me.groupBox2.Text = "Server:"
        '
        'comboBoxServer
        '
        Me.comboBoxServer.Dock = System.Windows.Forms.DockStyle.Fill
        Me.comboBoxServer.FormattingEnabled = True
        Me.comboBoxServer.Location = New System.Drawing.Point(3, 16)
        Me.comboBoxServer.Name = "comboBoxServer"
        Me.comboBoxServer.Size = New System.Drawing.Size(409, 21)
        Me.comboBoxServer.TabIndex = 0
        '
        'textBox1
        '
        Me.textBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.textBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.textBox1.Location = New System.Drawing.Point(0, 249)
        Me.textBox1.Name = "textBox1"
        Me.textBox1.ReadOnly = True
        Me.textBox1.Size = New System.Drawing.Size(421, 20)
        Me.textBox1.TabIndex = 5
        '
        'buttonLogout
        '
        Me.buttonLogout.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonLogout.Location = New System.Drawing.Point(0, 296)
        Me.buttonLogout.Name = "buttonLogout"
        Me.buttonLogout.Size = New System.Drawing.Size(421, 32)
        Me.buttonLogout.TabIndex = 6
        Me.buttonLogout.Text = "Logout"
        Me.buttonLogout.UseVisualStyleBackColor = True
        '
        'BypassForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(421, 328)
        Me.Controls.Add(Me.textBox1)
        Me.Controls.Add(Me.buttonLogout)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "BypassForm"
        Me.Text = "Form1"
        Me.groupBox1.ResumeLayout(False)
        Me.groupBox4.ResumeLayout(False)
        Me.groupBox3.ResumeLayout(False)
        Me.groupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Private WithEvents groupBox1 As System.Windows.Forms.GroupBox
    Private WithEvents groupBox4 As System.Windows.Forms.GroupBox
    Private WithEvents buttonRestart As System.Windows.Forms.Button
    Private WithEvents buttonDownload As System.Windows.Forms.Button
    Private WithEvents buttonOPENH As System.Windows.Forms.Button
    Private WithEvents buttonOpen As System.Windows.Forms.Button
    Private WithEvents groupBox3 As System.Windows.Forms.GroupBox
    Private WithEvents comboBoxMode As System.Windows.Forms.ComboBox
    Private WithEvents groupBox2 As System.Windows.Forms.GroupBox
    Private WithEvents comboBoxServer As System.Windows.Forms.ComboBox
    Private WithEvents textBox1 As System.Windows.Forms.TextBox
    Private WithEvents buttonLogout As System.Windows.Forms.Button
End Class
