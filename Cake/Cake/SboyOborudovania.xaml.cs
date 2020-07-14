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
    /// Логика взаимодействия для SboyOborudovania.xaml
    /// </summary>
    public partial class SboyOborudovania : Window
    {
        /// <summary>
        /// переменная для работы с таблицой оборудование
        /// </summary>
        ОборудованиеTableAdapter ОборудованиеTableAdapter;
        /// <summary>
        /// переменная для работы с таблицой сбой оборудования
        /// </summary>
        СбойОборудованияTableAdapter СбойОборудованияTableAdapter;
        /// <summary>
        /// переменная для работы с таблицой тип оборудования
        /// </summary>
        ТипОборудованиеTableAdapter ТипОборудованиеTableAdapter;
        /// <summary>
        /// переменная для работы с таблицами
        /// </summary>
        DataSet2 DataSet2;
        /// <summary>
        /// метод для заполнения содержимого Комбобоксов сразу при открытии формы
        /// </summary>
        public SboyOborudovania()
        {
            InitializeComponent();
            obnova();
            ОборудованиеTableAdapter = new ОборудованиеTableAdapter();
            DataSet2 = new DataSet2();
            new ОборудованиеTableAdapter().Fill(DataSet2.Оборудование);
            MarkirovkaComboB.ItemsSource = DataSet2.Оборудование;
            MarkirovkaComboB.DisplayMemberPath = "Маркировка";
            MarkirovkaComboB.SelectedValuePath = "Маркировка";
            ///
            ТипОборудованиеTableAdapter = new ТипОборудованиеTableAdapter();
            DataSet2 = new DataSet2();
            new ТипОборудованиеTableAdapter().Fill(DataSet2.ТипОборудование);
            TypeOborudComboB.ItemsSource = DataSet2.ТипОборудование;
            TypeOborudComboB.DisplayMemberPath = "Тип_Оборуования";
            TypeOborudComboB.SelectedValuePath = "Тип_Оборуования";

        }
        /// <summary>
        /// таблица для обновления содержимого датагрида
        /// </summary>
        public void obnova()
        {
            string s = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(s);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("select * from СбойОборудования", connection);
            System.Data.DataTable dataTable = new System.Data.DataTable("СбойОборудования");
            adapter.Fill(dataTable);
            dataGrid.ItemsSource = dataTable.DefaultView;
            connection.Close();
        }
        /// <summary>
        /// метод для корректного ввода времени начала сбоя
        /// </summary>
        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            string a;
            a = VremyaNachala.Text;
            if (a.Length == 2)
            {
                VremyaNachala.Text = VremyaNachala.Text + ":";//добавляет запятую после второго знака
                VremyaNachala.SelectionStart = VremyaNachala.Text.Length;//переносит курсор в конец текстбокса
            };
            if (a.Length == 5)
            {
                VremyaNachala.Text = VremyaNachala.Text + ":";//добавляет запятую после второго знака
                VremyaNachala.SelectionStart = VremyaNachala.Text.Length;//переносит курсор в конец текстбокса
            };

        }
        /// <summary>
        /// метод для сохраниния в таблицу сбоя
        /// </summary>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            СбойОборудованияTableAdapter = new СбойОборудованияTableAdapter();
            string Nachalo = data.Text + " " + VremyaNachala.Text;
            string Okon = dataO.Text + " " + VremyaOTextB.Text;
            СбойОборудованияTableAdapter.InsertSboyOb(PrichinaComboB.Text, MarkirovkaComboB.Text, TypeOborudComboB.Text, Convert.ToString(Nachalo), Convert.ToString(Okon));
            СбойОборудованияTableAdapter.Fill(DataSet2.СбойОборудования);
            obnova();
        }
        /// <summary>
        /// метод для корректного ввода времени начала сбоя
        /// </summary>
        private void VremyaOTextB_TextChanged(object sender, TextChangedEventArgs e)
        {
            string a;
            a = VremyaOTextB.Text;
            if (a.Length == 2)
            {
                VremyaOTextB.Text = VremyaOTextB.Text + ":";//добавляет запятую после второго знака
                VremyaOTextB.SelectionStart = VremyaOTextB.Text.Length;//переносит курсор в конец текстбокса
            };
            if (a.Length == 5)
            {
                VremyaOTextB.Text = VremyaOTextB.Text + ":";//добавляет запятую после второго знака
                VremyaOTextB.SelectionStart = VremyaOTextB.Text.Length;//переносит курсор в конец текстбокса
            };
        }
    }
}
