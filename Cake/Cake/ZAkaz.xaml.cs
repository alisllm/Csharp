using System;
using System.Collections.Generic;
using System.Data;
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
    /// Логика взаимодействия для ZAkaz.xaml
    /// </summary>
    public partial class ZAkaz : Window
    {
        /// <summary>
        /// переменная для работы с таблицей заказ
        /// </summary>
        ЗаказTableAdapter ЗаказTableAdapter;
        /// <summary>
        /// переменная для работы с таблицми
        /// </summary>
        DataSet2 DataSet2;
        /// <summary>
        /// метод для вывода в датагрид таблицы "заказ"
        /// </summary>
        public ZAkaz()
        {
            InitializeComponent();
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Заказ", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("Заказ");
            adapter.Fill(dataTable);
            DataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }

        /// <summary>
        /// метод для перехода на форму авторизации
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        /// <summary>
        /// метод для перехода на форму оформления заказа
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            OformlenieZakaza oformlenieZakaza = new OformlenieZakaza();
            oformlenieZakaza.Show();
            this.Close();
        }
        /// <summary>
        /// метод для удаления выбранной строки пользователем
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)DataGrid.SelectedItem;
            ЗаказTableAdapter = new ЗаказTableAdapter();
            ЗаказTableAdapter.DeleteZakaz(Convert.ToString(selectedDataRow.Row.ItemArray[0]));
            ЗаказTableAdapter.Fill(DataSet2.Заказ);
        }

        /// <summary>
        /// метод для изменения заказа только если роль = закупка
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            DataRowView selectedDataRow = (DataRowView)DataGrid.SelectedItem;
            string conString = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                String query = "SELECT [Статус] FROM Заказ where [Номер] = @nomerr";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@nomerr", Convert.ToString(selectedDataRow.Row.ItemArray[0]));
                string rol = Convert.ToString(sqlCommand.ExecuteScalar());
                if (rol != "Закупка")
                {
                    DataSet2 = new DataSet2();
                    ЗаказTableAdapter = new ЗаказTableAdapter();
                    ЗаказTableAdapter.UpdateStatus((Convert.ToString(selectedDataRow.Row.ItemArray[0])));
                    ЗаказTableAdapter.Fill(DataSet2.Заказ);
                }
                else { MessageBox.Show("вы не можете изменять"); }
            }

            finally
            {
                connection.Close();

            }

        }
    }
}
