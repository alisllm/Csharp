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
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {

        public Window3()
        {
            InitializeComponent();
        
        }
        /// <summary>
        /// переменная для работы с таблицами
        /// </summary>
        DataSet2 DataSet2 = new DataSet2();
        /// <summary>
        /// переменная для работы с таблицей ингридиент
        /// </summary>
        ИнгридиентTableAdapter ИнгридиентTableAdapter;
        /// <summary>
        /// переменная для работы с таблицей Украшения для тортов
        /// </summary>
        УкрашениеДляТортаTableAdapter УкрашениеДляТортаTableAdapter;
        /// <summary>
        /// переменная для сохранения в программе выбора пользователем таблицы
        /// </summary>
        bool tabUkrashenie = true;

        /// <summary>
        /// метод для вывода в датагрид таблицы украшения для тортов
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
        /// Добавление новой строки в таблицу украшения для тортов
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            if (tabUkrashenie == true)
            {
                УкрашениеДляТортаTableAdapter = new УкрашениеДляТортаTableAdapter();
                УкрашениеДляТортаTableAdapter.InsertУкрашения(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text,Convert.ToInt32(kolvoTextB.Text), typeTextB.Text,Convert.ToInt32(priceTextB), Convert.ToDouble(vesOrPriceTextB),PostavshikTextB.Text);
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
        /// удаление выбранной пользователем строки в 
        /// таблицы укращения для тортов
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
        /// Изменение поля в таблицы укращения для тортов
        /// </summary>
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            if (tabUkrashenie == true)
            {
                DataRowView selectedDataRow = (DataRowView)dataGrid.SelectedItem;
                УкрашениеДляТортаTableAdapter = new УкрашениеДляТортаTableAdapter();
                УкрашениеДляТортаTableAdapter.UpdateUkrash(Convert.ToInt32(ArtikTextB.Text), NameTextB.Text, IzmerenieTextB.Text, Convert.ToInt32(kolvoTextB.Text), typeTextB.Text, Convert.ToInt32(priceTextB), Convert.ToDouble(vesOrPriceTextB),PostavshikTextB.Text, Convert.ToInt32(selectedDataRow.Row.ItemArray[0]));
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
        /// переход к форме авторизации
        /// </summary>
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        /// <summary>
        /// ХЗ
        /// </summary>
        public string MyText()
        {
            return NameTextB.Text;
        }
        /// <summary>
        /// переход на форму Цеха
        /// </summary>
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            Cehha cehha = new Cehha();
            cehha.Show();
            this.Close();
        }

        /// <summary>
        /// переход на форму Сбой оборудования
        /// </summary>
        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            SboyOborudovania sboyOborudovania = new SboyOborudovania();
            sboyOborudovania.Show();
            this.Close();
        }
        /// <summary>
        /// метод для заполнения содержимого датагрида
        /// таблицей заказ
        /// </summary>
        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from Заказ", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("Заказ");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        /// <summary>
        /// метод для заполнения содержимого датагрида
        /// таблицей статусы заказов
        /// </summary>
        private void Button_Click_9(object sender, RoutedEventArgs e)
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from СтатусыЗаказов", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("СтатусыЗаказов");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        /// <summary>
        /// метод для перехода к форме Отчеты
        /// </summary>
        private void Button_Click_10(object sender, RoutedEventArgs e)
        {
            Otchet otchet = new Otchet();
            otchet.Show();
            this.Close();
        }
    }
}
