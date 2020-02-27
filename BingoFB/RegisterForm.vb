Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Partial Class RegisterForm
	Inherits Form
	Implements IFORM
	Private actionTaken As DialogStep
    Private managementForm As ManagementForm
    Private mainUrl As String = "http://bingo-fb.com/users/"
    Private m_password As String

	Public Sub New(parent As System.Windows.Forms.IWin32Window, mf As ManagementForm)
		InitializeComponent()
		managementForm = mf
		Me.MdiParent = TryCast(parent, DashboardForm)
	End Sub

    Private Sub buttonCancel_Click(sender As Object, e As EventArgs)
        actionTaken = DialogStep.LOGIN
        managementForm.RunLoop("RegisterForm")
    End Sub

    Private Sub buttonAccept_Click(sender As Object, e As EventArgs)
        If String.IsNullOrEmpty(Me.textBoxMuseName.Text) Then
            MessageBox.Show(Me, String.Format("user name smaller than or empty {0}", Me.textBoxMuseName.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        ElseIf String.IsNullOrEmpty(Me.textBoxMuseId.Text) Then
            MessageBox.Show(Me, String.Format("user name smaller than or empty {0}", Me.textBoxMuseId.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
        Else
            Dim paramurl As New ParameterUrl
            paramurl.url = String.Format("{0}{1}", Me.mainUrl, "register.php")
            paramurl.musename = Me.textBoxMuseName.Text
            paramurl.password = Me.m_password
            paramurl.museid = Me.textBoxMuseId.Text
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
                MessageBox.Show(Me, String.Format("Registration success {0}. Please be patien an admin will activated.", Me.textBoxMuseName.Text), "User registration", MessageBoxButtons.OK, MessageBoxIcon.Asterisk)
                Me.actionTaken = DialogStep.LOGIN
                Me.managementForm.RunLoop("RegisterForm")
            Catch exception As Exception
                Me.managementForm.AppendLog(Level.Error, String.Format("what:{0} {1}", exception.HelpLink, exception.Message))
            End Try
        End If
    End Sub

	Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
		Get
			Return Me.actionTaken
		End Get
    End Property

    Public WriteOnly Property Password As String
        Set(ByVal value As String)
            Me.m_password = value
        End Set
    End Property

End Class
