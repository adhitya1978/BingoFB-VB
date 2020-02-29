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

Public Class BypassForm
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

    Private Sub buttonLogout_Click(sender As Object, e As EventArgs) Handles buttonLogout.Click
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

    Private Sub buttonOpen_Click(sender As Object, e As EventArgs) Handles buttonOpen.Click
        '! get server mode dari user
        Dim server As SERVERS = CType([Enum].Parse(GetType(SERVERS), comboBoxServer.GetItemText(comboBoxServer.SelectedIndex)), SERVERS)
        '! get mode play dari user
        Dim mode As SERVER_MODE = CType([Enum].Parse(GetType(SERVERS), comboBoxMode.GetItemText(comboBoxMode.SelectedIndex)), SERVER_MODE)
        '! start a logic in here
        '! catch an error into logging form avoid an crash application
        Try

            If mode = SERVER_MODE.EMULATOR AndAlso server = SERVERS.GLOBAL_SERVER Then
                Dim GServer As New [Global]()
                GServer.KiLLServer()
                '! if no device return 
                If String.IsNullOrEmpty(GServer.InitDevices()) Then
                    Return
                End If
                GServer.ConnectDevice()
                GServer.Remount("system")
                GServer.Remount("data")
                GServer.Remount("data/data")
                '! launcer game
                GServer.Lancher("com.tencent.ig")
                GServer.Rename("init.vbox86.rc", "initvbox86.txt")
                GServer.Remove("data/data/com.netease.uu", 20)

                GServer.Remove("data/app-lib/com.tencent.ig-1/libcubehawk.so", 0)
            End If
            If mode = SERVER_MODE.EMULATOR AndAlso server = SERVERS.KOREA Then
            End If
        Catch ex As Exception
            managementForm.AppendLog(Level.[Error], String.Format("what:{0}{1}", ex.StackTrace, ex.Message))
        End Try

    End Sub
    Public WriteOnly Property MuseId() As [String]
        Set(value As [String])
            activeUser = value
        End Set
    End Property

    Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
        Get
            Return ActionTaken
        End Get
    End Property

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.textBox1.Text = activeUser
    End Sub
End Class