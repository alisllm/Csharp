using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using Word = Microsoft.Office.Interop.Word;
using System.Net;
using System.Net.Mail;

namespace Task
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        private void textViruchka_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (textViruchka.Text == "")
                {
                    textBox1.Text = "0";
                }
                string Boof = textViruchka.Text;
                int Bla = Convert.ToInt32(textViruchka.Text);
                int dohod = (Bla / 100) * 94;       //
                textBox1.Text = dohod.ToString();

                double marketing = (Convert.ToDouble(textBox1.Text) / 100) * 5;     //5 %  DOXODA
                double ost = (Convert.ToDouble(textBox1.Text) / 100) * 95;          // 95 % 
                textBox2.Text = marketing.ToString();
                double NDS = (ost / 100) * 70.3; // 
                textBox4.Text = NDS.ToString();
                double Sotrudniki_dohod = (Convert.ToDouble(textBox4.Text) / 100) * 50; // 
                textBox5.Text = Sotrudniki_dohod.ToString();
                double Zarplata_Sotr = Convert.ToDouble(textBox5.Text) / Convert.ToInt32(textBox3.Text);
                textBox6.Text = Zarplata_Sotr.ToString();
                double dohod_adm = (ost / 100) * 30;
                textBox7.Text = dohod_adm.ToString();
                double dohod_buhg = (ost / 100) * 20;
                textBox8.Text = dohod_buhg.ToString();
            }
            catch
            {

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "1";
            }
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            try
            {
                double Zarplata_Sotr = Convert.ToDouble(textBox5.Text) / Convert.ToInt32(textBox3.Text);
                textBox6.Text = Zarplata_Sotr.ToString();
            }
            catch
            {
            }
            if (textBox3.Text == "0")
            {
                textBox6.Text = "Не обнаружено!";
            }
        }
        public bool tap = true;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Dictionary<string, double> data = new Dictionary<string, double>()
                {
                    {"Выручка", Convert.ToDouble(textViruchka.Text) },
                    {"Доход"  , Convert.ToDouble(textBox1.Text)     },
                    {"Доход с НДС", Convert.ToDouble(textBox4.Text)     },
                    {"Реклама", Convert.ToDouble(textBox2.Text)     },
                    {"СОТРУДНИКИ", Convert.ToDouble(textBox5.Text) },
                    {"АДМИНИСТРАЦИЯ", Convert.ToDouble(textBox7.Text) },
                    {"БУХГАЛТЕРИЯ", Convert.ToDouble(textBox8.Text) }
                };
                if (comboBox1.Text == "1")
                {
                    if (tap == true)
                    {
                        button1.Enabled = false;
                    }
                    chart1.Series[0].ChartType = SeriesChartType.Pie;
                }
                if (comboBox1.Text == "2")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Pyramid;
                }
                if (comboBox1.Text == "3")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Doughnut;
                }
                if (comboBox1.Text == "4")
                {
                    chart1.Series[0].ChartType = SeriesChartType.Funnel;
                }
                chart1.Series[0].Points.Clear();
                chart1.ChartAreas[0].Area3DStyle.Enable3D = true;
                foreach (string dataname in data.Keys)
                {
                    chart1.Series[0].Points.AddXY(dataname, data[dataname]);
                }
            }
            catch
            {
            }

            if (tap == true)
            {
                button1.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            comboBox1.Text = "1";
            chart1.Series.Clear();
            chart1.Series.Add("Пусто");
            tap = true;
            if (tap == true)
            {
                button1.Enabled = true;
            }
        }
        private void textViruchka_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8)
            {
                e.Handled = true;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text == "1")
            {
                if (tap == true)
                {
                    button1.Enabled = false;
                }
                chart1.Series[0].ChartType = SeriesChartType.Pie;
            }
            if (comboBox1.Text == "2")
            {
                chart1.Series[0].ChartType = SeriesChartType.Pyramid;
            }
            if (comboBox1.Text == "3")
            {
                chart1.Series[0].ChartType = SeriesChartType.Doughnut;
            }
            if (comboBox1.Text == "4")
            {
                chart1.Series[0].ChartType = SeriesChartType.Funnel;
            }
        }

       

        private void Button4_Click(object sender, EventArgs e)
        {
            if (textBoxProject.Text != "" && textBoxCompanyName.Text != "" && textBoxDirector.Text != "" && textBox5.Text != "" && textBox7.Text != "" && textBoxRazrabotka.Text != "" && textBox9.Text != "")
            {
                Word.Application MSWORD = new Word.Application();
                Word.Document Doc = MSWORD.Documents.Open(@"C:\Users\Алина\Desktop\Shablon.doc"); // путь к шаблону
                MSWORD.Selection.Find.Execute("НН", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBoxProject.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("П-1,2,3,-17", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBoxCompanyName.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("И.И. Иванов", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBoxDirector.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("???", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox2.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("!!!", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox7.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("П.П. Петров", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBoxRazrabotka.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("С.С. Сидоров", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox9.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                saveFileDialog1.Filter = "WORD | *.doc | WORDX | *.docxt";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    MSWORD.ActiveDocument.SaveAs2(saveFileDialog1.FileName);
                }
                button4.Enabled = true;
                Doc.Close();
            }
            else
                MessageBox.Show("Заполните все поля!");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            if (textBoxOpen.Text != "")
            {
                MailAddress otKogo = new MailAddress("volkovaalina666@gmail.com", "Microsoft"); // ОТ КОГО
                MailAddress Komy = new MailAddress("it.is.alina0@gmail.com", "Microsoft"); // КОМУ
                MailMessage Soobshenie = new MailMessage(otKogo, Komy);
                Soobshenie.Subject = "Отчет о проекте - ТЕСТ"; // тема
                Soobshenie.Body = "Отчет";                     // 
                Soobshenie.IsBodyHtml = true;                  // Понимает RJL html
                                              

                    Soobshenie.Attachments.Add(new Attachment(textBoxOpen.Text));    //  Приклепляем файл
                    SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 465);  // Подключение порта
                    smtpClient.Credentials = new NetworkCredential("volkovaalina666@gmail.com", "пароль"); // Нужен для авторизации
                    smtpClient.EnableSsl = true;
                    smtpClient.Send(Soobshenie);
                MessageBox.Show("Отчёт отправлен!");
            }
            else
            {
                MessageBox.Show("Выберите файл!");
            }
        }

        private void ButtonOpen_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBoxOpen.Text = openFileDialog1.FileName;
           
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    } 
}
