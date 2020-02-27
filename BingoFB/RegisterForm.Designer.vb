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
        Me.splitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.labelMuseId = New System.Windows.Forms.Label()
        Me.textBoxMuseId = New System.Windows.Forms.TextBox()
        Me.splitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.labelUser = New System.Windows.Forms.Label()
        Me.textBoxMuseName = New System.Windows.Forms.TextBox()
        Me.splitter1 = New System.Windows.Forms.Splitter()
        Me.groupBox1.SuspendLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer2.Panel1.SuspendLayout()
        Me.splitContainer2.Panel2.SuspendLayout()
        Me.splitContainer2.SuspendLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.splitContainer1.Panel1.SuspendLayout()
        Me.splitContainer1.Panel2.SuspendLayout()
        Me.splitContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'buttonCancel
        '
        Me.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.buttonCancel.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonCancel.Location = New System.Drawing.Point(0, 235)
        Me.buttonCancel.Name = "buttonCancel"
        Me.buttonCancel.Size = New System.Drawing.Size(383, 56)
        Me.buttonCancel.TabIndex = 0
        Me.buttonCancel.Text = "Cancel"
        Me.buttonCancel.UseVisualStyleBackColor = True
        AddHandler Me.buttonCancel.Click, New System.EventHandler(AddressOf Me.buttonCancel_Click)
        '
        'buttonAccept
        '
        Me.buttonAccept.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.buttonAccept.Location = New System.Drawing.Point(0, 182)
        Me.buttonAccept.Name = "buttonAccept"
        Me.buttonAccept.Size = New System.Drawing.Size(383, 53)
        Me.buttonAccept.TabIndex = 1
        Me.buttonAccept.Text = "Accept"
        Me.buttonAccept.UseVisualStyleBackColor = True
        AddHandler Me.buttonAccept.Click, New System.EventHandler(AddressOf Me.buttonAccept_Click)
        '
        'groupBox1
        '
        Me.groupBox1.Controls.Add(Me.splitContainer2)
        Me.groupBox1.Controls.Add(Me.splitContainer1)
        Me.groupBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.groupBox1.Location = New System.Drawing.Point(0, 0)
        Me.groupBox1.Name = "groupBox1"
        Me.groupBox1.Size = New System.Drawing.Size(383, 90)
        Me.groupBox1.TabIndex = 2
        Me.groupBox1.TabStop = False
        Me.groupBox1.Text = "User Registration"
        '
        'splitContainer2
        '
        Me.splitContainer2.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitContainer2.Location = New System.Drawing.Point(3, 46)
        Me.splitContainer2.Name = "splitContainer2"
        '
        'splitContainer2.Panel1
        '
        Me.splitContainer2.Panel1.Controls.Add(Me.labelMuseId)
        '
        'splitContainer2.Panel2
        '
        Me.splitContainer2.Panel2.Controls.Add(Me.textBoxMuseId)
        Me.splitContainer2.Size = New System.Drawing.Size(377, 27)
        Me.splitContainer2.SplitterDistance = 60
        Me.splitContainer2.TabIndex = 5
        '
        'labelMuseId
        '
        Me.labelMuseId.AutoSize = True
        Me.labelMuseId.Location = New System.Drawing.Point(6, 7)
        Me.labelMuseId.Name = "labelMuseId"
        Me.labelMuseId.Size = New System.Drawing.Size(45, 13)
        Me.labelMuseId.TabIndex = 2
        Me.labelMuseId.Text = "MuseId:"
        '
        'textBoxMuseId
        '
        Me.textBoxMuseId.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textBoxMuseId.Location = New System.Drawing.Point(0, 0)
        Me.textBoxMuseId.Name = "textBoxMuseId"
        Me.textBoxMuseId.Size = New System.Drawing.Size(313, 20)
        Me.textBoxMuseId.TabIndex = 3
        '
        'splitContainer1
        '
        Me.splitContainer1.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitContainer1.Location = New System.Drawing.Point(3, 16)
        Me.splitContainer1.Name = "splitContainer1"
        '
        'splitContainer1.Panel1
        '
        Me.splitContainer1.Panel1.Controls.Add(Me.labelUser)
        '
        'splitContainer1.Panel2
        '
        Me.splitContainer1.Panel2.Controls.Add(Me.textBoxMuseName)
        Me.splitContainer1.Size = New System.Drawing.Size(377, 30)
        Me.splitContainer1.SplitterDistance = 60
        Me.splitContainer1.TabIndex = 4
        '
        'labelUser
        '
        Me.labelUser.AutoSize = True
        Me.labelUser.Location = New System.Drawing.Point(9, 3)
        Me.labelUser.Name = "labelUser"
        Me.labelUser.Size = New System.Drawing.Size(32, 13)
        Me.labelUser.TabIndex = 1
        Me.labelUser.Text = "User:"
        '
        'textBoxMuseName
        '
        Me.textBoxMuseName.Dock = System.Windows.Forms.DockStyle.Fill
        Me.textBoxMuseName.Location = New System.Drawing.Point(0, 0)
        Me.textBoxMuseName.Name = "textBoxMuseName"
        Me.textBoxMuseName.Size = New System.Drawing.Size(313, 20)
        Me.textBoxMuseName.TabIndex = 0
        '
        'splitter1
        '
        Me.splitter1.Dock = System.Windows.Forms.DockStyle.Top
        Me.splitter1.Location = New System.Drawing.Point(0, 90)
        Me.splitter1.Name = "splitter1"
        Me.splitter1.Size = New System.Drawing.Size(383, 47)
        Me.splitter1.TabIndex = 3
        Me.splitter1.TabStop = False
        '
        'RegisterForm
        '
        Me.AcceptButton = Me.buttonAccept
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.buttonCancel
        Me.ClientSize = New System.Drawing.Size(383, 291)
        Me.Controls.Add(Me.splitter1)
        Me.Controls.Add(Me.buttonAccept)
        Me.Controls.Add(Me.buttonCancel)
        Me.Controls.Add(Me.groupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "RegisterForm"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "RegisterForm"
        Me.groupBox1.ResumeLayout(False)
        Me.splitContainer2.Panel1.ResumeLayout(False)
        Me.splitContainer2.Panel1.PerformLayout()
        Me.splitContainer2.Panel2.ResumeLayout(False)
        Me.splitContainer2.Panel2.PerformLayout()
        CType(Me.splitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer2.ResumeLayout(False)
        Me.splitContainer1.Panel1.ResumeLayout(False)
        Me.splitContainer1.Panel1.PerformLayout()
        Me.splitContainer1.Panel2.ResumeLayout(False)
        Me.splitContainer1.Panel2.PerformLayout()
        CType(Me.splitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.splitContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

#End Region

    Private buttonCancel As System.Windows.Forms.Button
    Private buttonAccept As System.Windows.Forms.Button
    Private groupBox1 As System.Windows.Forms.GroupBox
    Private labelUser As System.Windows.Forms.Label
    Private textBoxMuseName As System.Windows.Forms.TextBox
    Private labelMuseId As System.Windows.Forms.Label
    Private textBoxMuseId As System.Windows.Forms.TextBox
    Private splitContainer2 As System.Windows.Forms.SplitContainer
    Private splitContainer1 As System.Windows.Forms.SplitContainer
    Private splitter1 As System.Windows.Forms.Splitter
End Class
