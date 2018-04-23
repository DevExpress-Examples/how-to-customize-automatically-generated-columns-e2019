Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows
Imports System.Windows.Documents
Imports DevExpress.Xpf.Grid

Namespace DXGrid_ColumnsPopulatedEvent
	Partial Public Class Window1
		Inherits Window
		Public Sub New()
			InitializeComponent()
			grid.ItemsSource = IssueList.GetData()
		End Sub
		Private Sub grid_ColumnsPopulated(ByVal sender As Object, ByVal e As RoutedEventArgs)
			For Each column As GridColumn In grid.Columns
				If column.FieldName = "ID" Then
					column.Visible = False
				End If
			Next column
			tableView1.VisibleColumns(0).SortOrder = DevExpress.Data.ColumnSortOrder.Descending
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
End Namespace
