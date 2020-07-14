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

namespace grafiki
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
                if (MessageBox.Show("Вы уверены, что хотите закрыть?", "Вопрос", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                {
                    e.Cancel = true;
                }
        }

        public bool tap = true;

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Dictionary<string, double> data = new Dictionary<string, double>()
                {
                    {"Выручка", Convert.ToDouble(textBox1.Text) },
                    {"Доход"  , Convert.ToDouble(textBox2.Text)     },
                    {"Доход с учетом налогов", Convert.ToDouble(textBox3.Text)     },
                    {"Реклама", Convert.ToDouble(textBox4.Text)     },
                    {"Доход СОТРУДНИКИ", Convert.ToDouble(textBox7.Text) },
                    {"Доход АДМИНИСТРАЦИЯ", Convert.ToDouble(textBox5.Text) },
                    {"Доход БУХГАЛТЕРИЯ", Convert.ToDouble(textBox6.Text) }
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

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox11.Text != "" && textBox12.Text != "" && textBox13.Text != "" && textBox9.Text != "" && textBox8.Text != "" && textBox14.Text != "" && textBox6.Text != "")
            {
                Word.Application MSWORD = new Word.Application();
                Word.Document Doc = MSWORD.Documents.Open(@"C:\Users\Алина\Desktop\Shablon.doc"); // путь к шаблону
                MSWORD.Selection.Find.Execute("Название", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox12.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("П-1,2,3,-17", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox10.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("И.И. Иванов", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox11.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("???", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox5.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("!!!", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox7.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                MSWORD.Selection.Find.Execute("П.П. Петров", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox13.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
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

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() != DialogResult.OK) return;
            textBox15.Text = openFileDialog1.FileName;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (textBox15.Text != "")
            {
                MailAddress otKogo = new MailAddress("СЮДА ПИСАТЬ СВОЮ ПОЧТУ", "Microsoft"); // ОТ КОГО
                MailAddress Komy = new MailAddress("СЮДА ПИСАТЬ ПОЧТУ ПОЛУЧАТЕЛЯ(МОЖНО СВОЮ ЖЕ)", "Microsoft"); // КОМУ
                MailMessage Soobshenie = new MailMessage(otKogo, Komy);
                Soobshenie.Subject = "Отчет о проекте - ТЕСТ"; // Заголовок сообщения
                Soobshenie.Body = "Текстовое сообщение "; // Содержимое сообщения
                Soobshenie.IsBodyHtml = true; // Понимает RJL html
                                              //  Приклепляем файл

                Soobshenie.Attachments.Add(new Attachment(textBox15.Text));
                SmtpClient smtpClient = new SmtpClient("smtp.gmail.com", 587); // Подключение порта
                smtpClient.Credentials = new NetworkCredential("СЮДА ПИСАТЬ СВОЮ ПОЧТУ", "СЮДА ПАРОЛЬ ОТ ПОЧТЫ"); // Нужен для авторизации
                smtpClient.EnableSsl = true;
                smtpClient.Send(Soobshenie);

                MessageBox.Show("Отчёт отправлен!");
            }
            else
            {
                MessageBox.Show("Выберите файл!");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
