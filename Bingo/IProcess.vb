Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Reflection

'! class untuk mangatur external application
'! berikut sudah ter pasang Hardwareid.exe, adb.exe, netsh.exe, dan taskkill
'! contoh penggunaan bisa di lihat di code dasboardform --> getHardware

'! structure pointer dari external process diantaranya error code, error mesage dan output message
Public Structure RESULT_PROCESS
    Public code As Integer
    Public output As String
    Public [Error] As String

End Structure

'! main clas dari process yang nantinya akan terpakai oleh anak class(inheritance method)
'! the process will not catch which not an error process e.g. file not found
Public Class IProcess
    Public Sub New(exe As String)
        Me._exe = exe
        result = New RESULT_PROCESS()
    End Sub

    '! get root directory dari main exe
    Private Function GetDirectory() As String
        Return Assembly.GetExecutingAssembly().Location.Replace("Bingo.exe", "")
    End Function

    '! overide method dengan parameter yang berbeda untuk parameter atau argument external applikasi
    Public Function exec(arg As String) As RESULT_PROCESS
        Return Me.exec(New String() {arg})
    End Function

    '!main method untuk exkusi external applikasi 
    Public Overridable Function exec(args As String()) As RESULT_PROCESS
        Dim ProcessInfo As New ProcessStartInfo
        ProcessInfo.CreateNoWindow = True
        ProcessInfo.UseShellExecute = False
        ProcessInfo.FileName = String.Join("", New String() {Me.GetDirectory(), Me._exe})
        ProcessInfo.Arguments = args.ToString
        ProcessInfo.RedirectStandardInput = True
        ProcessInfo.RedirectStandardError = True
        ProcessInfo.RedirectStandardOutput = True

        Using execute As System.Diagnostics.Process = System.Diagnostics.Process.Start(ProcessInfo)
            Try
                execute.EnableRaisingEvents = True
                AddHandler execute.OutputDataReceived, AddressOf execute_OutputDataReceived
                AddHandler execute.ErrorDataReceived, AddressOf execute_ErrorDataReceived
                AddHandler execute.Exited, AddressOf execute_Exited
                execute.Start()
                execute.BeginErrorReadLine()
                execute.BeginOutputReadLine()
            Finally
                execute.WaitForExit()
            End Try
            Return result
        End Using
    End Function
    Dim result As RESULT_PROCESS
    Private _exe As String

    Private Sub execute_OutputDataReceived(sender As Object, e As DataReceivedEventArgs)
        If Not e.Data Is Nothing Then
            result.output = e.Data
        End If
    End Sub

    Private Sub execute_ErrorDataReceived(sender As Object, e As DataReceivedEventArgs)
        If Not e.Data Is Nothing Then
            result.Error = e.Data
        End If
    End Sub

    Private Sub execute_Exited(sender As Object, e As EventArgs)
        result.code = 0
    End Sub

End Class

'! dibawah inheritance class dari iprocess
Public Class GetHardware
    Inherits IProcess
    Public Sub New()
        MyBase.New("HardwareId.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

'! class interface to ADB
Public Class ADBBridge
    Inherits IProcess
    Public Sub New()
        MyBase.New("adb.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

'! class interface taskkill.exe
Public Class KILLProcessWindows
    Inherits IProcess
    Public Sub New()
        MyBase.New("taskkill.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

'! class interface netsh
Public Class NETShell
    Inherits IProcess
    Public Sub New()
        MyBase.New("netsh.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

'! tambah kan kalau ada lagi
Public Class AndroidEMU
    Inherits IProcess
    Public Sub New()
        MyBase.New("AndroidEmulator.exe")
    End Sub
    Public Overrides Function exec(args As String()) As RESULT_PROCESS
        Return MyBase.exec(args)
    End Function
End Class

