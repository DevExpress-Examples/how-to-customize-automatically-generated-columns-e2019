using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using DevExpress.Wpf.Grid;

namespace DXGrid_ColumnsPopulatedEvent {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.DataSource = IssueList.GetData();
        }
        private void grid_ColumnsPopulated(object sender, RoutedEventArgs e) {
            foreach (GridColumn column in grid.Columns)
                if (column.FieldName == "ID")
                    column.Visible = false;
            grid.View.VisibleColumns[0].SortOrder = DevExpress.Data.ColumnSortOrder.Descending;
        }
        public class IssueList {
            static public List<IssueDataObject> GetData() {
                List<IssueDataObject> data = new List<IssueDataObject>();
                data.Add(new IssueDataObject() { ID = 0, 
                    IssueName = "Transaction History", IssueType = "Bug", IsPrivate = true });
                data.Add(new IssueDataObject() { ID = 1,
                    IssueName = "Ledger: Inconsistency", IssueType = "Bug", IsPrivate = false });
                data.Add(new IssueDataObject() { ID = 2,
                    IssueName = "Data Import", IssueType = "Request", IsPrivate = false });
                data.Add(new IssueDataObject() { ID = 3,
                    IssueName = "Data Archiving", IssueType = "Request", IsPrivate = true });
                return data;
            }
        }
        public class IssueDataObject {
            public int ID { get; set; }
            public string IssueName { get; set; }
            public string IssueType { get; set; }
            public bool IsPrivate { get; set; }
        }
    }
}
