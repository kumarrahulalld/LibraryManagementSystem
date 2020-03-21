using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Library
{
    public partial class Pwdmgmt : Form
    {
        static string c = "";
        string path = @"C:\";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        string ml = "";
        string pwd = "";
        public Pwdmgmt()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void Pwdmgmt_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form25");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("search_user_type").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("search_user_sem").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("search_user_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("search_user_task").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("find_button").InnerText;

            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
            nodeList = doc.SelectNodes("form/email_info");
            ml = nodeList[0].SelectSingleNode("email").InnerText;
            pwd = nodeList[0].SelectSingleNode("password").InnerText;
        }
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            if (comboBox3.SelectedIndex == 1)
            {
                comboBox2.Visible = false;
                cmd.CommandText = "SELECT * FROM [Teacher] ORDER BY teacher_name";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox1.Items.Add(reder["teacher_name"].ToString());
                        }
                    }
                    else
                    {
                        comboBox2.Visible = true;
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }

                    //                listBox1.DataSource = reder;


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Connect To Database" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Student] WHERE student_semester = '" + (comboBox2.SelectedIndex + 1) + "' and status='y'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox1.Items.Add(reder["student_name"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }

                //                listBox1.DataSource = reder;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Connect To Database" + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Type is Not Selected .");
            }
            else if (comboBox3.SelectedIndex == 1)
            {

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Name is Not Selected .");
                }
                else if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Task is Not Selected .");
                }
                else
                {
                    string p = "";
                    cmd.CommandText = "SELECT password FROM [Teacher] WHERE teacher_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'";
                    cmd.Connection = conn;
                    try
                    {

                        conn.Open();
                        p = cmd.ExecuteScalar().ToString();
                        if (comboBox4.SelectedIndex == 0)
                        {
                            string sub = "CCE Libraary Password Recovery";
                            string body = "Dear " + comboBox1.Text + " Your Password Is " + p + "For Issuing Books From Library.";
                            cmd.CommandText = "SELECT contact FROM [Teacher] WHERE teacher_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'";

                            string to = cmd.ExecuteScalar().ToString();


                            MailMessage msg = new MailMessage();
                            msg.From = new MailAddress(ml);

                            msg.To.Add(to);
                            msg.Subject = sub;
                            msg.Body = body;

                            SmtpClient smt = new SmtpClient();
                            smt.Host = "smtp.gmail.com";
                            System.Net.NetworkCredential ntcd = new NetworkCredential();
                            ntcd.UserName = ml;
                            ntcd.Password = pwd;
                            smt.Credentials = ntcd;
                            smt.EnableSsl = true;
                            smt.Port = 587;
                            smt.Send(msg);

                            MessageBox.Show("Mail Containig Password Has Been Sent.");
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("Email Sended to {0} To Recover Password.", comboBox1.Text);
                            }

                        }
                        else
                        {
                            passwordBox ps = new passwordBox();
                            string pre = ps.Show("Enter Previous Password", "Enter Password");


                            if (pre == "")
                            {
                                MessageBox.Show("Password Field is Empty.");
                            }
                            else if (pre.Length != 8)
                            {
                                MessageBox.Show("Password Length Should be 8.");
                            }
                            else if (pre == p)
                            {
                                passwordBox ne = new passwordBox();
                                string n = ne.Show("Enter New Password", "Enter Password");
                                if (n == "")
                                {
                                    MessageBox.Show("Password Field is Empty.");
                                }
                                else if (n.Length != 8)
                                {
                                    MessageBox.Show("Password Length Should be 8.");
                                }
                                else
                                {
                                    cmd.CommandText = "UPDATE [Teacher] SET [password]='" + n + "'where teacher_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'";
                                    cmd.Connection = conn;
                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Password Successfully Changed.");
                                        comboBox1.ResetText();
                                        comboBox2.ResetText();
                                        comboBox3.ResetText();
                                        comboBox4.ResetText();
                                    }
                                    else
                                    {

                                        MessageBox.Show("Password Can't be  Changed Now.");

                                    }
                                }
                            }
                            else
                            {

                                MessageBox.Show("Password is Invalid.");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to Connect To Database" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }

                }
            }
            else
            {

                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Name is Not Selected .");
                }
                else if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Task is Not Selected .");
                }
                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Semester is Not Selected .");
                }
                else
                {
                    string p = "";
                    cmd.CommandText = "SELECT password FROM [Student] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and student_semester='" + comboBox2.Text + "'";
                    cmd.Connection = conn;
                    try
                    {

                        conn.Open();
                        p = cmd.ExecuteScalar().ToString();
                        if (comboBox4.SelectedIndex == 0)
                        {
                            string sub = "CCE Libraary Password Recovery";
                            string body = "Dear " + comboBox1.Text + " Your Password Is " + p + "For Issuing Books From Library.";
                            cmd.CommandText = "SELECT contact FROM [Student] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and student_semester='" + comboBox2.Text + "'";

                            string to = cmd.ExecuteScalar().ToString();


                            MailMessage msg = new MailMessage();
                            msg.From = new MailAddress(ml);

                            msg.To.Add(to);
                            msg.Subject = sub;
                            msg.Body = body;

                            SmtpClient smt = new SmtpClient();
                            smt.Host = "smtp.gmail.com";
                            System.Net.NetworkCredential ntcd = new NetworkCredential();
                            ntcd.UserName = ml;
                            ntcd.Password = pwd;
                            smt.Credentials = ntcd;
                            smt.EnableSsl = true;
                            smt.Port = 587;
                            smt.Send(msg);

                            MessageBox.Show("Mail Containig Password Has Been Sent.");
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("Email Sended to {0} To Recover Password.", comboBox1.Text);
                            }
                        }
                        else
                        {
                            passwordBox ps = new passwordBox();
                            string pre = ps.Show("Enter Previous Password", "Enter Password");


                            if (pre == "")
                            {
                                MessageBox.Show("Password Field is Empty.");
                            }
                            else if (pre.Length != 8)
                            {
                                MessageBox.Show("Password Length Should be 8.");
                            }
                            else if (pre == p)
                            {
                                passwordBox ne = new passwordBox();
                                string n = ne.Show("Enter New Password", "Enter Password");
                                if (n == "")
                                {
                                    MessageBox.Show("Password Field is Empty.");
                                }
                                else if (n.Length != 8)
                                {
                                    MessageBox.Show("Password Length Should be 8.");
                                }
                                else
                                {
                                    cmd.CommandText = "UPDATE [Student] SET [password]='" + n + "'where student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and student_semester='" + comboBox2.Text + "'";
                                    cmd.Connection = conn;
                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        MessageBox.Show("Password Successfully Changed.");
                                        comboBox1.ResetText();
                                        comboBox2.ResetText();
                                        comboBox3.ResetText();
                                        comboBox4.ResetText();
                                    }
                                    else
                                    {

                                        MessageBox.Show("Password Can't be  Changed Now.");

                                    }
                                }
                            }
                            else
                            {

                                MessageBox.Show("Password is Invalid.");

                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Unable to Connect To Database" + ex.Message);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }
    }
    class passwordBox
    {
        private Form frm;
        public string Show(string prompt, string title)
        {
            frm = new Form();
            FlowLayoutPanel FL = new FlowLayoutPanel();
            Label lbl = new Label();
            TextBox txt = new TextBox();
            Button ok = new Button();
            Button cancel = new Button();

            frm.Font = new Font("Calibri", 9, FontStyle.Bold);
            frm.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            frm.StartPosition = FormStartPosition.CenterScreen;
            frm.Width = 200;
            frm.Height = 200;

            frm.Text = title;
            lbl.Text = prompt;
            ok.Text = "Ok";
            cancel.Text = "Cancel";
            txt.PasswordChar = '*';

            ok.FlatStyle = FlatStyle.Flat;
            ok.BackColor = SystemColors.ButtonShadow;
            ok.ForeColor = SystemColors.ButtonHighlight;
            ok.Cursor = Cursors.Hand;

            cancel.FlatStyle = FlatStyle.Flat;
            cancel.BackColor = SystemColors.ButtonShadow;
            cancel.ForeColor = SystemColors.ButtonHighlight;
            cancel.Cursor = Cursors.Hand;

            FL.Left = 0;
            FL.Top = 0;
            FL.Width = frm.Width;
            FL.Height = frm.Height;
            FL.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top;
            FL.Padding = new Padding(10);
            FL.FlowDirection = FlowDirection.TopDown;

            ok.Width = FL.Width - 35;
            txt.Width = ok.Width;
            cancel.Width = ok.Width;
            lbl.Width = ok.Width;

            ok.Click += new System.EventHandler(okClick);
            cancel.Click += new System.EventHandler(cancelClick);
            txt.KeyPress += new KeyPressEventHandler(txtEnter);

            FL.Controls.Add(lbl);
            FL.Controls.Add(txt);
            FL.Controls.Add(ok);
            FL.Controls.Add(cancel);
            frm.Controls.Add(FL);

            frm.ShowDialog();
            DialogResult DR = frm.DialogResult;
            frm.Dispose();
            frm = null;
            if (DR == DialogResult.OK)
            {
                return txt.Text;
            }
            else
            {
                return "";
            }
        }
        private void okClick(object sender, System.EventArgs e)
        {
            frm.DialogResult = DialogResult.OK;
            frm.Close();
        }
        private void cancelClick(object sender, System.EventArgs e)
        {
            frm.DialogResult = DialogResult.Cancel;
            frm.Close();
        }
        private void txtEnter(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13) { okClick(null, null); }
        }
    }
}
