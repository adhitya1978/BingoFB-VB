Public Class RegisterForm
    Implements IFORM
    Private actionTaken As DialogStep
    Private managementForm As ManagementForm
    Private mainUrl As String = "http://bingo-fb.com/users/"
    Private m_password As String

    Public Sub New(parent As System.Windows.Forms.IWin32Window, mf As ManagementForm)
        InitializeComponent()
        ManagementForm = mf
        Me.MdiParent = TryCast(parent, DashboardForm)
    End Sub
    Private Sub ButtonAccept_Click(sender As Object, e As EventArgs) Handles ButtonAccept.Click
        If String.IsNullOrEmpty(Me.TextBoxMuseName.Text) Then
            MessageBox.Show(Me, String.Format("user name smaller than or empty {0}", Me.TextBoxMuseName.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf String.IsNullOrEmpty(Me.TextBoxMuseId.Text) Then
            MessageBox.Show(Me, String.Format("user name smaller than or empty {0}", Me.TextBoxMuseId.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim paramurl As New ParameterUrl
            paramurl.url = String.Format("{0}{1}", Me.mainUrl, "register.php")
            paramurl.musename = Me.TextBoxMuseName.Text
            paramurl.password = Me.m_password
            paramurl.museid = Me.TextBoxMuseId.Text
            paramurl.mode = PHP_MODE.REGISTER
            paramurl.timeout = &H7530
            paramurl.method = Method.POST
            Try
                Dim response_feedback As RESPONSE_FEEDBACK = New NetworkManager().Connect(paramurl)
                If Not response_feedback.status Then
                    Me.actionTaken = DialogStep.LOGIN
                    Me.managementForm.RunLoop("RegisterForm")
                    Throw New Exception(String.Format("Registration Failed. {0}", response_feedback.message))
                End If
                '! create email
                Dim message As New Parameter_Email()
                message.display_name = TextBoxMuseName.Text
                message.msg_subject = String.Format("Muse name:{0} - Museid:{1}", TextBoxMuseName.Text, TextBoxMuseId.Text)
                message.msg_body = m_password
                message.sender_address = "aaa@gmail.com"
                message.receive_address = "aaa@yahoo.com"
                message.username = ""
                message.password = ""

                '! send email
                Dim Send As New NetworkManager
                Send.Email(message)

                MessageBox.Show(Me, String.Format("Registration success {0}. Please be patien an admin will activated.", Me.TextBoxMuseName.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.actionTaken = DialogStep.LOGIN
                Me.managementForm.RunLoop("RegisterForm")
            Catch exception As Exception
                Me.managementForm.AppendLog(Level.Error, String.Format("what:{0} {1}", exception.HelpLink, exception.Message))
            End Try
        End If
    End Sub

    Private Sub ButtonCancel_Click(sender As Object, e As EventArgs) Handles ButtonCancel.Click
        actionTaken = DialogStep.LOGIN
        ManagementForm.RunLoop("RegisterForm")
    End Sub
    Public WriteOnly Property Password As String
        Set(ByVal value As String)
            Me.m_password = value
        End Set
    End Property
    Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
        Get
            Return Me.actionTaken
        End Get
    End Property
End Class