Imports System.Collections.Generic
Imports System.Text
Imports System.Windows.Forms

Public Enum DialogStep
	LOGIN
	REGISTER
	BYPASS
End Enum

Public Class ManagementForm
	ReadOnly ScenarioForm As System.Collections.Hashtable

	Private dialogStep As DialogStep

	Private DialogLog As LoggerForm

	'! prepend to mainform
	Private museid As String
	'! get from main
	Private password As String

	Private ReadOnly _ownerDlg As System.Windows.Forms.IWin32Window


	Public Sub New(owner As System.Windows.Forms.IWin32Window)
		_ownerDlg = owner
		ScenarioForm = New System.Collections.Hashtable()

		SetupLoggerForm()
	End Sub

	Public Sub SetupLoggerForm()
		DialogLog = New LoggerForm(_ownerDlg)
		DialogLog.Dock = System.Windows.Forms.DockStyle.Bottom
		DialogLog.Show()
	End Sub

	Public Sub AppendLog(level As Level, msg As String)
		DialogLog.SetLogged(level, msg)
	End Sub

	Public Sub init()
		SetupMainForm()
		RunLoop("MainForm")
	End Sub

	Public Sub RunLoop(nform As String)
		dialogStep = Me.Loopings(nform)
	End Sub
	'! <<-----
	Private Function GetPreviousDialog(curForm As Form) As String
		Dim currentFormName As String = curForm.Name

		If currentFormName <> "MainForm" Then
			Return "MainForm"
		End If
		Return "MainForm"
	End Function
	'! ----->>
	Private Function GetNextDialog(curForm As Form, firstStep As DialogStep) As String
		Dim curFormName As String = curForm.Name

		If curFormName = "MainForm" AndAlso firstStep = DialogStep.BYPASS Then
			Return "BypassForm"
		End If
		If curFormName = "MainForm" AndAlso firstStep = DialogStep.REGISTER Then
			Return "RegisterForm"
		End If
		Return "MainForm"
	End Function
	'! <>--<>
	Private Function Loopings(firstForm As String) As DialogStep
		Dim nextstep As DialogStep = DialogStep.LOGIN
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
				Case DialogStep.REGISTER
					nextForm = Me.GetNextDialog(currentForm, nextstep)
					NextDialogHandler(nextForm, nextstep)
					currentForm.Dispose()
					currentForm = TryCast(Me.ScenarioForm(nextForm), Form)
					currentForm.Dock = DockStyle.Top
					currentForm.Show()
					StopLoop = False
					Exit Select
				Case DialogStep.BYPASS
					nextForm = Me.GetNextDialog(currentForm, nextstep)
					NextDialogHandler(nextForm, nextstep)
					currentForm.Dispose()
					currentForm = TryCast(Me.ScenarioForm(nextForm), Form)
					currentForm.Dock = DockStyle.Top
					currentForm.Show()
					StopLoop = False
					Exit Select
				Case DialogStep.LOGIN
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
	Private Sub NextDialogHandler(curForm As String, [step] As DialogStep)
		If curForm.Equals("BypassForm") AndAlso [step] = DialogStep.BYPASS Then
			SetupBypassForm()
		End If
		If curForm.Equals("RegisterForm") AndAlso [step] = DialogStep.REGISTER Then
			SetupRegisterForm()
		End If
		If curForm.Equals("MainForm") AndAlso [step] = DialogStep.LOGIN Then
			SetupMainForm()
		End If

	End Sub

	Private Sub PreviousDialogHandler(curForm As String)
		SetupMainForm()
	End Sub
	#Region "SetupForm"

	Private Sub SetupBypassForm()
		Me.DisposeBypassForm()
		Dim F As New BypassForm(_ownerDlg, Me)
		Dim mainForm As MainForm = TryCast(ScenarioForm("MainForm"), MainForm)
		Me.museid = mainForm.MuseId
		F.MuseId = Me.museid
		ScenarioForm.Remove("BypassForm")
		ScenarioForm.Add("BypassForm", F)
	End Sub

	Private Sub SetupRegisterForm()
        Me.DisposeRegisterForm()
        Dim passwordFrom As DashboardForm = TryCast(_ownerDlg, DashboardForm)

        Dim RF As New RegisterForm(_ownerDlg, Me)

        RF.Password = passwordFrom.GetHardwareId()

        ScenarioForm.Remove("RegisterForm")
        ScenarioForm.Add("RegisterForm", RF)

    End Sub


    Private Sub SetupMainForm()
        Me.DisposeMainForm()

        Dim mainForm As New MainForm(_ownerDlg, Me)

        mainForm.SetPassword = DirectCast(_ownerDlg, DashboardForm).GetHardwareId()
        ScenarioForm.Remove("MainForm")
        ScenarioForm.Add("MainForm", mainForm)
    End Sub

#End Region

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
