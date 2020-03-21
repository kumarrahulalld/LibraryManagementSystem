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
    public partial class Form5 : Form
    {string path = @"C:\";
        string c = "";
        public Form5()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[a-zA-Z ]+$");
            if(textBox1.Text=="" && textBox2.Text=="" && textBox4.Text=="")
            {
                MessageBox.Show("Input Fields Can't be Blank");
            }
            else if(textBox1.Text=="")
            {
                MessageBox.Show("Book Name Field Can't be Blank");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Book Author Field Can't be Blank");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Book Publisher Field Can't be Blank");
            }
            else if (!r.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Only Alphabets Are Allowed in Book Name Field");
            }
            else if (!r.IsMatch(textBox2.Text))
            {
                MessageBox.Show("Only Alphabets Are Allowed in Book Author Field");
            }
            else if (!r.IsMatch(textBox4.Text))
            {
                MessageBox.Show("Only Alphabets Are Allowed in Book Publisher Field");
            }
            else
            {
                textBox1.ReadOnly=true;
                textBox2.ReadOnly = true;
                textBox4.ReadOnly = true;
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "INSERT INTO [Purchase] (book_name, book_author, book_publisher,book_quantity)VALUES('"+textBox1.Text+"','"+textBox2.Text+"','"+textBox4.Text+"','"+ numericUpDown1.Value+"')";

                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if(cmd.ExecuteNonQuery()>0)
                    {
                        MessageBox.Show("Book Purchase Request Saved Succesfully");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("User Raised A Request To Purchase New Book With Name {0} Author {1} Publisher {2} And Quanity {3}.",textBox1.Text,textBox2.Text,textBox4.Text,numericUpDown1.Value);
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox4.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("Can't Add Purchase Request Try Again !");
                    }

                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("Unable to Connect To Database");
                }
                finally
                {
                    conn.Close();
                }
                
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form5");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("purchase_book_name").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("purchase_book_author").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("purchase_book_publisher").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("purchase_book_quantity").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("purchase_button").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("cancel_button").InnerText;
          
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
        }
    }
}
