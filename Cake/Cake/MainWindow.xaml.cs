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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SqlClient;
using System.Windows.Threading;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window 
        // основной и единственный класс
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        /// метод для проверки 
        /// авторизации и перехода 
        /// к нужным формам
        {
            DispatcherTimer timer = new DispatcherTimer();
            string conString = @"Data Source = DESKTOP-P6DOUN2\MSSQLSERVER02;Integrated Security = true;Initial Catalog=Cake";
            SqlConnection connection = new SqlConnection(conString);
            try
            {
                connection.Open();
                String query = "SELECT Role FROM Пользователи WHERE login = @Логин AND Password = @Пароль";
                SqlCommand sqlCommand = new SqlCommand(query, connection);
                sqlCommand.Parameters.AddWithValue("@Логин", loginTextB.Text);
                sqlCommand.Parameters.AddWithValue("@Пароль", passwordTextB.Password);
                string rol = Convert.ToString(sqlCommand.ExecuteScalar());
                if (rol == "Заказчик")
                {
                    ZAkaz abitur = new ZAkaz();
                    abitur.Show();
                    this.Close();
                }
               else if(rol == "Менеджер по закупкам")
                {
                    Zakupki window2 = new Zakupki();
                    window2.Show();
                    this.Close();
                }
                else if (rol == "Директор")
                {
                    Window3 abitur = new Window3();
                    abitur.Show();
                    this.Close();
                }
                else if (rol == "Мастер")
                {
                    Master master = new Master();
                    master.Show();
                    this.Close();
                }
                else if (rol == "Менеджер по продажам")
                {
                    MenedjerProd menedjerProd = new MenedjerProd();
                    menedjerProd.Show();
                    this.Close();
                }
                
                else
                {
                    Cehha cehha = new Cehha();
                    cehha.Show();
                    this.Close();
                    //MessageBox.Show("Логин или пароль неправилен");
                    //error++;
                    //if (error == 3)
                    //{
                    //    error = 0;
                    //    GetIn.IsEnabled = false;
                    //    Registration.IsEnabled = false;
                    //    loginTextB.IsEnabled = false;
                    //    passwordTextB.IsEnabled = false;

                    //    timer.Tick += new EventHandler(timerTick);
                    //    timer.Interval = new TimeSpan(0, 0, 5);
                    //    timer.Start();
                    //}
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                connection.Close();

            }
            
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        /// 
        /// метод для открытия формы регистрации
        ///
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }
    }
}
