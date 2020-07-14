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
using System.Xml.Serialization;
using System.IO;

namespace WpfApp_itog
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public class User
        {
            public string Special { get; set; }
            public string Fio { get; set; }

            public User() { }
            public User(string special, string fio)
            {
                Special = special;
                Fio = fio;
            }
        }
        public class Users
        {
            public List<User> items;

            public Users()
            {
                items = new List<User>();

            }
        }
        public Window2()
        {
            InitializeComponent();

            User klient1 = new User();

            User[] people = new User[] { klient1 };
            XmlSerializer formatter = new XmlSerializer(typeof(User));

            using (FileStream fs = new FileStream("special.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, people);
            }
            Console.ReadLine();
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
