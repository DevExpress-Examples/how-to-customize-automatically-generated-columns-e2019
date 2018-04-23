using System.Collections.Generic;
using System.Windows;
using System.Windows.Documents;
using DevExpress.Xpf.Grid;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows.Markup;

namespace E2019 {
    public partial class Window1 : Window {
        public Window1() {
            InitializeComponent();
            grid.ItemsSource = IssueList.GetData();
        }
        private void OnColumnsGenerated(object sender, RoutedEventArgs e) {
            foreach(GridColumn column in grid.Columns) {
                if(column.FieldName == "IssueName") {
                    string cellTemplate = @"
        <DataTemplate xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
                      xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
                      xmlns:dxe=""http://schemas.devexpress.com/winfx/2008/xaml/editors"">
            <dxe:TextEdit x:Name=""PART_Editor"" Foreground=""Blue""/>
        </DataTemplate>";
                    column.CellTemplate = XamlReader.Parse(cellTemplate) as DataTemplate;
                    column.SortOrder = DevExpress.Data.ColumnSortOrder.Ascending;
                } else if(column.FieldName == "IssueType") {
                    column.CellTemplate = Application.Current.MainWindow.Resources["IssueTypeTemplate"] as DataTemplate;
                } else if(column.FieldName == "ID") {
                    column.Visible = false;
                }
            }
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

    public class IssueTypeForegroundConverter : IValueConverter {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            if(value == null)
                return null;

            string issueType = value.ToString();
            if(issueType == "Bug")
                return new SolidColorBrush(Colors.Red);

            return new SolidColorBrush(Colors.Black);
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture) {
            throw new System.NotImplementedException();
        }
    }

}
