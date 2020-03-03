
'! Class untuk communicate ADB.exe
'! dengan fungsi umum yang paling banyak di execute
Public Class GENERALADBCMD
    Private ip As String = "127.0.0.1"
    '! atau localhost
    Private port As String = "5555"
    '! default port emulator
    Private s As String = "s"
    Private shell As String = "shell"
    Private commentremount As String = "mount -o rw,remount"

    '! constructor
    Public Sub New()
        '! todo logic initialization here
        ' contoh jika process berikut sering melakukan kill-server
        ' function KillServer() tidak perlu di overridable tetapi di private dan initialize di dalam sini
        ' KillServer()
    End Sub

    Public Overridable Sub KiLLServer()
        Dim comment As String = "kill-server"
        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
    End Sub

    Public Overridable Function InitDevices() As String
        Dim comment As String = "devices"
        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
        '! return empty jika tidak ada device yang terdetect
        Return InlineAssignHelper(PointerProcess.output, If(String.IsNullOrEmpty(PointerProcess.output), PointerProcess.output, String.Empty))
    End Function

    Public Overridable Function ConnectDevice() As String
        Dim commentconnect As String = "connect"

        Dim comment As String() = {commentconnect, String.Format("{0}:{1}", ip, port)}
        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
        '! return connected
        Return InlineAssignHelper(PointerProcess.output, If(String.IsNullOrEmpty(PointerProcess.output), PointerProcess.output, String.Empty))
    End Function

    '! path contoh data/data or system or data
    '! no return 
    Public Overridable Sub Remount(path As String)
        Dim comment As String() = {s, String.Format("{0}:{1}", ip, port), shell, commentremount, String.Format("/{0}", path)}

        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
    End Sub
    '! rename file dengan parameter oldfile dan newfile
    '! rename init.vbox86.rc init.vbox86.txt
    Public Overridable Sub Rename(oldfile As String, newfile As String)
        Dim comment As String() = {s, String.Format("{0}:{1}", ip, port), shell, "mv", String.Format("/{0}", oldfile), String.Format("/{0}", newfile)}

        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
    End Sub
    '! remove file
    '! data/data/simplehat.clicker
    Public Overridable Sub Remove(fileremove As String, timeout As Integer)
        Dim comment As String() = {s, String.Format("{0}:{1}", ip, port), shell, "rm", "-rf", String.Format("/{0}", fileremove), _
            String.Format("timeout {0}", timeout)}

        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
    End Sub

    Public Overridable Sub Lancher(gamepath As String)
        Dim commentlancher As String = "android.intent.category.LAUNCHER 1"
        Dim comment As String() = {s, String.Format("{0}:{1}", ip, port), shell, "monkey", "-p", String.Format("{0}", gamepath), _
            "-c", commentlancher}

        Dim PointerProcess As RESULT_PROCESS = New ADBBridge().exec(comment)
        '! jika error code bukan 0 berarti error dan error nya adaalah 
        If PointerProcess.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", PointerProcess.code, PointerProcess.[error]))
        End If
    End Sub

    Private Shared Function InlineAssignHelper(Of T)(ByRef target As T, value As T) As T
        target = value
        Return value
    End Function
End Class

'! jika ada tambahan fungsi bisa di tambahkan(overide di class berikut)

Public Class [Global]
    Inherits GENERALADBCMD
    Public Overrides Sub KiLLServer()
        MyBase.KiLLServer()
    End Sub

    Public Overrides Function InitDevices() As String
        Return MyBase.InitDevices()
    End Function

    Public Overrides Function ConnectDevice() As String
        Return MyBase.ConnectDevice()
    End Function

    Public Overrides Sub Remount(path As String)
        MyBase.Remount(path)
    End Sub

    Public Overrides Sub Remove(fileremove As String, timeout As Integer)
        '! default time in second 0
        Dim time As Integer = If(timeout = 0, 0, timeout)
        MyBase.Remove(fileremove, time)
    End Sub

    Public Overrides Sub Rename(oldfile As String, newfile As String)
        MyBase.Rename(oldfile, newfile)
    End Sub

    Public Overrides Sub Lancher(path As String)
        MyBase.Lancher(path)
    End Sub
End Class

'! membuat class baru jika ada comment yang berbeda 
Public Class Korea
    Inherits GENERALADBCMD
    Public Overrides Function ConnectDevice() As String
        Return MyBase.ConnectDevice()
    End Function

    Public Overrides Function InitDevices() As String
        Return MyBase.InitDevices()
    End Function

    Public Overrides Sub KiLLServer()
        MyBase.KiLLServer()
    End Sub
    Public Overrides Sub Lancher(gamepath As String)
        MyBase.Lancher(gamepath)
    End Sub
    Public Overrides Sub Remount(path As String)
        MyBase.Remount(path)
    End Sub
    Public Overrides Sub Remove(fileremove As String, timeout As Integer)
        MyBase.Remove(fileremove, timeout)
    End Sub
    Public Overrides Sub Rename(oldfile As String, newfile As String)
        MyBase.Rename(oldfile, newfile)
    End Sub
End Class

