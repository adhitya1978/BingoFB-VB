Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Reflection

Public Structure RESULT_PROCESS
    Public code As Integer
    Public [error] As String
    Public output As String
End Structure

Public Class IProcess
    Public Sub New(exe As String)
        Me._exe = exe
    End Sub

    Private Function GetDirectory() As String
        Return Assembly.GetExecutingAssembly().Location.Replace("BingoFB.exe", "")
    End Function

    Public Function exec(arg As String) As RESULT_PROCESS
        Return Me.exec(New String() {arg})
    End Function

    Public Overridable Function exec(args As String()) As RESULT_PROCESS
        Dim Result As RESULT_PROCESS = Nothing
        Using execute As Process = Process.Start(New ProcessStartInfo() With {.CreateNoWindow = True, .UseShellExecute = False, .FileName = String.Join("", New String() {Me.GetDirectory(), Me._exe}), .Arguments = If((args.ToString().Length <> -1), args.ToString(), String.Empty), .RedirectStandardError = True, .RedirectStandardOutput = True})
            Try
                execute.Start()
            Finally
                execute.WaitForExit(3000)
                execute.Kill()
                execute.Close()
                Result.code = execute.ExitCode
                Result.[error] = If((execute.StandardError.ReadToEnd().Length > 0), execute.StandardError.ReadToEnd(), String.Empty)
                Result.output = If((execute.StandardOutput.ReadToEnd().Length > 0), execute.StandardOutput.ReadToEnd(), String.Empty)
            End Try
        End Using
        Return Result
    End Function

    Private _exe As String
End Class

Public Class GetHardware
    Inherits IProcess
    Public Sub New()
        MyBase.New("HardwareId.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

Public Class ADBBridge
    Inherits IProcess
    Public Sub New()
        MyBase.New("adb.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

Public Class KILLProcessWindows
    Inherits IProcess
    Public Sub New()
        MyBase.New("taskkill.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

Public Class NETShell
    Inherits IProcess
    Public Sub New()
        MyBase.New("netsh.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

