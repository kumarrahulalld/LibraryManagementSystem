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
    public partial class Form10 : Form
    {
        string path = @"C:\";
        string a = "";
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Form10()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") 
            {
                MessageBox.Show("Id Field Can't Be Blank");
            }
            else{
                cmd.CommandText = "SELECT count (*) as cnt FROM [Book] WHERE book_id = '" + textBox1.Text + "'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if (cmd.ExecuteScalar().ToString() != "1")
                    {
                        MessageBox.Show("Book Doesn't Exist !.");
                        textBox1.Text = "";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT book_allocation FROM [Book] WHERE book_id ='"+textBox1.Text+"'";
                        if (cmd.ExecuteScalar().ToString() == "No")
                        {
                            
                            MessageBox.Show("Book Is Not Allocated Now Can't Renew.");
                        }
                        else
                        {
                            textBox1.ReadOnly = true;
                            cmd.CommandText = "SELECT * FROM [Allocation] WHERE book_id ='"+textBox1.Text+"'AND return_date='00/00/0000'";
                            OleDbDataReader read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                a = read[0].ToString();
                                label3.Text = read[4].ToString();
                                label4.Text = read[1].ToString();
                                label7.Text = read[3].ToString();
                                label11.Text = read[6].ToString();
                                label12.Text = read[7].ToString();
                                tableLayoutPanel1.Visible = true;
                                button2.Visible = true;
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("Unable to Connect To Database" + ex.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            cmd.CommandText = "UPDATE Allocation SET due_date='" + DateTime.Now.AddDays(7).ToString("MM/dd/yyyy") + "' WHERE ID="+Convert.ToInt32(a);
            cmd.Connection = conn;
            try
            {
                conn.Open();
                if (cmd.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Book Renewal Successful For 7 Days.");
                    using (var tw = new StreamWriter(path, true))
                    {

                        tw.WriteLine("User Renewed A Book With Name {0} And Id {1} For Student {2} Till {3}.", label4.Text, label4.Text, label3.Text,label12.Text);
                    }
                }
                else
                    MessageBox.Show("Unable To Process.");
            }
#pragma warning disable CS0168 // The variable 't' is declared but never used
            catch(Exception t)
#pragma warning restore CS0168 // The variable 't' is declared but never used
            {
                MessageBox.Show("Can't Connect To Database.");
            }
            finally
            {
                conn.Close();
            }
        }

        private void Form10_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form10");
            groupBox1.Text = nodeList[0].SelectSingleNode("renew_area").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("enter_id").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("find_button").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("details_stu_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("details_book_id").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("details_book_name").InnerText;
            label10.Text = nodeList[0].SelectSingleNode("details_issue_date").InnerText;
            label13.Text = nodeList[0].SelectSingleNode("details_due_date").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("renew_button").InnerText;
         
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
             conn = new OleDbConnection(c);
        }
    }
}
