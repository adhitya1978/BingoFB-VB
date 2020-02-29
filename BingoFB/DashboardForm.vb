
Public Interface IFORM
    ReadOnly Property StepResult() As DialogStep
End Interface

Public Class DashboardForm
    Inherits Form
    Private managementForm As ManagementForm
    Private password As String


    Public ReadOnly Property GetPassword() As String
        Get
            Return Me.password
        End Get
    End Property

    Public Sub New()
        InitializeComponent()
        managementForm = New ManagementForm(Me)
        Me.GetHardwareId()
        managementForm.init()
    End Sub


    Private Sub GetHardwareId()
		Try
            Dim Process As RESULT_PROCESS = New GetHardware().exec("")
            If Process.code <> 0 Then
                Throw New Exception(Process.[Error])
            End If
            password = Process.output
        Catch ex As Exception
            managementForm.AppendLog(Level.[Error], String.Format("what:{0}{1}", ex.StackTrace, ex.Message))
        End Try
    End Sub
End Class

