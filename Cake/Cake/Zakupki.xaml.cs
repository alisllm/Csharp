using System;
using System.Collections.Generic;
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
using System.Data.SqlClient;
using System.Data;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для Zakupki.xaml
    /// </summary>
    public partial class Zakupki : Window
    {
        public Zakupki()
        {
            InitializeComponent();
        }
        /// <summary>
        /// переменная для работы с таблицами
        /// </summary>
        DataSet2 DataSet2 = new DataSet2();
        /// <summary>
        /// переменная для работы с таблицой ингридиент
        /// </summary>
        ИнгридиентTableAdapter ИнгридиентTableAdapter;
        /// <summary>
        /// переменная для работы с таблицой укращения для тортов
        /// </summary>
        УкрашениеДляТортаTableAdapter УкрашениеДляТортаTableAdapter;
        /// <summary>
        /// переменная для работы с таблицой заказ
        /// </summary>
        ЗаказTableAdapter ЗаказTableAdapter;
        /// <summary>
        /// переменная для сохранения в программе выбора пользователем таблицы
        /// </summary>
        bool tabUkrashenie = true;


        /// <summary>
        /// метод для вывода в датагрид таблицы укращения для торта
        /// </summary>
        private void Window_Activated(object sender, EventArgs e)
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
        /// <summary>
        /// Обновление таблицы УкрашениеДляТорта
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            tabUkrashenie = true;
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from УкрашениеДляТорта", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("УкрашениеДляТорта");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }

        /// <summary>
        /// Обновление таблицы ингридиент
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            tabUkrashenie = false;
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Ингридиент", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("Ингридиент");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        /// <summary>
        /// Добавление новой строки в таблицу Укращения для торта
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (tabUkrashenie == true)
            {
                УкрашениеДляТортаTableAdapter = new УкрашениеДляТортаTableAdapter();
                УкрашениеДляТортаTableAdapter.InsertУкрашения(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text, Convert.ToInt32(kolvoTextB.Text), typeTextB.Text, Convert.ToInt32(priceTextB), Convert.ToDouble(vesOrPriceTextB),PostavshikTextB.Text);
                УкрашениеДляТортаTableAdapter.Fill(DataSet2.УкрашениеДляТорта);
            }
            else
            {
                ИнгридиентTableAdapter = new ИнгридиентTableAdapter();
                ИнгридиентTableAdapter.InsertIngrid(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text, Convert.ToInt32(kolvoTextB.Text), typeTextB.Text, Convert.ToInt32(priceTextB), GostTextB.Text, fasovkaTextB.Text, CharacterTextB.Text, Convert.ToString(SrokGondosti.DisplayDate), PostavshikTextB.Text);
                УкрашениеДляТортаTableAdapter.Fill(DataSet2.УкрашениеДляТорта);
            }
        }

        /// <summary>
        /// Удаление выбранноц пользователем строки в таблицы
        /// </summary>
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {

            if (tabUkrashenie == true)
            {
                DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
                УкрашениеДляТортаTableAdapter = new УкрашениеДляТортаTableAdapter();
                УкрашениеДляТортаTableAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                УкрашениеДляТортаTableAdapter.Fill(DataSet2.УкрашениеДляТорта);
            }
            else
            {
                DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
                ИнгридиентTableAdapter = new ИнгридиентTableAdapter();
                ИнгридиентTableAdapter.DeleteQuery(Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                ИнгридиентTableAdapter.Fill(DataSet2.Ингридиент);
            }

        }

        /// <summary>
        /// Изменение выбранной строки пользователем
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (tabUkrashenie == true)
            {
                DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
                УкрашениеДляТортаTableAdapter = new УкрашениеДляТортаTableAdapter();
                УкрашениеДляТортаTableAdapter.UpdateUkrash(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text, Convert.ToInt32(kolvoTextB.Text), typeTextB.Text, Convert.ToInt32(priceTextB), Convert.ToDouble(vesOrPriceTextB), PostavshikTextB.Text,Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                УкрашениеДляТортаTableAdapter.Fill(DataSet2.УкрашениеДляТорта);
            }
            else
            {
                DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
                ИнгридиентTableAdapter = new ИнгридиентTableAdapter();
                ИнгридиентTableAdapter.UpdateIngrid(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text, Convert.ToInt32(kolvoTextB.Text), typeTextB.Text, Convert.ToInt32(priceTextB), GostTextB.Text, fasovkaTextB.Text, CharacterTextB.Text, Convert.ToString(SrokGondosti.DisplayDate), PostavshikTextB.Text,Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
                УкрашениеДляТортаTableAdapter.Fill(DataSet2.УкрашениеДляТорта);
            }
        }
        /// <summary>
        /// метод для перехода на форму авторизации
        /// </summary>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        /// <summary>
        /// вывод всех заказов со статусом = ЗАкупка
        /// </summary>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM dbo.Заказ   where [Статус] = 'Закупка'", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("Заказ");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        /// <summary>
        /// метод для изменения номера заказа если роль заказа = закупка
        /// </summary>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
            string conString = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                String query = "SELECT [Статус] FROM Заказ where [Номер] = @nomerr";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@nomerr", Convert.ToString(selectedDataRow.Row.ItemArray[0]));
                string rol = Convert.ToString(sqlCommand.ExecuteScalar());
                if (rol == "Закупка")
                {
                    DataSet2 = new DataSet2();
                    ЗаказTableAdapter = new ЗаказTableAdapter();
                    ЗаказTableAdapter.UpdateQueryProizvodstvo((Convert.ToString(selectedDataRow.Row.ItemArray[0])));
                    ЗаказTableAdapter.Fill(DataSet2.Заказ);
                }
                else { MessageBox.Show("вы не можете изменять"); }
            }

            finally
            {
                connection.Close();

            }
        }
        /// <summary>
        /// метод для перехода в форму оформления заказа
        /// </summary>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            OformlenieZakaza oformlenieZakaza = new OformlenieZakaza();
            oformlenieZakaza.Show();
            this.Close();
        }

        /// <summary>
        /// метод дл перехода в форму отчета
        /// </summary>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            Otchet otchet = new Otchet();
            otchet.Show();
            this.Close();
        }
    }
}
