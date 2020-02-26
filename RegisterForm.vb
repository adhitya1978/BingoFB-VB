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
		actionTaken = DialogStep.LOGIN
		managementForm.RunLoop("RegisterForm")
	End Sub

	Public ReadOnly Property StepResult() As DialogStep Implements IFORM.StepResult
		Get
			Return Me.actionTaken
		End Get
	End Property
End Class
