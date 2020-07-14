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
using System.Xml.Serialization;
using System.IO;

namespace WpfApp_itog
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public class User
        {
            public string login { get; set; }
            public string Password { get; set; }
            public User() { items = new List<User>(); }
            public User(string name, string password)
            {
                login = name;
                Password = password;
            }
            public List<User> items;
        }
        
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
            this.Close();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {


            /////////////////////////

            XmlSerializer formatter = new XmlSerializer(typeof(User));
            User us;
            using (Stream ins = File.Open("auto.xml", FileMode.OpenOrCreate))
            {
                try
                {
                    us = (User)formatter.Deserialize(ins);
                }
                catch
                {
                    us = new User();
                }
            }
            for (int i = 0; i < us.items.Count; i++)
            {
                if (login.Text == us.items[i].login && pass.Text == us.items[i].Password)
                {
                        Window2 window2 = new Window2();
                        window2.Show();
                        MessageBox.Show("Добро пожаловать");             
                }
               
            }
        }
        private void logitn(object sender, MouseEventArgs e)
        {

           
            
        }
    }
}
