Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Enum SERVERS As Integer
	VIETNAM = 0
	KOREA = 1
	TAIWAN = 2
	GLOBAL_SERVER = 3

End Enum

Public Enum SERVER_MODE As Integer
	MOBILE = 0
	EMULATOR = 1
End Enum

Public Enum MODE As Integer
	OFFLINE = 0
	ONLINE = 1
End Enum

Public Partial Class BypassForm
	Inherits Form
	Implements IFORM
	Private mainUrl As String = "http://bingo-fb.com/users/"

	Private activeUser As String
	Private status As Boolean

	Private ActionTaken As DialogStep

	Private managementForm As ManagementForm

	Public Sub New(parent As System.Windows.Forms.IWin32Window, mf As ManagementForm)
		InitializeComponent()
		managementForm = mf
		Me.MdiParent = TryCast(parent, DashboardForm)
		Dim servers As String() = [Enum].GetNames(GetType(SERVERS))
		Dim servers_mode As String() = [Enum].GetNames(GetType(SERVER_MODE))
		comboBoxServer.Items.AddRange(servers)
		comboBoxMode.Items.AddRange(servers_mode)
		comboBoxMode.SelectedIndex = 0
		comboBoxServer.SelectedIndex = 0
	End Sub

	Public WriteOnly Property MuseId() As [String]
		Set
			activeUser = value
		End Set
	End Property

	Private Sub buttonLogout_Click(sender As Object, e As EventArgs)
		Dim LogoutPHP As New ParameterUrl()
		LogoutPHP.musename = activeUser
		LogoutPHP.password = ""
		LogoutPHP.mode = PHP_MODE.LOGOUT
		LogoutPHP.timeout = 300000
		LogoutPHP.url = String.Format("{0}{1}", mainUrl, "logout.php").Trim()
		LogoutPHP.method = Method.POST
		Try
			Dim response As RESPONSE_FEEDBACK = New NetworkManager().Connect(LogoutPHP)
			If response.status = False Then
				Throw New Exception(String.Format("Logout Failed. {0}", response.message))
			Else
				status = response.status
			End If
			ActionTaken = DialogStep.LOGIN
			managementForm.RunLoop("BypassForm")
		Catch ex As Exception
			managementForm.AppendLog(Level.[Error], [String].Format("what:{0} {1}", ex.HelpLink, ex.Message))
		End Try

	End Sub

	Private Sub BypassForm_Load(sender As Object, e As EventArgs)
		Me.textBox1.Text = activeUser
	End Sub


	Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
		Get
			Return ActionTaken
		End Get
	End Property
End Class
