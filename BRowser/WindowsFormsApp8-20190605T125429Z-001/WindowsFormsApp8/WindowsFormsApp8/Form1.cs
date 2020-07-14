using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Word = Microsoft.Office.Interop.Word;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp8
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            toolStripButton2.Visible = false;
            toolStripButton3.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
        }
        public void toolStripButton1_Click_1(object sender, EventArgs e)
        {
            double start = 0;

            if (maskedTextBox1.Text.Length < 1&& textBox1.Text.Length<0&& maskedTextBox5.Text.Length<0&& maskedTextBox6.Text.Length < 0 && maskedTextBox7.Text.Length < 0)
            {
                MessageBox.Show("Вы забыли ввести сумму или название проекта!");
            }
            else
            {
                    start = Convert.ToInt32(maskedTextBox1.Text);
                    double doxod, reklama, bugalt, admin, sotrydniki, zp;
                    doxod = start / 100 * 94;
                    doxod = doxod / 100 * 69.8;
                    reklama = doxod / 100 * 5;
                    zp = doxod;
                    bugalt = doxod / 100 * 20;
                    admin = doxod / 100 * 30;
                    sotrydniki = doxod / 100 * 50;

                    label3.Text = Convert.ToString(reklama +"$");
                    label4.Text = Convert.ToString(bugalt / Convert.ToInt32(maskedTextBox7.Text))+"$";
                    label5.Text = Convert.ToString(admin / Convert.ToInt32(maskedTextBox6.Text))+"$";
                    label6.Text = Convert.ToString(sotrydniki / Convert.ToInt32(maskedTextBox5.Text))+"$";

                    chart1.Titles.Add(textBox1.Text);
                    chart2.Titles.Add(textBox1.Text);
                    chart3.Titles.Add(textBox1.Text);
                    chart4.Titles.Add(textBox1.Text);
                    chart5.Titles.Add(textBox1.Text);
                    chart6.Titles.Add(textBox1.Text);

                    chart1.Series.Add("Доход");
                    chart1.Series.Add("Реклама");
                    chart1.Series.Add("Бухгалтерия");
                    chart1.Series.Add("Администрация");
                    chart1.Series.Add("Программисты");

                    chart1.Series["Доход"].Points.Add(doxod);
                    chart1.Series["Реклама"].Points.Add(reklama);
                    chart1.Series["Бухгалтерия"].Points.Add(bugalt);
                    chart1.Series["Администрация"].Points.Add(admin);
                    chart1.Series["Программисты"].Points.Add(sotrydniki);

                    chart2.Series.Add(" ").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pie;

                    string[] x = new string[5] { "Доход", $"Реклама", $"Бухгалтерия", $"Администрация", $"Программисты" };
                    double[] y = new double[5] { doxod, reklama, bugalt, admin, sotrydniki };

                    for (int i = 0; i < 5; i++)
                        chart2.Series[0].Points.AddXY(x[i], y[i]);

                    chart3.Series.Add(" ").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
                    for (int i = 0; i < 5; i++)
                        chart3.Series[0].Points.AddXY(x[i], y[i]);


                    chart4.Series.Add(" ").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Pyramid;
                    for (int i = 0; i < 5; i++)
                        chart4.Series[0].Points.AddXY(x[i], y[i]);

                    chart6.Series.Add(" ").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Area;
                    for (int i = 0; i < 5; i++)
                        chart6.Series[0].Points.AddXY(x[i], y[i]);

                    chart5.Series.Add("Доход").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart5.Series.Add("Реклама").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart5.Series.Add("Бухгалтерия").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart5.Series.Add("Администрация").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;
                    chart5.Series.Add("Программисты").ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Bubble;

                    chart5.Series["Доход"].Points.AddXY(1, doxod);
                    chart5.Series["Реклама"].Points.AddXY(2, reklama);
                    chart5.Series["Бухгалтерия"].Points.AddXY(3, bugalt);
                    chart5.Series["Администрация"].Points.AddXY(4, admin);
                    chart5.Series["Программисты"].Points.AddXY(5, sotrydniki);
                    toolStripButton3.Visible = true;
            }
        }

        private void pieToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = true;
            chart3.Visible = false;
            chart4.Visible = false;
            chart6.Visible = false;
            chart5.Visible = false;
        }

        private void ponchikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = true;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = false;
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = true;
            chart5.Visible = false;
            chart6.Visible = false;
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = true;
            chart6.Visible = false;
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            chart1.Visible = false;
            chart2.Visible = false;
            chart3.Visible = false;
            chart4.Visible = false;
            chart5.Visible = false;
            chart6.Visible = true;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            Mail settingsForm = new Mail();
            settingsForm.Show();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            toolStripButton2.Visible = true;
            
            {
                Word.Application msword = new Word.Application();
                msword.Visible = true;
                Word.Document doc = msword.Documents.Open(@"C:\Users\Fail\Desktop\Shablon.doc");
             
                msword.Selection.Find.Execute("Название", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox1.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("**", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, label6.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("?", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, label5.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("&", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, label4.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("омг", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, label3.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("ФРМА", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox2.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("ФАМ", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, maskedTextBox4.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("Группп", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, textBox2.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("^", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, maskedTextBox5.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("=", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, maskedTextBox6.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                msword.Selection.Find.Execute("+", false, false, false, false, false, false, Word.WdFindWrap.wdFindContinue, false, maskedTextBox7.Text, Word.WdReplace.wdReplaceAll, false, false, false, false);
                saveFileDialog1.Filter = "WORD|*.doc|WORD|*.docx";
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    
                    string put = saveFileDialog1.FileName;
                    msword.ActiveDocument.SaveAs2(put);
                    msword.ActiveDocument.Close();
                }

            }
        }

        private void maskedTextBox1_Enter(object sender, EventArgs e)
        {
            maskedTextBox1.SelectionStart = maskedTextBox1.Text.Length;
        }

        private void chart6_Click(object sender, EventArgs e)
        {

        }
    }

}
