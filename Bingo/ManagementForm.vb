Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms
'!  class Management Form 
'!  Describe untuk mengatur form Main, Register. dan bypass 
'!  setiap form mempunyai parameter dan class berikut mengatur parameter sebelum dan sesudah form di jalankan
'!  end 


'! Enum atau ID langkah berdasarkan form Main/Login, Register dan bypass
Public Enum DialogStep
	LOGIN
	REGISTER
	BYPASS
End Enum


Public Class ManagementForm
    '! mengumpulkan form 
    ReadOnly ScenarioForm As System.Collections.Hashtable

    Private dialogStep As DialogStep

    Private DialogLog As LoggerForm

    '! prepend parameter  mainform
    Private museid As String
    Private password As String

    '! dashboard form
    Private ReadOnly _ownerDlg As System.Windows.Forms.IWin32Window


    '! constructor
    Public Sub New(owner As System.Windows.Forms.IWin32Window)
        _ownerDlg = owner
        ScenarioForm = New System.Collections.Hashtable()
        SetupLoggerForm()
    End Sub

    '! initial logging form
    Public Sub SetupLoggerForm()
        DialogLog = New LoggerForm(_ownerDlg)
        DialogLog.Dock = System.Windows.Forms.DockStyle.Bottom
        DialogLog.Show()
    End Sub

    '! global insert data logging ke dalam logging form
    Public Sub AppendLog(level As Level, msg As String)
        DialogLog.SetLogged(level, msg)
    End Sub

    '! init form ketika pertama kali applikasi run
    Public Sub init()
        SetupMainForm()
        RunLoop("MainForm")
    End Sub

    '! exekusi form yang akan di tampilkan
    Public Sub RunLoop(nform As String)
        dialogStep = Me.Loopings(nform)
    End Sub
    '! <<-----
    '! karena semua di mulai main form jadi semua akan kembali ke main form
    Private Function GetPreviousDialog(curForm As Form) As String
        Dim currentFormName As String = curForm.Name

        If currentFormName <> "MainForm" Then
            Return "MainForm"
        End If
        Return "MainForm"
    End Function
    '! ----->>
    '! nama form yang akan di pangil setelah mainform
    Private Function GetNextDialog(curForm As Form, firstStep As DialogStep) As String
        Dim curFormName As String = curForm.Name

        If curFormName = "MainForm" AndAlso firstStep = dialogStep.BYPASS Then
            Return "BypassForm"
        End If
        If curFormName = "MainForm" AndAlso firstStep = dialogStep.REGISTER Then
            Return "RegisterForm"
        End If
        Return "MainForm"
    End Function
    '! <>--<>
    '! main function untuk membuang form yang lama dan memangil form yang baru.
    Private Function Loopings(firstForm As String) As DialogStep
        Dim nextstep As DialogStep = dialogStep.LOGIN
        Dim nextForm As String = firstForm
        Dim StopLoop As Boolean = True
        While StopLoop
            '! getting step from mainform
            Dim currentForm As Form = Nothing
            currentForm = TryCast(Me.ScenarioForm(firstForm), Form)
            nextstep = DirectCast(currentForm, IFORM).StepResult

            '! 1. nextstep register
            '! 2. nextstep Bypass

            Select Case nextstep
                Case dialogStep.REGISTER
                    nextForm = Me.GetNextDialog(currentForm, nextstep)
                    NextDialogHandler(nextForm, nextstep)
                    currentForm.Dispose()
                    currentForm = TryCast(Me.ScenarioForm(nextForm), Form)
                    currentForm.Dock = DockStyle.Top
                    currentForm.Show()
                    StopLoop = False
                    Exit Select
                Case dialogStep.BYPASS
                    nextForm = Me.GetNextDialog(currentForm, nextstep)
                    NextDialogHandler(nextForm, nextstep)
                    currentForm.Dispose()
                    currentForm = TryCast(Me.ScenarioForm(nextForm), Form)
                    currentForm.Dock = DockStyle.Top
                    currentForm.Show()
                    StopLoop = False
                    Exit Select
                Case dialogStep.LOGIN
                    nextForm = Me.GetNextDialog(currentForm, nextstep)
                    NextDialogHandler(nextForm, nextstep)
                    currentForm.Dispose()
                    currentForm = TryCast(Me.ScenarioForm(nextForm), Form)
                    currentForm.Dock = DockStyle.Top
                    currentForm.Show()
                    StopLoop = False
                    Exit Select

            End Select
        End While
        Return nextstep
    End Function

    '! -->>***
    '! setup atau mengatur parameter sebelum form di jalankan
    Private Sub NextDialogHandler(curForm As String, [step] As DialogStep)
        If curForm.Equals("BypassForm") AndAlso [step] = dialogStep.BYPASS Then
            SetupBypassForm()
        End If
        If curForm.Equals("RegisterForm") AndAlso [step] = dialogStep.REGISTER Then
            SetupRegisterForm()
        End If
        If curForm.Equals("MainForm") AndAlso [step] = dialogStep.LOGIN Then
            SetupMainForm()
        End If

    End Sub

    '! semua process kembali ke mainform
    Private Sub PreviousDialogHandler(curForm As String)
        SetupMainForm()
    End Sub
#Region "SetupForm"

    '! setup Bypassform
    Private Sub SetupBypassForm()
        Me.DisposeBypassForm()
        Dim F As New BypassForm(_ownerDlg, Me)
        Dim mainForm As MainForm = TryCast(ScenarioForm("MainForm"), MainForm)
        Me.museid = mainForm.MuseId
        F.MuseId = Me.museid
        ScenarioForm.Remove("BypassForm")
        ScenarioForm.Add("BypassForm", F)
    End Sub

    '! setup Register form
    Private Sub SetupRegisterForm()
        Me.DisposeRegisterForm()
        Dim RF As New RegisterForm(_ownerDlg, Me)

        RF.Password = Me.password

        ScenarioForm.Remove("RegisterForm")
        ScenarioForm.Add("RegisterForm", RF)

    End Sub

    '! setup mainform
    Private Sub SetupMainForm()
		Me.DisposeMainForm()
        Dim mainForm As New MainForm(_ownerDlg, Me)
        Me.password = DirectCast(_ownerDlg, DashboardForm).GetPassword
        mainForm.SetPassword = Me.password
        ScenarioForm.Remove("MainForm")
        ScenarioForm.Add("MainForm", mainForm)
    End Sub

#End Region

    '! berikut function membuang form
#Region "DisposeForm"

    Private Sub DisposeRegisterForm()
        Dim f As RegisterForm = TryCast(Me.ScenarioForm("RegisterForm"), RegisterForm)
        If f IsNot Nothing Then
            f.Dispose()
        End If
    End Sub

    Private Sub DisposeBypassForm()
        Dim f As BypassForm = TryCast(ScenarioForm("BypassForm"), BypassForm)
        If f IsNot Nothing Then
            f.Dispose()
        End If
    End Sub

    Private Sub DisposeMainForm()
        Dim mf As MainForm = TryCast(ScenarioForm("MainForm"), MainForm)
        If mf IsNot Nothing Then
            mf.Dispose()
        End If
    End Sub

    Private Sub Cleanup()
        Dim BF As BypassForm = TryCast(ScenarioForm("BypassForm"), BypassForm)
        Dim RF As RegisterForm = TryCast(ScenarioForm("RegisterForm"), RegisterForm)
        If BF IsNot Nothing Then
            BF.Dispose()
        End If
        If RF IsNot Nothing Then
            RF.Dispose()
        End If
        ScenarioForm.Clear()
    End Sub
#End Region

End Class
