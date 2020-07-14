using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace WindowsFormsApp8
{
    public partial class Mail : Form
    {
        public Mail()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            if (textBox1.Text.Length>0 && comboBox1.Text.Length>0)
            {
                MailAddress otkogo = new MailAddress("p_d.s.Domrachev@mpt.ru", "П-11-18");
                MailAddress komy = new MailAddress(textBox1.Text + comboBox1.Text);
                MailMessage sms = new MailMessage(otkogo, komy);
                sms.Subject = "Отчет";
                sms.Body = "";
                sms.Attachments.Add(new Attachment(@textBox3.Text));
                sms.IsBodyHtml = true;
                SmtpClient clent = new SmtpClient("smtp.gmail.com", 587);
                clent.Credentials = new NetworkCredential("p_d.s.Domrachev@mpt.ru", "*******");
                clent.EnableSsl = true;
                clent.Send(sms);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
           // OpenFileDialog open = new OpenFileDialog();
            //open.ShowDialog();
            DialogResult opn = openFileDialog1.ShowDialog();
            //open.Filter = "txt files (*.doc)|*.docs";
            //open.Filter = "Word Documents|*.doc";
            if (opn == DialogResult.OK)
            {

               // open.Filter = "Word Documents|*.doc";
                string filepath = openFileDialog1.FileName;
                string name = openFileDialog1.SafeFileName;

                textBox3.Text = filepath;



            }
        }

        private void Mail_Load(object sender, EventArgs e)
        {

        }
    }
}
