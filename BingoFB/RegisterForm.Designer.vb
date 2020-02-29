<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class RegisterForm
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
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TextBoxMuseName = New System.Windows.Forms.TextBox()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TextBoxMuseId = New System.Windows.Forms.TextBox()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.ButtonAccept = New System.Windows.Forms.Button()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TextBoxMuseName)
        Me.GroupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox1.Location = New System.Drawing.Point(0, 0)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(292, 50)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Muse name:"
        '
        'TextBoxMuseName
        '
        Me.TextBoxMuseName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMuseName.Location = New System.Drawing.Point(3, 16)
        Me.TextBoxMuseName.Name = "TextBoxMuseName"
        Me.TextBoxMuseName.Size = New System.Drawing.Size(286, 20)
        Me.TextBoxMuseName.TabIndex = 1
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TextBoxMuseId)
        Me.GroupBox2.Dock = System.Windows.Forms.DockStyle.Top
        Me.GroupBox2.Location = New System.Drawing.Point(0, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(292, 50)
        Me.GroupBox2.TabIndex = 1
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Muse id:"
        '
        'TextBoxMuseId
        '
        Me.TextBoxMuseId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TextBoxMuseId.Location = New System.Drawing.Point(3, 16)
        Me.TextBoxMuseId.Name = "TextBoxMuseId"
        Me.TextBoxMuseId.Size = New System.Drawing.Size(286, 20)
        Me.TextBoxMuseId.TabIndex = 1
        '
        'Splitter1
        '
        Me.Splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Splitter1.Location = New System.Drawing.Point(0, 100)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(292, 11)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'ButtonAccept
        '
        Me.ButtonAccept.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonAccept.Location = New System.Drawing.Point(0, 111)
        Me.ButtonAccept.Name = "ButtonAccept"
        Me.ButtonAccept.Size = New System.Drawing.Size(292, 49)
        Me.ButtonAccept.TabIndex = 3
        Me.ButtonAccept.Text = "Accept"
        Me.ButtonAccept.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Dock = System.Windows.Forms.DockStyle.Top
        Me.ButtonCancel.Location = New System.Drawing.Point(0, 160)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(292, 55)
        Me.ButtonCancel.TabIndex = 4
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(292, 224)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonAccept)
        Me.Controls.Add(Me.Splitter1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxMuseName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents TextBoxMuseId As System.Windows.Forms.TextBox
    Friend WithEvents Splitter1 As System.Windows.Forms.Splitter
    Friend WithEvents ButtonAccept As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
End Class
