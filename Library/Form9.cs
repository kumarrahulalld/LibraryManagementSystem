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
    public partial class Form9 : Form
    {
        string path = @"C:\";
        string i = "";
        string c = "";
        public Form9()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Field Can't be Blank.");
            }
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "SELECT count (*) as cnt FROM [Book] WHERE book_id = '" + textBox1.Text + "'";
                cmd.Connection = conn;
                OleDbDataReader read=null;
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
                        cmd.CommandText = "SELECT book_allocation FROM [Book] WHERE book_id = '" + textBox1.Text + "'";
                        if (cmd.ExecuteScalar().ToString() == "No")
                        {
                            MessageBox.Show("Book Is Not Allocated Now Can't Return.");
                        }
                        else
                        {
                            textBox1.ReadOnly = true;
                            cmd.CommandText = "SELECT * FROM [Allocation] WHERE book_id = '" + textBox1.Text + "' AND return_date='00/00/0000'";
                             read = cmd.ExecuteReader();
                            if (read.Read())
                            {
                                i = read[0].ToString();
                                label3.Text = read[4].ToString();
                                label4.Text = read[1].ToString();
                                label7.Text = read[3].ToString();
                                //label9.Text = read[4].ToString();
                                label11.Text = read[6].ToString();
                                label12.Text = read[7].ToString();
                               
                            }
                            tableLayoutPanel1.Visible = true;
                            button2.Visible = true;
                            
                        }

                    }

                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    MessageBox.Show("Unable to Connect To Database"+ex.Message);
                }
                finally
                {
                    conn.Close();
                    read.Close();


                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string []a=new string[8];
            OleDbConnection conn = new OleDbConnection();
            conn.ConnectionString = c;
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = " UPDATE [Book] SET book_allocation = 'No' WHERE book_id = '" + textBox1.Text + "'";
            cmd.Connection = conn;
            try
            {
                conn.Open();
                int x = cmd.ExecuteNonQuery();
                if (x == 1)
                {
                    String dd = System.DateTime.Now.ToString("MM/dd/yyyy");
                    int j = Convert.ToInt32(i);
                    
                    cmd.CommandText =" UPDATE [Allocation] SET return_date ='"+dd+"' WHERE ID="+j;
                    int d = cmd.ExecuteNonQuery();
                    if (d == 1)
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE ID=" + j;
                        OleDbDataReader read1 = cmd.ExecuteReader();
                        if (read1.Read())
                        {
                            a[0] = read1[1].ToString();
                            a[1] = read1[2].ToString();
                            a[2] = read1[3].ToString();
                            a[3] = read1[4].ToString();
                            a[4] = read1[5].ToString();
                            a[5] = read1[6].ToString();
                        }
                        read1.Close();
                        string dt = System.DateTime.Now.ToString("MM/dd/yyyy");
                        cmd.CommandText = "INSERT INTO [LEGACY] (book_id,book_name,student_name,student_sem,issue_date,return_date) VALUES('"+a[0]+ "','" + a[1] + "','" + a[2] + "','" + a[3] + "','" + a[4] + "','" +dt+ "')";
                        if(cmd.ExecuteNonQuery()==1)
                            MessageBox.Show("Book Return Successfull");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("User Collected A Book With Name {0} And Id {1} From Student {2}.",label7.Text,label4.Text,label3.Text);
                        }
                        textBox1.Text = "";
                        tableLayoutPanel1.Visible = false;button2.Visible = false;
                    }
                }
                else
                {
                    MessageBox.Show("Can't Process Now Try Later!.");
                }

            }
            catch(Exception ec)
            {
                MessageBox.Show("Unable to Connect DataBase"+ec.Message);
            }
            finally
            {
                conn.Close();
               
            }
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form9");
            groupBox1.Text = nodeList[0].SelectSingleNode("return_area").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("enter_id").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("find_button").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("details_stu_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("details_book_id").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("details_book_name").InnerText;
            label10.Text = nodeList[0].SelectSingleNode("details_issue_date").InnerText;
            label13.Text = nodeList[0].SelectSingleNode("details_due_date").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("return_button").InnerText;
       
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
        }
    }
}
