Imports System.Collections.Generic
Imports System.Text
Imports System.Net.Mail


'! signal

Public Enum Method
    POST = 0
    [GET] = 1
End Enum

Public Enum PHP_MODE
    LOGIN = 0
    LOGOUT = 1
    PASTEBIN = 2
    OURCLOUD = 3
    REGISTER = 4
    UPDATE

End Enum

Public Enum RESPONSE_TYPE
    JSON
    PASTEBIN
    GDRIVE
    MEGADRIVE
End Enum


Public Interface TYPE
    ReadOnly Property type() As RESPONSE_TYPE

    ReadOnly Property Response() As RESPONSE_FEEDBACK
End Interface

Public Structure ParameterUrl
    Public url As String
    Public musename As String
    Public password As String
    Public mode As PHP_MODE
    Public timeout As Integer
    Public method As Method
    Public museid As String
End Structure

Public Structure RESPONSE_FEEDBACK
    Public message As String
    Public details As String()
    Public status As Boolean
End Structure

Public Structure Parameter_Email
    Public display_name As String
    '! isi body email
    Public msg_body As String
    '! subject email
    Public msg_subject As String
    '! penerima email or alamat email
    Public receive_address As String
    '! pengirim
    Public sender_address As String

    '! put here for user name and password
    Public username As String
    Public password As String
End Structure

Public Delegate Sub Connect()

Public Class NetworkManager

    Public Sub New()
    End Sub

    Protected Overrides Sub Finalize()
        Try
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Public Function Connect(paramurl As ParameterUrl) As RESPONSE_FEEDBACK
        Return New RequestManager(paramurl).Status
    End Function
    Public Sub Email(context_email As Parameter_Email)
        Dim SMTP As New SMTPEmail(context_email)
    End Sub
End Class

Class RequestManager
    Private networkAccesManager As System.Net.HttpWebRequest

    Private webReply As System.Net.HttpWebResponse
    Private parameterUrl As ParameterUrl

    Private KeepAlive As Boolean = False
    Private requestAborted As Boolean = False

    Private responsemanager As TYPE


    Public Sub New(paramurl As ParameterUrl)
        parameterUrl = paramurl
        CreateRequest()
    End Sub


    Private Sub CreateRequest()

        'System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;

        networkAccesManager = DirectCast(System.Net.HttpWebRequest.Create(New Uri(parameterUrl.url)), System.Net.HttpWebRequest)

        Dim Query As String = String.Empty
        Dim buffer As Byte() = New Byte(511) {}

        Dim method__1 As String = [Enum].GetName(GetType(Method), If(CInt(parameterUrl.method) <> -1, Method.POST, Method.[GET]))

        networkAccesManager.KeepAlive = Me.KeepAlive
        networkAccesManager.Timeout = parameterUrl.timeout
        networkAccesManager.Method = method__1
        networkAccesManager.ContentType = "application/x-www-form-urlencoded"

        If method__1 = "POST" Then

            If parameterUrl.mode = PHP_MODE.LOGIN Then
                Query = "user=" & parameterUrl.musename & "&password=" & parameterUrl.password
                buffer = Encoding.ASCII.GetBytes(Query)
            End If
            If parameterUrl.mode = PHP_MODE.LOGOUT Then
                Query = "user=" & parameterUrl.musename
                buffer = Encoding.ASCII.GetBytes(Query)
            End If
            If (Me.parameterUrl.mode = PHP_MODE.REGISTER) Then
                Query = String.Concat(New String() {"user=", Me.parameterUrl.musename, "&id=", Me.parameterUrl.museid, "&password=", Me.parameterUrl.password})
                buffer = Encoding.ASCII.GetBytes(Query)
            End If

            networkAccesManager.ContentLength = buffer.Length
            networkAccesManager.GetRequestStream().Write(buffer, 0, buffer.Length)
            networkAccesManager.GetRequestStream().Close()
        End If

        webReply = DirectCast(networkAccesManager.GetResponse(), System.Net.HttpWebResponse)
        Me.Finished()
        Me.ReadyRead()

    End Sub

    Private Sub Finished()
        If requestAborted Then
            webReply.GetResponseStream().Flush()
            webReply.GetResponseStream().Close()
            webReply.Close()
            Throw New Exception(String.Format("NetworkManager slot Finished. {0}", "aborted."))
        End If

        If webReply.StatusCode <> System.Net.HttpStatusCode.OK Then
            webReply.GetResponseStream().Flush()
            webReply.GetResponseStream().Close()
            webReply.Close()
            Throw New Exception(String.Format("NetworkManager slot Finished. code: {0} whats: {1}", webReply.StatusCode, webReply.StatusDescription))
        End If
        If webReply.IsFromCache Then
            Me.CreateRequest()
            Return
        End If
    End Sub

    Private Sub ReadyRead()
        Dim UTF8 As Byte() = New Byte(-1) {}
        Dim response As System.IO.Stream = webReply.GetResponseStream()

        Using readbuffer As New System.IO.StreamReader(response)
            Try
                Dim pagecontent As String = readbuffer.ReadToEnd().Trim()
                UTF8 = New Byte(pagecontent.Length - 1) {}
                UTF8 = Encoding.UTF8.GetBytes(pagecontent)
            Finally
                readbuffer.Close()
            End Try
        End Using


        If parameterUrl.mode = PHP_MODE.LOGIN OrElse parameterUrl.mode = PHP_MODE.LOGOUT OrElse parameterUrl.mode = PHP_MODE.REGISTER Then
            responsemanager = New JSONResponse(UTF8)
        ElseIf parameterUrl.mode = PHP_MODE.OURCLOUD Then
            '! todo write etc host bokep

        ElseIf parameterUrl.mode = PHP_MODE.UPDATE Then
            '! todo response from MEGADrive
            responsemanager = New MEGAResponse(UTF8)
        Else
            '! todo response from pastebin
            responsemanager = New STDResponse(UTF8)
        End If

    End Sub

    Public WriteOnly Property Aborted() As Boolean
        Set(value As Boolean)
            requestAborted = True
        End Set
    End Property

    Public ReadOnly Property Status() As RESPONSE_FEEDBACK
        Get
            Return responsemanager.Response
        End Get
    End Property
