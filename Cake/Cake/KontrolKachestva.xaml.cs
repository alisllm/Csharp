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
using Cake.DataSet2TableAdapters;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для KontrolKachestva.xaml
    /// </summary>
    public partial class KontrolKachestva : Window
    {
       
        public KontrolKachestva() // метод для вывода таблицы Контроль качества в датасет
        {
            InitializeComponent();
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from КонтрольКачества", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("КонтрольКачества");
            adapter.Fill(dataTable);
            DataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
            
        }
    }
}
