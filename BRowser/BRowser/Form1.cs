using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BRowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        public static bool blank = true;


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
            if (nw.CanGoBack == true)
            {
                nw.GoBack();
                toolStripButton2.Enabled = true;
            }
            else
            {
                MessageBox.Show("Вернуться назад невозможно");
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
            if (nw.CanGoForward == true)
            {
                nw.GoForward();
            }
            else 
            {
                toolStripButton2.Enabled = false;
            }
            
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
            nw.Refresh();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
            nw.GoHome();
        }

        private void новаяВкладкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = TabControl1.TabCount;
            TabControl1.TabPages.Add($"Новая вкладка {i + 1}");
            WebBrowser nw = new WebBrowser();
            nw.Navigate("https://www.google.ru");
            nw.Name = "nw";
            nw.Dock = DockStyle.Fill;
            this.TabControl1.TabPages[i].Controls.Add(nw);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton2.Enabled = false;
            ночнаяТемаToolStripMenuItem.Checked = false;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (toolStripTextBox1.Text != null)
            {
                ((WebBrowser)TabControl1.SelectedTab.Controls[0]).Navigate(toolStripTextBox1.Text);
            }
            else
            {

            }
        }

        private void закрытьВкладкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = TabControl1.SelectedIndex;
            TabControl1.TabPages.RemoveAt(i);
            
           
        }

        private void hScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
           // nw.Document.All()
          
        }

        private void nw_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {

            var nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
            toolStripTextBox1.Text = nw.Url.ToString();

            string filename = @"C:\Новая папка\history.txt";

            //Создаём или перезаписываем существующий файл

                 using (StreamWriter sw = File.AppendText(filename))

           
                 { 
                     sw.WriteLine(toolStripTextBox1.Text);
                 }

           
            





        }

        private void историяToolStripMenuItem_Click(object sender, EventArgs e)
        {


            int i = TabControl1.TabCount;
            TabControl1.TabPages.Add($"История {i + 1}");
            RichTextBox history = new RichTextBox();
            history.Name = "history";

            TabControl1.TabPages[i].Controls.Add(history);
            history.Dock = DockStyle.Fill;
            string Путь = @"C:\Новая папка\history.txt";
            using (StreamReader sr = new StreamReader(Путь, System.Text.Encoding.Default))
            {


                string MyText;
                MyText = File.ReadAllText(Путь);
                history.Text = MyText;
                sr.Close();
                
            }



        }

        private void toolStripDropDownButton1_Click(object sender, EventArgs e)
        {

           


        }

        private void nw_Navigating(object sender, WebBrowserNavigatingEventArgs e)
        {
             WebBrowser nw = TabControl1.SelectedTab.Controls.Find("nw", false)[0] as WebBrowser;
             toolStripTextBox1.Text = nw.Url.ToString();
        }

        private void загрузкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();

                openFileDialog1.InitialDirectory = @"C:\Users\Fail\Downloads";

                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                }
            }
        }

        private void ночнаяТемаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (blank == true)
            {
                toolStripButton1.ForeColor = Color.Cyan;
                toolStripButton2.ForeColor = Color.Cyan;
                toolStripButton3.ForeColor = Color.Cyan;
                button1.ForeColor = Color.Cyan;
                toolStripButton5.ForeColor = Color.Cyan;

                toolStrip1.BackColor = Color.DimGray;

                button1.BackColor = Color.DimGray;

                toolStripDropDownButton1.BackColor = Color.DimGray;
                toolStripDropDownButton1.ForeColor = Color.Cyan;

                toolStripTextBox1.BackColor = Color.WhiteSmoke;

                toolStripTextBox1.ForeColor = Color.Pink;


                ночнаяТемаToolStripMenuItem.Checked = true;
                blank = false;
            }
            else
            {
                toolStripButton1.ForeColor = Color.Black;
                toolStripButton2.ForeColor = Color.Black;
                toolStripButton3.ForeColor = Color.Black;
                button1.ForeColor = Color.Black;
                toolStripButton5.ForeColor = Color.Black;


                toolStrip1.BackColor = Color.WhiteSmoke;

                button1.BackColor = Color.WhiteSmoke;

                toolStripDropDownButton1.BackColor = Color.WhiteSmoke;
                toolStripDropDownButton1.ForeColor = Color.Black;

                toolStripTextBox1.BackColor = Color.White;
                toolStripTextBox1.ForeColor = Color.Black;

                ночнаяТемаToolStripMenuItem.Checked = false;
                blank = true;
            }
        }
    }
}