Public Class BLOCKPortFirewall
    Private Enum ACTION
        BLOCK
        ALLOW
    End Enum
    Private Enum DIRECTION
        [IN]
        OUT
    End Enum
    Private Enum PROTOCOL
        TCP
        UDP
    End Enum

    Private applications As String() = {"AndroidEmulator.exe", "aow_exe.exe"}

    Private rangeport As String = "10000-125000"

    Private command As String = "advfirewall firewall add rule name=trojan"

    Public Sub Execute(drive As String)
        Dim process As RESULT_PROCESS = New NETShell().exec(command)
        If process.[error] IsNot Nothing Then
            Throw New Exception(String.Format("Blocking firewall failed. {0} - code {1}", process.code, process.[error]))
        End If
    End Sub
End Class

'! a class for detect current operating system and get system drives of installation os
'! a proces must be in thread and support for most windows vista and above
Public NotInheritable Class Util
    Private Sub New()
    End Sub
    '! operating system installaed
    Shared installedOS As System.OperatingSystem = System.Environment.OSVersion
    '! system directory
    Shared osSystemDirectory As String = System.Environment.SystemDirectory
    '! active domain name
    Shared osDomainName As String = System.Environment.UserDomainName
    '! platform operating system
    Shared is64Bit As Boolean = System.Environment.Is64BitOperatingSystem
    '! directory Program Files
    Shared osProgramFiles As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles, Environment.SpecialFolderOption.None)
    '! directory Program Filesx86
    Shared osProgramFilesX86 As String = System.Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86, Environment.SpecialFolderOption.None)
    '! list of partition
    Shared osPartitons As String() = System.Environment.GetLogicalDrives()
    '! build version operating system
    Shared osVersion As System.Version = System.Environment.Version


    Public Shared ReadOnly Property GetSystemDirectory() As String
        Get
            If installedOS.Platform <> PlatformID.Win32NT Then
                Throw New Exception(String.Format("OS Platform {0}. Not Supported", installedOS.Platform))
            End If
            Return osSystemDirectory
        End Get
    End Property

    Public Shared ReadOnly Property Partitions() As String()
        Get
            Return osPartitons
        End Get
    End Property

    Public Shared ReadOnly Property GetProgramFilesDirectory() As String
        Get
            ' if os 64bit and apps is 86bit
            If is64Bit Then
                Return osProgramFilesX86
            End If
            '! default is program files
            Return osProgramFiles
        End Get
    End Property

    Public Shared Function ExecutableDirectory() As String
        Return System.Reflection.Assembly.GetExecutingAssembly().Location.Replace("Bingo.exe", "")
    End Function

End Class

'! class untuk membersihkan applikasi yang telah running
Public Class WINDOWProcess
    Private windowProcess As String()

    Public Sub New()
        Me.GetProcess()
    End Sub
    Private Sub GetProcess()
        Dim Process As RESULT_PROCESS = New GetHardware().exec("-c")
        If Process.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", Process.code, Process.[error]))
        End If
        windowProcess = Process.output.Split(" "c)
    End Sub

    Private Function Kill(processname As String) As Boolean
        Dim ret As Boolean = False
        Dim arg As String() = {"/F", "/IM", processname, "/T"}

        Dim Process As RESULT_PROCESS = New KILLProcessWindows().exec(arg)
        If Process.code <> 0 Then
            Throw New Exception(String.Format("error code:{0} - message {1} ", Process.code, Process.[error]))
        End If
        If Process.output.Contains("SUCCESS") Then
            ret = True
        End If
        Return ret
    End Function

    Public Sub CleanUp()
        Dim runkill As Boolean = True
        While runkill
            For Each process As String In windowProcess
                If process.Contains("AndroidEmulator") Then
                    runkill = Kill(process)
                End If
                If process.Contains("aow_exe") Then
                    runkill = Kill(process)
                End If
                If process.Contains("adb") Then
                    runkill = Kill(process)
                End If
                If process.Contains("bfb") Then
                    runkill = Kill(process)
                End If
            Next
            If runkill Then
                runkill = False
            End If
        End While

    End Sub
End Class

'! class untuk extract zip file
Public NotInheritable Class Uncompress
    Private Sub New()
    End Sub
    ' 4K is optimum
    Shared buffer As Byte() = New Byte(4095) {}

    Public Shared Sub UnCompressZipFile(source As System.IO.Stream)
        Dim zipFile As New ICSharpCode.SharpZipLib.Zip.ZipFile(source)
        Try
            For Each entry As ICSharpCode.SharpZipLib.Zip.ZipEntry In zipFile
                If Not entry.IsFile Then
                    Continue For
                End If

                If entry.IsCrypted Then
                    Throw New Exception(String.Format("UnCompressZipFile. {0} ", "Compress file encrypted."))
                End If

                Dim filetobecreate As String = System.IO.Path.Combine(Util.ExecutableDirectory(), entry.Name)

                Using data As System.IO.Stream = zipFile.GetInputStream(entry)
                    Using write As System.IO.Stream = System.IO.File.Open(filetobecreate, System.IO.FileMode.Create, System.IO.FileAccess.Write, System.IO.FileShare.None)
                        Try
                            ICSharpCode.SharpZipLib.Core.StreamUtils.Copy(data, write, buffer)
                        Finally
                            write.Close()
                            data.Close()

                        End Try

                    End Using
                End Using
            Next
        Finally
            zipFile.IsStreamOwner = True
            zipFile.Close()
        End Try
    End Sub
End Class
