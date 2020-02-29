Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms

Public Enum Level As Integer
	Critical = 0
	[Error] = 1
	Warning = 2
	Info = 3
	Verbose = 4
	Debug = 5
End Enum


Public Partial Class LoggerForm
	Inherits Form
	Private listBoxLog As ListBoxLog
	Public Sub New(parent As System.Windows.Forms.IWin32Window)
		InitializeComponent()
		listBoxLog = New ListBoxLog(listBox1)
		Me.MdiParent = TryCast(parent, DashboardForm)
	End Sub

	Public Sub SetLogged(l As Level, msg As String)
		listBoxLog.Log(l, msg)
	End Sub

End Class

Public NotInheritable Class ListBoxLog
	Implements IDisposable
	Private Const DEFAULT_MESSAGE_FORMAT As String = "{0} [{5}] : {8}"
	Private Const DEFAULT_MAX_LINES_IN_LISTBOX As Integer = 2000

	Private _disposed As Boolean
	Private _listBox As ListBox
	Private _messageFormat As String
	Private _maxEntriesInListBox As Integer
	Private _canAdd As Boolean
	Private _paused As Boolean

	Private Class LogEvent
		Public Sub New(level__1 As Level, message__2 As String)
			EventTime = DateTime.Now
			Level = level__1
			Message = message__2
		End Sub

		Public ReadOnly EventTime As DateTime

		Public ReadOnly Level As Level
		Public ReadOnly Message As String
	End Class

	Private Sub OnHandleCreated(sender As Object, e As EventArgs)
		_canAdd = True
	End Sub
	Private Sub OnHandleDestroyed(sender As Object, e As EventArgs)
		_canAdd = False
	End Sub
	Private Sub DrawItemHandler(sender As Object, e As DrawItemEventArgs)
		If e.Index >= 0 Then
			e.DrawBackground()
			e.DrawFocusRectangle()

			Dim logEvent As LogEvent = TryCast(DirectCast(sender, ListBox).Items(e.Index), LogEvent)

			' SafeGuard against wrong configuration of list box
			If logEvent Is Nothing Then
				logEvent = New LogEvent(Level.Critical, DirectCast(sender, ListBox).Items(e.Index).ToString())
			End If

			Dim color__1 As Color
			Select Case logEvent.Level
				Case Level.Critical
					color__1 = Color.White
					Exit Select
				Case Level.[Error]
					color__1 = Color.Red
					Exit Select
				Case Level.Warning
					color__1 = Color.Goldenrod
					Exit Select
				Case Level.Info
					color__1 = Color.Green
					Exit Select
				Case Level.Verbose
					color__1 = Color.Blue
					Exit Select
				Case Else
					color__1 = Color.Black
					Exit Select
			End Select

			If logEvent.Level = Level.Critical Then
				e.Graphics.FillRectangle(New SolidBrush(Color.Red), e.Bounds)
			End If
			e.Graphics.DrawString(FormatALogEventMessage(logEvent, _messageFormat), New Font("Lucida Console", 8.25F, FontStyle.Regular), New SolidBrush(color__1), e.Bounds)
		End If
	End Sub
	Private Sub KeyDownHandler(sender As Object, e As KeyEventArgs)
		If (e.Modifiers = Keys.Control) AndAlso (e.KeyCode = Keys.C) Then
			CopyToClipboard()
		End If
	End Sub
	Private Sub CopyMenuOnClickHandler(sender As Object, e As EventArgs)
		CopyToClipboard()
	End Sub
	Private Sub CopyMenuPopupHandler(sender As Object, e As EventArgs)
		Dim menu As ContextMenu = TryCast(sender, ContextMenu)
		If menu IsNot Nothing Then
			menu.MenuItems(0).Enabled = (_listBox.SelectedItems.Count > 0)
		End If
	End Sub
	Private Sub WriteEvent(logEvent As LogEvent)
		If (logEvent IsNot Nothing) AndAlso (_canAdd) Then
			_listBox.BeginInvoke(New AddALogEntryDelegate(AddressOf AddALogEntry), logEvent)
		End If
	End Sub
	Private Delegate Sub AddALogEntryDelegate(item As Object)
	Private Sub AddALogEntry(item As Object)
		_listBox.Items.Add(item)

		If _listBox.Items.Count > _maxEntriesInListBox Then
			_listBox.Items.RemoveAt(0)
		End If

		If Not _paused Then
			_listBox.TopIndex = _listBox.Items.Count - 1
		End If
	End Sub
	Private Function LevelName(level__1 As Level) As String
		Select Case level__1
			Case Level.Critical
				Return "Critical"
			Case Level.[Error]
				Return "Error"
			Case Level.Warning
				Return "Warning"
			Case Level.Info
				Return "Info"
			Case Level.Verbose
				Return "Verbose"
			Case Level.Debug
				Return "Debug"
			Case Else
				Return String.Format("<value={0}>", CInt(level__1))
		End Select
	End Function
	Private Function FormatALogEventMessage(logEvent As LogEvent, messageFormat As String) As String
		Dim message As String = logEvent.Message
		If message Is Nothing Then
			message = "<NULL>"
		End If
		' {0} 
		' {1} 
		' {2} 
		' {3} 
		' {4} 

		' {5} 
		' {6} 
		' {7} 

		' {8} 
		Return String.Format(messageFormat, logEvent.EventTime.ToString("yyyy-MM-dd HH:mm:ss.fff"), logEvent.EventTime.ToString("yyyy-MM-dd HH:mm:ss"), logEvent.EventTime.ToString("yyyy-MM-dd"), logEvent.EventTime.ToString("HH:mm:ss.fff"), logEvent.EventTime.ToString("HH:mm:ss"), _
			LevelName(logEvent.Level)(0), LevelName(logEvent.Level), CInt(logEvent.Level), message)
	End Function
	Private Sub CopyToClipboard()
		If _listBox.SelectedItems.Count > 0 Then
			Dim selectedItemsAsRTFText As New StringBuilder()
			selectedItemsAsRTFText.AppendLine("{\rtf1\ansi\deff0{\fonttbl{\f0\fcharset0 Courier;}}")
			selectedItemsAsRTFText.AppendLine("{\colortbl;\red255\green255\blue255;\red255\green0\blue0;\red218\green165\blue32;\red0\green128\blue0;\red0\green0\blue255;\red0\green0\blue0}")
			For Each logEvent As LogEvent In _listBox.SelectedItems
				selectedItemsAsRTFText.AppendFormat("{{\f0\fs16\chshdng0\chcbpat{0}\cb{0}\cf{1} ", If((logEvent.Level = Level.Critical), 2, 1), If((logEvent.Level = Level.Critical), 1, If((CInt(logEvent.Level) > 5), 6, CInt(logEvent.Level) + 1)))
				selectedItemsAsRTFText.Append(FormatALogEventMessage(logEvent, _messageFormat))
				selectedItemsAsRTFText.AppendLine("\par}")
			Next
			selectedItemsAsRTFText.AppendLine("}")
			System.Diagnostics.Debug.WriteLine(selectedItemsAsRTFText.ToString())
			Clipboard.SetData(DataFormats.Rtf, selectedItemsAsRTFText.ToString())
		End If

	End Sub
	Public Sub New(listBox As ListBox)
		Me.New(listBox, DEFAULT_MESSAGE_FORMAT, DEFAULT_MAX_LINES_IN_LISTBOX)
	End Sub
	Public Sub New(listBox As ListBox, messageFormat As String)
		Me.New(listBox, messageFormat, DEFAULT_MAX_LINES_IN_LISTBOX)
	End Sub

	Public Sub New(listBox As ListBox, messageFormat As String, maxLinesInListbox As Integer)
		_disposed = False

		_listBox = listBox
		_messageFormat = messageFormat
		_maxEntriesInListBox = maxLinesInListbox

		_paused = False

		_canAdd = listBox.IsHandleCreated

		_listBox.SelectionMode = SelectionMode.MultiExtended

		AddHandler _listBox.HandleCreated, AddressOf OnHandleCreated
		AddHandler _listBox.HandleDestroyed, AddressOf OnHandleDestroyed
		AddHandler _listBox.DrawItem, AddressOf DrawItemHandler
		AddHandler _listBox.KeyDown, AddressOf KeyDownHandler

		Dim menuItems As MenuItem() = New MenuItem() {New MenuItem("Copy", New EventHandler(AddressOf CopyMenuOnClickHandler))}
		_listBox.ContextMenu = New ContextMenu(menuItems)
		AddHandler _listBox.ContextMenu.Popup, New EventHandler(AddressOf CopyMenuPopupHandler)

		_listBox.DrawMode = DrawMode.OwnerDrawFixed
	End Sub
	Public Sub Log(message As String)
		Log(Level.Debug, message)
	End Sub
	Public Sub Log(format As String, ParamArray args As Object())
		Log(Level.Debug, If((format Is Nothing), Nothing, String.Format(format, args)))
	End Sub
	Public Sub Log(level As Level, format As String, ParamArray args As Object())
		Log(level, If((format Is Nothing), Nothing, String.Format(format, args)))
	End Sub
	Public Sub Log(level As Level, message As String)
		WriteEvent(New LogEvent(level, message))
	End Sub

	Public Property Paused() As Boolean
		Get
			Return _paused
		End Get
		Set
			_paused = value
		End Set
	End Property

	Protected Overrides Sub Finalize()
		Try
			If Not _disposed Then
				Dispose(False)
				_disposed = True
			End If
		Finally
			MyBase.Finalize()
		End Try
	End Sub
	Public Sub Dispose() Implements IDisposable.Dispose
		If Not _disposed Then
			Dispose(True)
			GC.SuppressFinalize(Me)
			_disposed = True
		End If
	End Sub
	Private Sub Dispose(disposing As Boolean)
		If _listBox IsNot Nothing Then
			_canAdd = False

			RemoveHandler _listBox.HandleCreated, AddressOf OnHandleCreated
			RemoveHandler _listBox.HandleCreated, AddressOf OnHandleDestroyed
			RemoveHandler _listBox.DrawItem, AddressOf DrawItemHandler
			RemoveHandler _listBox.KeyDown, AddressOf KeyDownHandler

			_listBox.ContextMenu.MenuItems.Clear()
			RemoveHandler _listBox.ContextMenu.Popup, AddressOf CopyMenuPopupHandler
			_listBox.ContextMenu = Nothing

			_listBox.Items.Clear()
			_listBox.DrawMode = DrawMode.Normal
			_listBox = Nothing
		End If
	End Sub

End Class
