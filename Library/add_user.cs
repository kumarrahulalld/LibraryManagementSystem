using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace Library
{
    public partial class add_user : Form
    {
        string path = @"C:\";
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public add_user()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form19");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("user_id").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("user_password").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("hint_question").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("hint_answer").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            login_button.Text = nodeList[0].SelectSingleNode("add_button").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("clear_button").InnerText;
            
           nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
        }

        private void login_button_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("User Id Field Can't be Empty.");
            else if (textBox2.Text == "")
                MessageBox.Show("User Password Field can't be Blank.");
            else if (textBox3.Text == "")
                MessageBox.Show("User Hint Question Can't be Blank.");
            else if (textBox4.Text == "")
                MessageBox.Show("User Hint Answer Can't be Blank.");
            else
            {
                if (textBox1.Text.Length < 8)
                    MessageBox.Show("User Id should be of 8 characters.");
                else if (textBox2.Text.Length < 8)
                    MessageBox.Show("User Password should be of 8 characters.");
                else if (textBox3.Text.Length < 15)
                    MessageBox.Show("User Hint Question should be of 15 characters.");
                else
                {
                    cmd.CommandText = @"INSERT INTO [User] (user_id,user_password,question,answer) VALUES ('" + textBox1.Text.ToString() + "','" + textBox2.Text.ToString() + "','" + textBox3.Text.ToString() + "','" + textBox4.Text.ToString() + "');";
                    cmd.Connection = conn;
                    try
                    {
                        conn.Open();
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("User Added Successfully.");
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("Admin Added A New User With Id {0} At {1}.",textBox1.Text,DateTime.Now.ToString("MM/dd/yyyy"));
                            }
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox3.Text = "";
                            textBox4.Text = "";
                        }
                        else
                            MessageBox.Show("Can't Process Request.");
                    }
                    catch (Exception exp)
                    {
                        MessageBox.Show("Can't Connect To Database"+exp.Message);
                    }
                }
            }

        }
    }
}
