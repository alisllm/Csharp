using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для Otchet.xaml
    /// </summary>
    public partial class Otchet : Window
    {
        public Otchet()
        {
            InitializeComponent();
        }
        ///метод для просмотра 
        ///таблицы ингридиентов
        ///
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ингридиент", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("Ингридиент");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        ///метод для просмотра 
        ///таблицы украшения для тортов
        ///
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from УкрашениеДляТорта", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("УкрашениеДляТорта");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        ///метод для печати 
        ///содержимого датагрида
        ///
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            PrintDialog Printdlg = new PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                dataGrid.Measure(pageSize);
                dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dataGrid, Title);
            }
        }
    }
}
