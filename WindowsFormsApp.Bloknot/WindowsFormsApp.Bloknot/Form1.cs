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
using Microsoft.Win32;

namespace WindowsFormsApp.Bloknot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.KeyPreview = true;
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            string str2 = myCurrentLanguage.Culture.DisplayName;
            menuStrip2.Items[3].Text = str2;
            
        }
        public bool Find(string stroka) 
        {
            bool returnValue = false;
            int linenumber = 0;
            int indexToText = -1;
            if (stroka.Length > 0)
            {
                indexToText = richTextBox1.Find(stroka);
                if (indexToText >= 0)
                {
                    textBox1.Text = stroka;
                    linenumber = richTextBox1.GetLineFromCharIndex(indexToText);
                    richTextBox1.SelectionStart = indexToText;
                    richTextBox1.SelectionLength = stroka.Length;
                    richTextBox1.Select(indexToText, stroka.Length);
                    richTextBox1.Focus();
                    returnValue = true;
                }
                else
                {   
                    returnValue = false;
                }
            }
            return returnValue;
        }
        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            int r = 8;
            if (r > 7)
            {
                richTextBox1.Font = new Font(richTextBox1.Font.FontFamily, trackBar1.Value, richTextBox1.Font.Style);
            }
          
        }
        private void копироватьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           richTextBox1.Copy();
        }
        private void сохранитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog SFD = new SaveFileDialog())
            {
                SFD.InitialDirectory = "C:\\Users\\itisa_24\\Desktop";
                string path = "C:\\Users\\itisa_24\\Desktop";
                //string path = Path.GetDirectoryName(Application.ExecutablePath);
                SFD.DefaultExt = ".txt";
                SFD.Filter = "txt files(*.txt)|*.txt";
                if (SFD.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter a = new StreamWriter(File.Create(Path.Combine(path))))
                    {
                        RichTextBox rtb = new RichTextBox();
                        a.WriteLine(rtb.Text);
                        a.Close();
                    }
                    richTextBox1.SaveFile("C:\\Users\\Алина\\Desktop", RichTextBoxStreamType.PlainText);

                    //using (StreamWriter sw = new StreamWriter(path, true))
                    //{
                    //    RichTextBox rtb = new RichTextBox();
                    //    sw.WriteLine(rtb.Text);
                    //    sw.Close();
                    //}
                }
            }  
        }
        private void оТкрытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           using (OpenFileDialog OFD = new OpenFileDialog())
                {
                 OFD.InitialDirectory = "C:\\Users\\itisa_24\\Desktop";
                 OFD.Filter = "txt files(*.txt)|*.txt";
                 OFD.RestoreDirectory = true;
                 OFD.Multiselect = true;
                    if (OFD.ShowDialog() == DialogResult.OK)
                    {
                        richTextBox1.Text = File.ReadAllText(OFD.FileName);
                        toolStripMenuItem5.Visible = true;
                        menuStrip2.Items[4].Text = OFD.FileName;
                     }
           }
        }
        private void отменитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Undo();
        }
        private void вставитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Paste();
        }
        public void найтиToolStripMenuItem_Click(object sender, EventArgs e)
        {
           panel2.Visible = true;
        }
        private void выделитьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.SelectAll();
        }
        private void вырезатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            richTextBox1.Cut();
        }
        private void переносПоСловамToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(richTextBox1.WordWrap == false)
            {
                richTextBox1.WordWrap = true;
            }
           else
            {
                richTextBox1.WordWrap = false;
            }
        }
        private void CправкаToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Версия 1.0 (и единственная) не знаю как добавить картнку");
        }    
        private void button1_Click(object sender, EventArgs e)
        {
            Find(textBox1.Text);
        }
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (fontDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            richTextBox1.Font = fontDialog1.Font;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            int kool = richTextBox1.TextLength;
            string kolvo = Convert.ToString(richTextBox1.TextLength);
            menuStrip2.Items[1].Text = kolvo;
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey podkey = registry.CreateSubKey("ekmn");
            this.Size = new Size(Convert.ToInt32(podkey.GetValue("Ширина")), (Convert.ToInt32(podkey.GetValue("Высота"))));
            podkey.Close();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            RegistryKey registry = Registry.CurrentUser;
            RegistryKey podkey = registry.CreateSubKey("ekmn");
            podkey.SetValue("Ширина", this.Width);
            podkey.SetValue("Высота", this.Height);
            podkey.Close();
            
            if (MessageBox.Show(" Уверены что хотите выйти?", "?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                e.Cancel = true;
        }

        private void Form1_InputLanguageChanged(object sender, InputLanguageChangedEventArgs e)
        {
            InputLanguage myCurrentLanguage = InputLanguage.CurrentInputLanguage;
            string str2 = myCurrentLanguage.Culture.DisplayName;
            menuStrip2.Items[3].Text = str2;
        }

        private void печатьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (PrintDialog print = new PrintDialog())
            {
                 
            }
        }

        private void createToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int i = tabControl1.TabCount;
            tabControl1.TabPages.Add($"Лист {i + 1}");
            RichTextBox rtb = new RichTextBox();
            rtb.Name = "rtb";
            rtb.Dock = DockStyle.Fill;
            tabControl1.TabPages[i].Controls.Add(rtb);
          
        }

 

        

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
