Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports DevExpress.Xpf.Grid
Imports System.Windows.Data
Imports System.Windows.Media
Imports System.Windows.Markup

Namespace E2019
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = IssueList.GetData()
		End Sub
		Private Sub OnColumnsGenerated(ByVal sender As Object, ByVal e As RoutedEventArgs)
			For Each column As GridColumn In grid.Columns
				If column.FieldName = "IssueName" Then
					Dim cellTemplate As String = "" & ControlChars.CrLf & "        <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""" & ControlChars.CrLf & "                      xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""" & ControlChars.CrLf & "                      xmlns:dxe=""http://schemas.devexpress.com/winfx/2008/xaml/editors"">" & ControlChars.CrLf & "            <dxe:TextEdit x:Name=""PART_Editor"" Foreground=""Blue""/>" & ControlChars.CrLf & "        </DataTemplate>"
					column.CellTemplate = TryCast(XamlReader.Parse(cellTemplate), DataTemplate)
					column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending
				ElseIf column.FieldName = "IssueType" Then
					column.CellTemplate = TryCast(Application.Current.MainWindow.Resources("IssueTypeTemplate"), DataTemplate)
				ElseIf column.FieldName = "ID" Then
					column.Visible = False
				End If
			Next column
		End Sub
		Public Class IssueList
			Public Shared Function GetData() As List(Of IssueDataObject)
				Dim data As New List(Of IssueDataObject)()
				data.Add(New IssueDataObject() With {.ID = 0, .IssueName = "Transaction History", .IssueType = "Bug", .IsPrivate = True})
				data.Add(New IssueDataObject() With {.ID = 1, .IssueName = "Ledger: Inconsistency", .IssueType = "Bug", .IsPrivate = False})
				data.Add(New IssueDataObject() With {.ID = 2, .IssueName = "Data Import", .IssueType = "Request", .IsPrivate = False})
				data.Add(New IssueDataObject() With {.ID = 3, .IssueName = "Data Archiving", .IssueType = "Request", .IsPrivate = True})
				Return data
			End Function
		End Class
		Public Class IssueDataObject
			Private privateID As Integer
			Public Property ID() As Integer
				Get
					Return privateID
				End Get
				Set(ByVal value As Integer)
					privateID = value
				End Set
			End Property
			Private privateIssueName As String
			Public Property IssueName() As String
				Get
					Return privateIssueName
				End Get
				Set(ByVal value As String)
					privateIssueName = value
				End Set
			End Property
			Private privateIssueType As String
			Public Property IssueType() As String
				Get
					Return privateIssueType
				End Get
				Set(ByVal value As String)
					privateIssueType = value
				End Set
			End Property
			Private privateIsPrivate As Boolean
			Public Property IsPrivate() As Boolean
				Get
					Return privateIsPrivate
				End Get
				Set(ByVal value As Boolean)
					privateIsPrivate = value
				End Set
			End Property
		End Class
	End Class

	Public Class IssueTypeForegroundConverter
		Implements IValueConverter
		Public Function Convert(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.Convert
			If value Is Nothing Then
				Return Nothing
			End If

			Dim issueType As String = value.ToString()
			If issueType = "Bug" Then
				Return New SolidColorBrush(Colors.Red)
			End If

			Return New SolidColorBrush(Colors.Black)
		End Function

		Public Function ConvertBack(ByVal value As Object, ByVal targetType As System.Type, ByVal parameter As Object, ByVal culture As System.Globalization.CultureInfo) As Object Implements IValueConverter.ConvertBack
			Throw New System.NotImplementedException()
		End Function
	End Class

End Namespace