End Class

Class JSONResponse
    Implements TYPE
    Private JSONByte As Byte()
    '! response from PHP

    Private m_response As RESPONSE_FEEDBACK


    Public Sub New(input As Byte())
        JSONByte = input
        m_response = New RESPONSE_FEEDBACK()
        Me.Load()
    End Sub

    Protected Overrides Sub Finalize()
        Try
            m_response.details = New String() {}
            m_response.message = String.Empty
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Private Sub Load()
        Using jsonreader As System.Xml.XmlDictionaryReader = System.Runtime.Serialization.Json.JsonReaderWriterFactory.CreateJsonReader(Me.JSONByte, New System.Xml.XmlDictionaryReaderQuotas())
            Try
                If jsonreader Is Nothing Then
                    Throw New Exception(String.Format("JsonUtil.Load(). {0}", "failed to load"))
                End If
                ReadyRead(jsonreader)
            Finally
                jsonreader.Close()

            End Try
        End Using
    End Sub

    '! noted the response must be jsonformat {"key":"value"}
    Private Sub ReadyRead(JSONBuffer As System.Xml.XmlReader)
        JSONBuffer.MoveToContent()

        While JSONBuffer.Read()
            If JSONBuffer.IsStartElement("details") Then
                JSONBuffer.Read()
                m_response.details = If(JSONBuffer.Value.Length >= 0, JSONBuffer.Value.Split(","c), New String() {})
            End If
            If JSONBuffer.IsStartElement("success") Then
                JSONBuffer.Read()
                Boolean.TryParse(JSONBuffer.Value.Trim(), m_response.status)
            End If
            If JSONBuffer.IsStartElement("message") Then
                JSONBuffer.Read()
                m_response.message = JSONBuffer.Value.Trim()

            End If
        End While
    End Sub
    Public ReadOnly Property Response() As RESPONSE_FEEDBACK Implements type.Response
        Get
            Return Me.m_response
        End Get
    End Property
    Public ReadOnly Property type() As RESPONSE_TYPE Implements type.type
        Get
            Return RESPONSE_TYPE.PASTEBIN
        End Get
    End Property
End Class

