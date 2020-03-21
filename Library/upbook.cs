using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
    public partial class upbook : Form
    {
        string path = @"C:\";
        string id = "";
        static string c = "";
        OleDbConnection conn; //= new OleDbConnection(c);
        OleDbCommand cmd;//= new OleDbCommand();
        public upbook()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";

            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            nodeList = doc.SelectNodes("form/form24");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label8.Text = nodeList[0].SelectSingleNode("book_label").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("id_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("name_label").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("tid_label").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("author_label").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("publisher_label").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("update_button").InnerText;
            conn = new OleDbConnection(c);
            cmd = new OleDbCommand();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_name='" + comboBox2.Text + "'and book_id='" + comboBox1.Text + "'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {
                    reder.Read();

                    textBox1.Text = reder["book_name"].ToString();
                    textBox2.Text = reder["book_id"].ToString();
                    textBox3.Text = reder["book_author"].ToString();
                    textBox4.Text = reder["book_publisher"].ToString();
                    id = reder["ID"].ToString();
                    tableLayoutPanel1.Visible = true;
                    reder.Close();

                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }

                //                comboBox4.DataSource = reder;


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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_name='" + comboBox2.Text + "'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox1.Items.Add(reder["book_id"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }

                //                comboBox4.DataSource = reder;


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

        private void upbook_Load(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT Distinct book_name FROM [Book]";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox2.Items.Add(reder["book_name"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }

                //                comboBox4.DataSource = reder;


            }
            catch (Exception ex)
            {
                MessageBox.Show("Unable to Connect To Database.." + ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name Field is Empty.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Id Field is Empty.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Author Field is Empty.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Publisher Field is Empty.");
            }
            else
            {
                cmd.CommandText = "UPDATE [Book] SET book_name='" + textBox1.Text + "',book_id='" + textBox2.Text + "',book_author='" + textBox3.Text + "',book_publisher='"+textBox4.Text+"'WHERE ID=" + id;
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("Record Successfully Updated.");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("Book:-{0} With Id {1} Record Updated And Setted To Name={2},Id={3},Author={4},Publisher={5}.", comboBox2.Text, comboBox1.Text, textBox1.Text, textBox2.Text, textBox3.Text,textBox4.Text);
                        }
                        textBox1.Text = "";
                        textBox2.Text = "";
                        textBox3.Text = "";
                        tableLayoutPanel1.Visible = false;
                    }
                    else
                    {
                        MessageBox.Show("Can't Update record Now.");
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
