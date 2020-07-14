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
using System.Data.Common;
using System.Drawing;
using System.IO;

namespace Cake
{
    /// <summary>
    /// Логика взаимодействия для Cehha.xaml
    /// </summary>
    public partial class Cehha : Window
    {
        ПланировкаЦеховTableAdapter ПланировкаЦеховTableAdapter; // переменная для взаимодействия с таблицей планировка цехов
        DataSet2 DataSet2; // переменная для взаимодействия с  таблицами
        public Cehha() 
        {
            InitializeComponent();
            
        }
    }
}