'! below class for overwrite host on etc without know the platform, assume all operating system having same directory
'! not save thread
Class STDResponse
    Implements TYPE
    Private buffer As Byte()
    Private m_response As RESPONSE_FEEDBACK

    Public Sub New(input As Byte())
        buffer = input
        m_response = New RESPONSE_FEEDBACK()
        Me.load()
        '! emulate response
        m_response.details = New String() {}
    End Sub

    Protected Overrides Sub Finalize()
        Try
            m_response.details = New String() {}
            m_response.message = String.Empty
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Private Sub load()
        Dim context As String = String.Empty
        Using stream As System.IO.Stream = New System.IO.MemoryStream(Me.buffer)
            Try
                If stream.Length < 0 Then
                    Throw New Exception(String.Format("STDResponse.Load(). {0}", "failed to load"))
                End If
                Using TRead As New System.IO.StreamReader(stream)
                    Try
                        context = TRead.ReadToEnd()
                        If String.IsNullOrEmpty(context) Then
                            Throw New Exception(String.Format("STDResponse.Load(). {0}", "data pastebin nulled."))
                        End If
                    Finally
                        TRead.Close()
                        ReadyWrite(context)
                    End Try

                End Using
            Finally
                stream.Close()
            End Try
        End Using
    End Sub
    '! no need catch anything here  
    Private Sub ReadyWrite(data As String)
        '! assumed an input is text cause from pastebin
        Dim command As String() = {"-n", data}
        Dim result As RESULT_PROCESS = New GetHardware().exec(command)
        If result.code <> 0 Then
            Throw New Exception(String.Format("STDResponse.ReadyWrite(). {0}", "write etc host failed"))
        End If
        m_response.message = data
        m_response.status = True
    End Sub

    Public ReadOnly Property Response() As RESPONSE_FEEDBACK Implements type.Response
        Get
            Return Me.m_response
        End Get
    End Property

    Public ReadOnly Property type() As RESPONSE_TYPE Implements type.type
        Get
            Return RESPONSE_TYPE.PASTEBIN
        End Get
    End Property
End Class

Class MEGAResponse
    Implements TYPE
    Private buffer As Byte()

    Private m_response As RESPONSE_FEEDBACK

    Public Sub New(input As Byte())
        buffer = input
        m_response = New RESPONSE_FEEDBACK()
        Me.load()
        '! emulate response
        m_response.details = New String() {}
    End Sub

    Private Sub load()
        Dim context As Byte() = New Byte() {}
        Using stream As System.IO.Stream = New System.IO.MemoryStream(Me.buffer)
            Try
                If stream.Length < 0 Then
                    Throw New Exception(String.Format("MEGAResponse.Load(). {0}", "failed to load."))
                End If
                ReadyWrite(stream)
            Finally
                stream.Close()
            End Try
        End Using
    End Sub
    '! no need catch anything here  
    Private Sub ReadyWrite(data As System.IO.Stream)
        Uncompress.UnCompressZipFile(data)
        '! clean up
        Dim winProcess As New WINDOWProcess
        winProcess.CleanUp()

        m_response.message = "none"
        m_response.status = True
    End Sub


    Public ReadOnly Property type() As RESPONSE_TYPE Implements TYPE.type
        Get
            Return RESPONSE_TYPE.MEGADRIVE
        End Get
    End Property

    Public ReadOnly Property Response() As RESPONSE_FEEDBACK Implements TYPE.Response
        Get
            Return Me.m_response
        End Get
    End Property
End Class


Class SMTPEmail
    '*
    '         * After sign into google account, go to:https://www.google.com/settings/security/lesssecureapps
    '         * 
    '         * send email with anonymous device
    '         * 
    '         * **

    Private port As Integer = 587
    '! smtp port
    Private host As String = "smtp.gmail.com"
    '! receipent
    Private context As Parameter_Email

    Public Sub New(context_email As Parameter_Email)
        context = context_email
        Sending()
    End Sub
    Protected Overrides Sub Finalize()
        Try
        Finally
            MyBase.Finalize()
        End Try
    End Sub

    Private Sub Sending()
        '! construct pengirim
        Dim pengirim As System.Net.Mail.MailAddress = New MailAddress(context.sender_address, context.display_name)
        '! construct penerima
        Dim penerima As System.Net.Mail.MailAddress = New MailAddress(context.receive_address)
        '! construct credential or email username and password
        Dim indetitas As New System.Net.NetworkCredential(context.username, context.password)

        Using smtpClient As System.Net.Mail.SmtpClient = New SmtpClient(host, port)
            '! always via networks
            smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network
            '! be aware for port
            smtpClient.EnableSsl = True

            smtpClient.Credentials = indetitas
            AddHandler smtpClient.SendCompleted, AddressOf smtpClient_SendCompleted
            Using newmsg As System.Net.Mail.MailMessage = New MailMessage(pengirim, penerima)
                newmsg.Subject = context.msg_subject
                newmsg.Body = context.msg_body
                newmsg.Priority = MailPriority.Normal
                newmsg.BodyEncoding = UTF8Encoding.UTF8
                Try
                    smtpClient.Send(newmsg)
                Finally
                    '! dispose or release or buang activity email
                    newmsg.Dispose()
                    smtpClient.Dispose()
                End Try
            End Using
        End Using

    End Sub
    '! callback or response untuk menangkap error
    Private Sub smtpClient_SendCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs)
        If String.IsNullOrEmpty(e.[Error].Message) Then
            Throw New Exception(String.Format("Send email error. {0}-{1}", e.[Error].StackTrace, e.[Error].Message))
        End If
    End Sub
End Class
