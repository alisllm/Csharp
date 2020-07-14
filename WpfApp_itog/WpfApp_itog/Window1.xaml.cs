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
using Microsoft.Win32;
using System.IO;
using System.Xml.Serialization;

namespace WpfApp_itog
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        [Serializable]
        public class auto
        {
            public string Login { get; set; }
            public string Pass { get; set; }
            public auto() { }
            public auto(string login, string pass)
            {
                Login = login;
                Pass = pass;
            }
        }
        public class Person
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Lastname { get; set; }
            public string Otec { get; set; }
            public string Pol { get; set; }
            public string Login { get; set; }
            public string Pass { get; set; }
            public string Nomer { get; set; }
            public string Photo { get; set; }
            
            public Person() { }
            
            public Person(string name, string age, string lastname, string otec, string pol, string nomer, string photo)
            {
                Name = name;
                Age = age;
                Lastname = lastname;
                Otec = otec;
                Pol = pol;
                
                Nomer = nomer;
                Photo = photo;
            }
           
        }
        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            MainWindow win = new MainWindow();
            win.Show();
            this.Close();

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            Person klient1 = new Person(name.Text, aage.Text, lastname.Text, otec.Text, pol.Text, nomerr.Text,pathphoto.Text);

            Person[] aaauto = new Person[] { klient1 };

            XmlSerializer formatter = new XmlSerializer(typeof(Person));

            using (FileStream fs = new FileStream("people.xml", FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, klient1);
            }
            ////////ddd
            auto person1 = new auto (login2.Text, password2.Text);

            auto[] people = new auto[] { person1 };

            XmlSerializer formatterr = new XmlSerializer(typeof(auto));
            using (FileStream fs = new FileStream("auto.xml", FileMode.OpenOrCreate))
            {
                formatterr.Serialize(fs, person1);
            }
            ////
            Console.ReadLine();
            MainWindow win = new MainWindow();
            win.Show();
            this.Close();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".jpg";
            dlg.Filter = "photo documents (.jpg)|*.jpg";
            dlg.InitialDirectory = "C:\\Users\\Алина\\Desktop";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                pathphoto.Text = dlg.FileName;
                Image image = new Image();
                image.Source = BitmapFrame.Create(new Uri(pathphoto.Text));
                photo.Source = image.Source;
            }
        }
        private void Pathphoto_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }
    }
}
