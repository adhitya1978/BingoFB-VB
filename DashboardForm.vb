Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports DMSoft


Public Interface IFORM
	ReadOnly Property StepResult() As DialogStep
End Interface

Public Partial Class DashboardForm
	Inherits Form
	Private managementForm As ManagementForm
	Public Sub New()
		InitializeComponent()
		managementForm = New ManagementForm(Me)
		managementForm.init()
		Dim skin As New DMSoft.SkinCrafter()
		skin.SkinFile = "RedJet"
		Using ms As New System.IO.MemoryStream(Properties.Resources.RedJet)
			skin.LoadSkinFromStream(ms)
			skin.ApplySkin()
			ms.Close()
		End Using
	End Sub

	Public Function GetHardwareId() As String
		Dim ret As String = String.Empty
		Try
            Dim Process As RESULT_PROCESS = New GetHardware().exec("")
			If Process.[error].Contains("error") Then
				Throw New Exception(Process.[error])
			End If
		Catch ex As Exception
			managementForm.AppendLog(Level.[Error], String.Format("what:{0}{1}", ex.StackTrace, ex.Message))
		End Try


		Using hardwareidtxt As System.IO.Stream = System.IO.File.Open("Hwid.txt", System.IO.FileMode.Open, System.IO.FileAccess.Read, System.IO.FileShare.Delete)
			Using read As New System.IO.StreamReader(hardwareidtxt)
				Try
					ret = read.ReadToEnd()
				Finally
					read.Close()
					hardwareidtxt.Close()
				End Try
			End Using
		End Using
		Return ret
	End Function
End Class
