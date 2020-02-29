
'! Class untuk communicate ADB.exe
'! dengan fungsi umum yang paling banyak di execute
Public Class ADBCOMMENT
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
    Inherits ADBCOMMENT
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
    Inherits ADBCOMMENT
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