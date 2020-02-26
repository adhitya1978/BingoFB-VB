Imports System.Collections.Generic

Public Structure RESULT_PROCESS
	Public code As Integer
	Public [error] As String
	Public output As String
End Structure

Public Class IProcess
	Private _exe As String

	Public Sub New(exe As String)

		_exe = exe
	End Sub
	Public Function exec(arg As String) As RESULT_PROCESS
		Return exec(New String() {arg})
	End Function
	Public Overridable Function exec(args As String()) As RESULT_PROCESS
		Dim Result As New RESULT_PROCESS()
		Dim startInfo As New System.Diagnostics.ProcessStartInfo()
		startInfo.CreateNoWindow = True
		startInfo.UseShellExecute = False
		startInfo.FileName = _exe
		startInfo.Arguments = args.ToString()
		startInfo.RedirectStandardError = True

		Using execute As System.Diagnostics.Process = System.Diagnostics.Process.Start(startInfo)
			Try
				execute.WaitForExit(3000)
				Result.code = execute.ExitCode
				Result.[error] = If(execute.StandardError.ReadToEnd().Length > 0, execute.StandardError.ReadToEnd(), String.Empty)
				Result.output = If(execute.StandardOutput.ReadToEnd().Length > 0, execute.StandardOutput.ReadToEnd(), String.Empty)
			Finally
				execute.Kill()
				execute.Close()
			End Try
			Return Result
		End Using
	End Function
End Class

Public Class GetHardware
	Implements IProcess
	Public Sub New()
		MyBase.New("HardwareId.exe")
	End Sub
	Public Overrides Function exec(args As String()) As RESULT_PROCESS
		Return MyBase.exec(args)
	End Function
End Class

Public Class ADBBridge
	Implements IProcess
	Public Sub New()
		MyBase.New("adb.exe")
	End Sub
	Public Overrides Function exec(args As String()) As RESULT_PROCESS
		Return MyBase.exec(args)
	End Function
End Class

Public Class KILLProcessWindows
	Implements IProcess
	Public Sub New()
		MyBase.New("taskkill.exe")
	End Sub
	Public Overrides Function exec(args As String()) As RESULT_PROCESS
		Return MyBase.exec(args)
	End Function
End Class

Public Class NETShell
	Implements IProcess
	Public Sub New()
		MyBase.New("netsh.exe")
	End Sub
	Public Overrides Function exec(args As String()) As RESULT_PROCESS
		Return MyBase.exec(args)
	End Function
End Class

