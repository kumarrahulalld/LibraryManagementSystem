using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.IO;
namespace Library
{
    public partial class Forgot_Password : Form
    {
        string path = @"C:\";
        string c = "";
        public Forgot_Password()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Id Field Can't be Blank.");
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT count (*) FROM [User] WHERE user_id = '" + textBox1.Text + "'";

                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if (cmd.ExecuteScalar().ToString() != "1")
                    {
                        MessageBox.Show("Invalid User Id Try Again.");
                    }
                    else
                    {
                        cmd.CommandText = "SELECT question FROM [User] WHERE user_id = '" + textBox1.Text + "'";
                        label3.Text= cmd.ExecuteScalar().ToString();
                        label3.Visible = true;
                        label4.Visible = true;
                        textBox2.Visible = true;
                        button2.Visible = true;
                        label2.Visible = false;
                        textBox1.Visible = false;
                        button1.Visible = false;

                    }
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Can't Connect To Database."+exc.Message);
                }
                finally
                {
                    conn.Close();
                    
                    
                }
                }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
                MessageBox.Show("Answer Field Can't be Blank.");
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT answer FROM [User] WHERE user_id = '" + textBox1.Text + "'";

                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    string a = cmd.ExecuteScalar().ToString();
                    cmd.CommandText = "SELECT user_password FROM [User] WHERE user_id = '" + textBox1.Text + "'";
                    string b = cmd.ExecuteScalar().ToString();
                    if (a!= textBox2.Text)
                    {
                        MessageBox.Show("Answer Is Incorrect. Kindly Contact Admin.");
                    }
                    else
                    {

                        label5.Text ="Your Password is :-"+b;
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("User Used Forgot Password Facility.");
                        }
                        label5.Visible = true;
                    }

                }
#pragma warning disable CS0168 // The variable 'excp' is declared but never used
                catch(Exception excp)
#pragma warning restore CS0168 // The variable 'excp' is declared but never used
                {
                    MessageBox.Show("Can't Connect To Database.");
                }
                finally
                {
                    conn.Close();
                   
                }
        }
        }

        private void Forgot_Password_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form14");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("user_id").InnerText;  
            label4.Text = nodeList[0].SelectSingleNode("user_answer").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("id_button").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("answer_button").InnerText;
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
        }
    }
}
