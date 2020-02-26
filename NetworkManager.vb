Imports System.Collections.Generic
Imports System.Text


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
End Enum

Public Structure ParameterUrl
	Public url As String
	Public musename As String
	Public password As String
	Public mode As PHP_MODE
	Public timeout As Integer
	Public method As Method
End Structure

Public Structure RESPONSE_FEEDBACK
	Public message As String
	Public details As String()
	Public status As Boolean
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
End Class

Class RequestManager
	Private networkAccesManager As System.Net.HttpWebRequest

	Private webReply As System.Net.HttpWebResponse
	Private parameterUrl As ParameterUrl

	Private KeepAlive As Boolean = False
	Private requestAborted As Boolean = False

	Private Event finished As Connect
	Private Event readyRead As Connect

	Private responsemanager As ResponseManager


	Public Sub New(paramurl As ParameterUrl)
		parameterUrl = paramurl
		'! Slot
		AddHandler Me.finished, New Connect(AddressOf Finished)
		AddHandler Me.readyRead, New Connect(AddressOf ReadyRead)
		CreateRequest()
	End Sub

	Private Sub CreateRequest()

		'System.Net.ServicePointManager.SecurityProtocol = (System.Net.SecurityProtocolType)3072;

		networkAccesManager = DirectCast(System.Net.HttpWebRequest.Create(New Uri(parameterUrl.url)), System.Net.HttpWebRequest)

		Dim Query As String = String.Empty
		Dim buffer As Byte() = New Byte(511) {}

		If parameterUrl.mode = PHP_MODE.LOGIN Then
			Query = "user=" & parameterUrl.musename & "&password=" & parameterUrl.password
			buffer = Encoding.ASCII.GetBytes(Query)
		End If
		If parameterUrl.mode = PHP_MODE.LOGOUT Then
			Query = "user=" & parameterUrl.musename
			buffer = Encoding.ASCII.GetBytes(Query)
		End If

		networkAccesManager.KeepAlive = Me.KeepAlive
		networkAccesManager.Timeout = parameterUrl.timeout
		networkAccesManager.Method = [Enum].GetName(GetType(Method), If(CInt(parameterUrl.method) <> -1, Method.POST, Method.[GET]))
		networkAccesManager.ContentType = "application/x-www-form-urlencoded"
		networkAccesManager.ContentLength = buffer.Length
		networkAccesManager.GetRequestStream().Write(buffer, 0, buffer.Length)
		networkAccesManager.GetRequestStream().Close()

		webReply = DirectCast(networkAccesManager.GetResponse(), System.Net.HttpWebResponse)
		RaiseEvent finished()
		RaiseEvent readyRead()

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


		If parameterUrl.mode = PHP_MODE.LOGIN OrElse parameterUrl.mode = PHP_MODE.LOGOUT Then
			responsemanager = New ResponseManager(UTF8)
				'! todo write etc host bokep
		ElseIf parameterUrl.mode = PHP_MODE.OURCLOUD Then
				'! todo response from pastebin
		Else
		End If

	End Sub

	Public WriteOnly Property Aborted() As Boolean
		Set
			requestAborted = True
		End Set
	End Property

	Public ReadOnly Property Status() As RESPONSE_FEEDBACK
		Get
			Return responsemanager.Response
		End Get
	End Property
End Class

Class ResponseManager

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
				m_response.details = If(JSONBuffer.Value.Length >= 0, JSONBuffer.Value.Split(","C), New String() {})
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
	Public ReadOnly Property Response() As RESPONSE_FEEDBACK
		Get
			Return Me.m_response
		End Get
	End Property

End Class

