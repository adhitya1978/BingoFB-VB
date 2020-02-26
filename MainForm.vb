Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Windows.Forms

Public Partial Class MainForm
	Inherits Form
	Implements IFORM
	Private m_status As Boolean
	Private password As String
	Private m_museid As String

	Private actionTaken As DialogStep

	Private managementForm As ManagementForm

	Public Sub New(parent As System.Windows.Forms.IWin32Window, manForm As ManagementForm)
		InitializeComponent()
		managementForm = manForm
		Me.MdiParent = TryCast(parent, DashboardForm)
	End Sub

	Private mainUrl As String = "http://bingo-fb.com/users/"

	Private Sub buttonLogin_Click(sender As Object, e As EventArgs)
		m_museid = Me.textBoxUser.Text
		Dim LoginPHP As New ParameterUrl()
		LoginPHP.musename = m_museid
		LoginPHP.password = password
		LoginPHP.mode = PHP_MODE.LOGIN
		LoginPHP.timeout = 300000
		LoginPHP.url = String.Format("{0}{1}", mainUrl, "login.php").Trim()
		LoginPHP.method = Method.POST
		Try
			Dim response As RESPONSE_FEEDBACK = New NetworkManager().Connect(LoginPHP)
			If response.status = False Then
				Throw New Exception(String.Format("Login Failed. {0}", response.message))
			End If
			m_status = response.status
			actionTaken = DialogStep.BYPASS
			managementForm.RunLoop("MainForm")
		Catch ex As Exception
			managementForm.AppendLog(Level.[Error], [String].Format("what:{0} {1}", ex.HelpLink, ex.Message))
		End Try
	End Sub

	Public WriteOnly Property SetPassword() As String
		Set
			password = value
		End Set
	End Property

	Public ReadOnly Property MuseId() As String
		Get
			Return Me.m_museid
		End Get
	End Property

	Public ReadOnly Property STATUS() As Boolean
		Get
			Return Me.m_status
		End Get
	End Property

	Private Sub buttonRegister_Click(sender As Object, e As EventArgs)
		actionTaken = DialogStep.REGISTER
		managementForm.RunLoop("MainForm")
	End Sub


	Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
		Get
			Return Me.actionTaken
		End Get
	End Property

End Class
