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
    public partial class Form4 : Form
    {
        string path = @"C:\";
        string c = "";
        public Form4()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                MessageBox.Show("Field Can't be Blank.");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT count (*) as cnt FROM [Book] WHERE book_id = '" + textBox3.Text + "'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if (cmd.ExecuteScalar().ToString() != "1")
                    {
                        MessageBox.Show("Book Doesn't Exist !.");
                        textBox3.Text = "";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT book_allocation FROM [Book] WHERE book_id = '" + textBox3.Text + "'";
                        if (cmd.ExecuteScalar().ToString() == "yes")
                        {
                            MessageBox.Show("Book Is Allocated Now Can't Delete");
                        }
                        else
                        {
                            textBox3.ReadOnly = true;
                            cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + textBox3.Text + "'";
                            OleDbDataReader read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                label9.Text = read[1].ToString();
                                label10.Text = read[2].ToString();
                                label11.Text = read[4].ToString();
                                label12.Text = read[3].ToString();

                            }
                            tableLayoutPanel1.Visible = true;
                            button1.Visible = true;
                        }

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

        private void button1_Click(object sender, EventArgs e)
        {
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = c;
            OleDbCommand cmd = new OleDbCommand();
            cmd.Connection = conn;
            cmd.CommandText = "DELETE FROM [Book] WHERE book_id = '" + textBox3.Text + "'";
            try
            {
                conn.Open();

                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Book Deleted Successfully.");
                    using (var tw = new StreamWriter(path, true))
                    {

                        tw.WriteLine("User Deleted Book {0} With Book Id {1}.",label10.Text,label9.Text);
                    }

                    textBox3.Text = "";
                    tableLayoutPanel1.Visible = false;
                    label9.Text = "Book Id";
                    label10.Text = "Book Name";
                    label11.Text = "Book Author";
                    label12.Text = "Book Publication";
                }
                else
                {
                    MessageBox.Show("Can't Be Deleted Right Now Try After Some Time");
                }
            }
#pragma warning disable CS0168 // The variable 'ex' is declared but never used
            catch(Exception ex)
#pragma warning restore CS0168 // The variable 'ex' is declared but never used
            {
                MessageBox.Show("Can't Connect To Database!.");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form4");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            groupBox1.Text = nodeList[0].SelectSingleNode("delete_area").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("enter_book_id").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("find_book_details_button").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("delete_book_id").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("delete_book_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("delete_book_author").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("delete_book_publisher").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("delete_button").InnerText;
           
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
        }
    }
}
