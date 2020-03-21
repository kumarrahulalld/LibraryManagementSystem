using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Xml;
namespace Library
{
    public partial class email : Form
    {
        string path = @"C:\";
        string s_mail = "";
        string s_password="";
        System.Text.RegularExpressions.Regex expr = new System.Text.RegularExpressions.Regex(@"^[a-zA-Z][\w\.-]{2,28}[a-zA-Z0-9]@[a-zA-Z0-9][\w\.-]*[a-zA-Z0-9]\.[a-zA-Z][a-zA-Z\.]*[a-zA-Z]$");
        public email()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form22");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("email_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("subject_label").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("message_label").InnerText;
            send_button.Text = nodeList[0].SelectSingleNode("send_button").InnerText;
            clear_button.Text = nodeList[0].SelectSingleNode("clear_button").InnerText;
            attachment_button.Text = nodeList[0].SelectSingleNode("attachment_button").InnerText;
             nodeList = doc.SelectNodes("form/email_info");
            s_mail = nodeList[0].SelectSingleNode("email").InnerText;
            s_password = nodeList[0].SelectSingleNode("password").InnerText;
        }

        private void send_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Destination Email Field Can't Be Blank");
            else if (textBox2.Text == "")
                MessageBox.Show("Subject Field Can't Be Blank");
            else if (richTextBox1.Text == "")
                MessageBox.Show("Message Field Can't Be Blank");
            else if (checkBox1.Checked && openFileDialog1.FileName == "")
                MessageBox.Show("Attachment File not Selected");
            else
            {
                using (MailMessage mm = new MailMessage(s_mail, textBox1.Text.Trim()))
                {
                    mm.Subject = textBox2.Text;
                    mm.Body = richTextBox1.Text;
                    foreach (string filePath in openFileDialog1.FileNames)
                    {
                        if (File.Exists(filePath))
                        {
                            string fileName = Path.GetFileName(filePath);
                            mm.Attachments.Add(new Attachment(filePath));
                        }
                    }
                    mm.IsBodyHtml = false;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential(s_mail.Trim(), s_password.Trim());
                    smtp.UseDefaultCredentials = true;
                    smtp.Credentials = NetworkCred;
                    smtp.Port = 587;

                    smtp.Send(mm);
                    MessageBox.Show("Email sent Successfully.", "Message");
                    using (var tw = new StreamWriter(path, true))
                    {

                        tw.WriteLine("User Sended An Email To {0} With Subject {1} And Message {2}",textBox1.Text,textBox2.Text,richTextBox1.Text);
                    }
                }
            }
        }

        private void clear_button_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            richTextBox1.Text = "";
            label4.Visible = false;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
                attachment_button.Visible = true;
            else
                attachment_button.Visible = false;
        }

        private void attachment_button_Click(object sender, EventArgs e)
        {
            label4.Text = "";
            openFileDialog1.ShowDialog();
            
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            foreach (string filePath in openFileDialog1.FileNames)
            {
                if (File.Exists(filePath))
                {
                    string fileName = Path.GetFileName(filePath);
                    label4.Text += fileName;
                }
            }
            label4.Visible = true;
        }
    }
}
