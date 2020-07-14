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
using Microsoft.Win32;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            
        }
        /// <summary>
        /// переменная для работы с таблицами
        /// </summary>
        DataSet2 dataset = new DataSet2(); 
        /// <summary>
        /// переменная для работы с талблицей пользователи
        /// </summary>
        ПользователиTableAdapter ПользователиTableAdapter = new ПользователиTableAdapter();
        /// <summary>
        /// Переменная для проверки пароля, пароль должен содержать хоть одну заглавную букву
        /// </summary>
        bool Est_Zaglavnie;
        /// <summary>
        /// Переменная для проверки пароля, пароль должен содержать хоть одну прописную букву
        /// </summary>
        bool Est_Propesnie;
        /// <summary>
        /// Переменная для проверки пароля, пароль должен содержать хоть одну цифру
        /// </summary>
        bool Est_Cifri;

        /// <summary>
        /// метод для проверки правильности введенного пароля,
        /// если все правильно и соответсвует требованияем 
        /// то пользователь добаляется в базу
        /// </summary>
        private void Button_Click_1(object sender, RoutedEventArgs e) 
        {
            Est_Zaglavnie = false;
            Est_Propesnie = false;
            Est_Cifri = false;
            if (surnameTextB.Text.Length > 0 && nameTextb.Text.Length > 0 && lastnameTextb.Text.Length > 0 && loginTextb.Text.Length > 0 && passTextb.Text.Length > 0)
            {
                if (loginTextb.Text != Convert.ToString(ПользователиTableAdapter.ScalarQuery(loginTextb.Text)))
                {
                    for (int i = 0; i < passTextb.Text.Length; i++)
                    {
                        if (Char.IsUpper(passTextb.Text[i]))
                        {
                            Est_Zaglavnie = true;
                        }
                        else
                        if (Char.IsNumber(passTextb.Text[i]))
                        {
                            Est_Cifri = true;
                        }
                        else
                        if (Char.IsLower(passTextb.Text[i]))
                        {
                            Est_Propesnie = true;
                        }

                    }
                    if (Est_Cifri == true && Est_Propesnie == true && Est_Zaglavnie == true && (passTextb.Text.Contains(loginTextb.Text) == false) && passTextb.Text.Length >= 5 && passTextb.Text.Length <= 20)
                    {
                        ПользователиTableAdapter.InsertQuery(loginTextb.Text, passTextb.Text, surnameTextB.Text, nameTextb.Text, lastnameTextb.Text, "Заказчик");
                        surnameTextB.Text = null;
                        nameTextb.Text = null;
                        lastnameTextb.Text = null;
                        loginTextb.Text = null;
                        passTextb.Text = null;
                        MessageBox.Show("Пользователь добавлен");
                    }
                    else
                    {
                        MessageBox.Show("Пароль должен содержать заглавные и прописные буквы, а также цифры и не должен содержать логин, а также от 5 до 20 символов");
                    }

                }
                else
                {
                    MessageBox.Show("Такой логин уже существует, придумайте другой");
                }
            }
            else
            {
                MessageBox.Show("Заполните все поля");
            }

        }
        /// <summary>
        /// Переход к форме авторизации
        /// </summary>
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

    }
}
