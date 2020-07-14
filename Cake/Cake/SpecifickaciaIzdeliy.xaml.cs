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
    /// Логика взаимодействия для SpecifickaciaIzdeliy.xaml
    /// </summary>
    public partial class SpecifickaciaIzdeliy : Window
    {
        /// <summary>
        /// переменная для работы с таблицей "изделия"
        /// </summary>
        ИзделиеTableAdapter ИзделиеTableAdapter;
        /// <summary>
        /// переменная для работы с таблицами
        /// </summary>
        DataSet2 DataSet2;
        /// <summary>
        /// метод для заполнения комбо-бокса данными из
        /// таблицы изделия
        /// и заполнением датагрид таблицей Спецификация изделий
        /// </summary>
        public SpecifickaciaIzdeliy()
        {
            InitializeComponent();
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from СпецификацияИзделий", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("СпецификацияИзделий");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();

            ИзделиеTableAdapter = new ИзделиеTableAdapter();
            DataSet2 = new DataSet2();
            new ИзделиеTableAdapter().Fill(DataSet2.Изделие);
            IzdeliaComboB.ItemsSource = DataSet2.Изделие;
            IzdeliaComboB.DisplayMemberPath = "Изделие";
            IzdeliaComboB.SelectedValuePath = "Изделие";


        }

        /// <summary>
        /// метод для печати содержимого датагрида
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Controls.PrintDialog Printdlg = new System.Windows.Controls.PrintDialog();
            if ((bool)Printdlg.ShowDialog().GetValueOrDefault())
            {
                Size pageSize = new Size(Printdlg.PrintableAreaWidth, Printdlg.PrintableAreaHeight);
                dataGrid.Measure(pageSize);
                dataGrid.Arrange(new Rect(5, 5, pageSize.Width, pageSize.Height));
                Printdlg.PrintVisual(dataGrid, Title);
            }
        }
        /// <summary>
        /// метод для перехода к форме авторизации
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
