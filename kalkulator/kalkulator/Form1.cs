using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace kalkulator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           

        }
        double a, b, c;
        int dejstvie;
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {
            textBox1.Text = textBox1.Text + (sender as Button).Text;
        }  
        private void button20_Click(object sender, EventArgs e) //сумма
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = Convert.ToString(a);
                label2.Text = "+";
                dejstvie = 1;
                textBox1.Text = "";
                a = 0;
            }
            catch { }
        }

        private void button8_Click(object sender, EventArgs e)  // минус
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = Convert.ToString(a);
                label2.Text = "-";
                dejstvie = 2;
                textBox1.Text = "";
                a = 0;
            }
            catch { }
        }
        private void button22_Click(object sender, EventArgs e) // умножение 
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = Convert.ToString(a);
                label2.Text = "*";
                dejstvie = 3;
                textBox1.Text = "";
                a = 0;
            }
            catch { }
        }
        private void button5_Click(object sender, EventArgs e) // С
        {
            textBox1.Clear();
        }
        private void button17_Click(object sender, EventArgs e)// СЕ
        {
            textBox1.Clear();
            label2.Text = "";
            label1.Text = "";
        }
        private void button3_Click(object sender, EventArgs e) 
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = Convert.ToString(a);
            label2.Text = "x²";
            textBox1.Text = "";
            c = Math.Pow(a, 2);
            textBox1.Text = Convert.ToString(c);
        }
        private void button4_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = Convert.ToString(a);
            label2.Text = "1/x";
            textBox1.Text = "";
            c = 1 / a;
            textBox1.Text = Convert.ToString(c);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox1.Text);
            label1.Text = Convert.ToString(a);
            label2.Text = "√";
            textBox1.Text = "";
            c = Math.Sqrt(a);
            textBox1.Text = Convert.ToString(c);
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            s = s.Remove(s.Length - 1, 1);
            textBox1.Text = s;
        }
        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                a *= -1;
                textBox1.Text = Convert.ToString(a);
            }
            catch
            { }
        }
        private void button21_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox1.Text);
                label1.Text = Convert.ToString(a);
                label2.Text = "÷";
                dejstvie = 4;// деление 
                textBox1.Text = "";
                a = 0;
            }
            catch { }
        }
        private void button24_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dejstvie)

                {
                    case 1:// сумма 
                        {
                            a = Convert.ToDouble(label1.Text);
                            b = Convert.ToDouble(textBox1.Text);

                            c = a + b;
                            textBox1.Text = Convert.ToString(c);
                            label2.Text = "";
                            label1.Text = "";
                            break;
                        }
                    case 2: // минус 
                        {
                            a = Convert.ToDouble(label1.Text);
                            b = Convert.ToDouble(textBox1.Text);

                            c = a - b;
                            textBox1.Text = Convert.ToString(c);
                            label2.Text = "";
                            label1.Text = "";
                            break;

                        }
                    case 3:/// умножение 
                        {
                            a = Convert.ToDouble(label1.Text);
                            b = Convert.ToDouble(textBox1.Text);
                            c = a * b;
                            textBox1.Text = Convert.ToString(c);
                            label2.Text = "";
                            label1.Text = "";
                            break;

                        }
                    case 4: // деление 
                        {
                            if (Convert.ToDouble(textBox1.Text) != 0)
                            {
                                a = Convert.ToDouble(label1.Text);
                                b = Convert.ToDouble(textBox1.Text);
                                c = a / b;
                                textBox1.Text = Convert.ToString(c);
                                label2.Text = "";
                                label1.Text = "";
                            }
                            else
                            {
                                textBox1.Text = "Делить на ноль нельзя";
                            }
                            break;

                        }
                }
            }
            catch { }
        }
       //////////////////////////////////////////////////////////////////
        private void button36_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox2.Text + (sender as Button).Text;
        }

        private void button30_Click(object sender, EventArgs e)// минус
        {
            try
            {
                a = Convert.ToDouble(textBox2.Text);
                label3.Text = Convert.ToString(a);
                label4.Text = "-";
                dejstvie = 2;
                textBox2.Text = "";
                a = 0;
            }
            catch { }
        }   
        private void button35_Click(object sender, EventArgs e)// умножение 
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "-";
            dejstvie = 2;
            textBox2.Text = "";
            a = 0;
        }
        private void button40_Click(object sender, EventArgs e) //СЕ
        {
            textBox2.Clear();
            label3.Text = "";
            label4.Text = "";
        }
        private void button31_Click(object sender, EventArgs e)//С
        {
            textBox2.Clear();
        }
        private void button1_Click(object sender, EventArgs e)//---
        {
            string s = textBox2.Text;
            s = s.Remove(s.Length - 1, 1);
            textBox2.Text = s;
        }
        private void button27_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "x²";
            textBox2.Text = "";
            c = Math.Pow(a, 2);
            textBox2.Text = Convert.ToString(c);
        }
        private void button25_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "√";
            textBox2.Text = "";
            c = Math.Sqrt(a);
            textBox2.Text = Convert.ToString(c);
        }
        private void button47_Click(object sender, EventArgs e)//sin
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "sin";
            textBox2.Text = "";
            c = Math.Sin(a);
            textBox2.Text = Convert.ToString(c);
            a = 0;
        }
        private void button49_Click(object sender, EventArgs e)//cos
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "cos";
            textBox2.Text = "";
            c = Math.Cos(a);
            textBox2.Text = Convert.ToString(c);
            a = 0;
        }
        private void button50_Click(object sender, EventArgs e)//tan
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "tan";
            textBox2.Text = "";
            c = Math.Tan(a);
            textBox2.Text = Convert.ToString(c);
            a = 0;
        }
        private void button51_Click(object sender, EventArgs e)//log
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "ln";
            textBox2.Text = "";
            c = Math.Log10(a);
            textBox2.Text = Convert.ToString(c);
            a = 0;
        }
        private void button48_Click(object sender, EventArgs e)  //x^y
        {
            try
            {
                a = Convert.ToDouble(textBox2.Text);
                label3.Text = Convert.ToString(a);
                textBox2.Text = "";
                dejstvie = 5;
            }
            catch { }
        }
        private void button26_Click(object sender, EventArgs e)
        {
            try
            {
                switch (dejstvie)

                {
                    case 1:// сумма 
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = a + b;
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;
                        }
                    case 2: // минус 
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);

                            c = a - b;
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;

                        }
                    case 3:/// умножение 
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = a * b;
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;

                        }
                    case 4: // деление 
                        {
                            if (Convert.ToDouble(textBox2.Text) != 0)
                            {
                                a = Convert.ToDouble(label3.Text);
                                b = Convert.ToDouble(textBox2.Text);
                                c = a / b;
                                textBox2.Text = Convert.ToString(c);
                                label3.Text = "";
                                label4.Text = "";
                            }
                            else
                            {
                                textBox2.Text = "Делить на ноль нельзя";
                            }
                            break;
                        }
                    case 5:
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = Math.Pow(a, b);
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;
                        }
                    case 7:
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = Math.Pow(10, b);
                            c = a * c;
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;
                        }
                    case 8:
                        {
                            a = Convert.ToDouble(label3.Text);
                            b = Convert.ToDouble(textBox2.Text);
                            c = Math.IEEERemainder(a, b);
                            textBox2.Text = Convert.ToString(c);
                            label3.Text = "";
                            label4.Text = "";
                            break;
                        }
                }
            }
            catch { }
        }
        private void button52_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            c = Math.Pow(a, 10);
            textBox2.Text = Convert.ToString(c);
        }
        private void button28_Click(object sender, EventArgs e)
        {

            if (textBox2.Text.LastIndexOf(",") == -1)
            {
                if (textBox2.Text.Length == 0)
                {
                    textBox2.Text = textBox2.Text + "0,";
                }
                else
                {
                    textBox2.Text = textBox2.Text + ",";
                }
            }
        }
        private void button53_Click(object sender, EventArgs e)
        {
            textBox2.Text = Convert.ToString(Math.PI);
        }
        static double Fact(double n)
        {
                if (n == 0)
                {
                    return 1;
                }
                return n * Fact(n - 1);
        }
        private void button54_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            c = Fact(a);
            textBox2.Text = Convert.ToString(c);
        }
        private void button55_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "Mod";
            dejstvie = 8;
            textBox2.Text = "";
            a = 0;
        }
        private void button56_Click(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox2.Text);
                label3.Text = Convert.ToString(a);
                label4.Text = "Exp";
                dejstvie = 7;
                textBox2.Text = "";
                a = 0;
            }
            catch { }
        }
        private void button33_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            a *= -1;
            textBox2.Text = Convert.ToString(a);
        }
        private void button23_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.LastIndexOf(",") == -1)
            {
                if (textBox1.Text.Length == 0)
                {
                    textBox1.Text = textBox1.Text + "0,";
                }
                else
                {
                    textBox1.Text = textBox1.Text + ",";
                }
            }
        }
        private void button34_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "+";
            dejstvie = 1;
            textBox2.Text = "";
            a = 0;
        }
        private void button34_Click_1(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "+";
            dejstvie = 1;
            textBox2.Text = "";
            a = 0;
        }
        private void button32_Click_1(object sender, EventArgs e)
        {
            try
            {
                a = Convert.ToDouble(textBox2.Text);
                label3.Text = Convert.ToString(a);
                label4.Text = "÷";
                dejstvie = 4;// деление 
                textBox2.Text = "";
                a = 0;
            }
            catch { }
        }
        private void button80_Click(object sender, EventArgs e)
        {
            button69.Enabled = false;
            button61.Enabled = false;
            button62.Enabled = false;
            button63.Enabled = false;
            button64.Enabled = false;
            button65.Enabled = false;
            button66.Enabled = false;
            button67.Enabled = false;
            button68.Enabled = false;
            button69.Enabled = false;
        }
        private void button96_Click(object sender, EventArgs e)
        {
            DateTime z = DateTime.MinValue;
            if(dateTimePicker3.Value<dateTimePicker4.Value)
            {
                z = z.Add(dateTimePicker4.Value.Date - dateTimePicker3.Value.Date);
                textBox6.Text = Convert.ToString(Math.Abs((dateTimePicker4.Value.Date - dateTimePicker3.Value.Date).TotalDays));
            }
            else
            {
                z = z.Add(dateTimePicker3.Value.Date - dateTimePicker4.Value.Date);
                textBox6.Text = Convert.ToString(Math.Abs((dateTimePicker3.Value.Date - dateTimePicker4.Value.Date).TotalDays));
            }
            string yeras = Convert.ToString(z.Year - 1) + "г ";
            string month = Convert.ToString(z.Month - 1) + "м ";
            string day = Convert.ToString(z.Day - 1) + "д ";
            textBox6.Text = yeras + month + day;
        }

        private void button32_Click(object sender, EventArgs e)
        {
            a = Convert.ToDouble(textBox2.Text);
            label3.Text = Convert.ToString(a);
            label4.Text = "÷";
            dejstvie = 4;// деление 
            textBox2.Text = "";
            a = 0;
        }
        private void button57_Click(object sender, EventArgs e)
        {
            DateTime ad = dateTimePicker1.Value;
            if (textBox3.Text == "")
                textBox3.Text = "0";
            if (textBox4.Text == "")
                textBox4.Text = "0";
            if (textBox5.Text == "")
                textBox5.Text = "0";
            try
            {
                if (radioButton1.Checked)
                {
                    ad = ad.AddDays(Convert.ToDouble(textBox5.Text));
                    ad = ad.AddMonths(Convert.ToInt32(textBox4.Text));
                    ad = ad.AddYears(Convert.ToInt32(textBox3.Text));
                    dateTimePicker2.Value = ad; 
                }
                if (radioButton2.Checked)
                {
                    ad = ad.AddDays(0 - Convert.ToDouble(textBox5.Text));
                    ad = ad.AddMonths(0 - Convert.ToInt32(textBox4.Text));
                    ad = ad.AddYears(0 - Convert.ToInt32(textBox3.Text));
                    dateTimePicker2.Value = ad;
                }
            }
            catch
            {
                MessageBox.Show("Введены некорректные значения");
            }
        }
    }
 }


