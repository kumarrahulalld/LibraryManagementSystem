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
    public partial class Form11 : Form
    {
        string path = @"C:\";
        string c = "";
        public Form11()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
            OleDbConnection conn = new OleDbConnection(c);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT distinct book_subject FROM [Book]";

            cmd.Connection = conn;
            try
            {
                comboBox1.Items.Add("Other");
                conn.Open();
                OleDbDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        comboBox1.Items.Add(read["book_subject"].ToString());
                    }
                }
                read.Close();
                conn.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Unable to connect"+e.Message);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            comboBox1.Items.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            System.Text.RegularExpressions.Regex r = new System.Text.RegularExpressions.Regex("^[a-zA-Z ]+$");
            if (textBox1.Text == "" && textBox2.Text == "" && textBox3.Text=="" && textBox4.Text == "")
            {
                MessageBox.Show("Input Fields Can't be Blank");
            }
            else if (textBox1.Text == "")
            {
                MessageBox.Show("Book Name Field Can't be Blank");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Book Author Field Can't be Blank");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Book Publisher Field Can't be Blank");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Book Id Field Can't be Blank");
            }
            else if (comboBox1.Text == "")
            {
                MessageBox.Show("Book Subject Field Can't be Blank");
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
                textBox1.ReadOnly = true;
                textBox2.ReadOnly = true;
                textBox3.ReadOnly = true;
                textBox4.ReadOnly = true;
                OleDbConnection conn = new OleDbConnection(c);
                
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT count (*) as cnt FROM [Book] WHERE book_id = '" + textBox3.Text + "'";

                cmd.Connection = conn;
                try
                {
                    string No = "No";
                    conn.Open();
                    if (cmd.ExecuteScalar().ToString() != "1")
                    {
                        cmd.CommandText = "INSERT INTO [Book] (book_name, book_author, book_publisher,book_id,book_subject,book_allocation)VALUES('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox4.Text + "','" + textBox3.Text + "','"+comboBox1.Text+"','"+No+"')";
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            MessageBox.Show("Book Added Succesfully");
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("User Added A Book To Database With Name {0} And Id {0} Author {2} Publisher {3}.",textBox1.Text,textBox3.Text,textBox2.Text,textBox4.Text);
                            }
                            textBox1.Text = "";
                            textBox2.Text = "";
                            textBox4.Text = "";
                            textBox3.Text = "";
                            comboBox1.Items.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Can't Add Book Now Try Again!.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Book Already Exists With This Book Id.");
                        textBox3.Text = "";
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

        private void Form11_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form11");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("register_book_name").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("register_book_author").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("register_book_publisher").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("register_book_id").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("register_book_subject").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("register_button").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("cancel_button").InnerText;
         
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            OleDbConnection conn = new OleDbConnection(c);

            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT distinct book_subject FROM [Book]";

            cmd.Connection = conn;
            try
            {
              
                conn.Open();
                OleDbDataReader read = cmd.ExecuteReader();
                if (read.HasRows)
                {
                    while (read.Read())
                    {
                        comboBox1.Items.Add(read["book_subject"].ToString());
                    }
                }
                read.Close();
                conn.Close();
            }
            catch (Exception ex)
            {
                
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
