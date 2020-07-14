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
    /// Логика взаимодействия для Master.xaml
    /// </summary>
    public partial class Master : Window
    {
        public Master()
        {
            InitializeComponent();
        }
         
        private void Button_Click_1(object sender, RoutedEventArgs e) ///метод для просмотра в датагрид таблицы Ингридиент
            ///
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
        ///метод для просмотра в датагрид 
        ///таблицы УкращениеДляТорта
        ///

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
             
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from УкращениеДляТорта", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("УкращениеДляТорта");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }

        ///метод для перехода к 
        ///форме сбой оборудования
        ///

        private void Button_Click_7(object sender, RoutedEventArgs e) 
        {
            SboyOborudovania sboyOborudovania = new SboyOborudovania();
            sboyOborudovania.Show();
            this.Close();
        }
        ///метод для перехода к 
        ///форме спецификация изделий
        ///

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
             
            SpecifickaciaIzdeliy specifickaciaIzdeliy = new SpecifickaciaIzdeliy();
            specifickaciaIzdeliy.Show();
            this.Close();
        }
        ///метод для перехода к 
        ///форме авторизации
        ///

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
        ///метод для перехода к 
        ///форме контроля качества
        ///

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            KontrolKachestva kontrolKachestva = new KontrolKachestva();
            kontrolKachestva.Show();
            this.Close();
        }
    }
}
