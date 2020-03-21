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
    public partial class upstu : Form
    {
        string path = @"C:\";
        string id = "";
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public upstu()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";

            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
             nodeList = doc.SelectNodes("form/form23");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label8.Text = nodeList[0].SelectSingleNode("sem_label").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("stu_name_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("name_label").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("semester_label").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("contact_label").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("status_label").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("update_button").InnerText;
            conn = new OleDbConnection(c);
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            cmd.CommandText = "SELECT * FROM [Student] WHERE student_name='"+comboBox1.Text+"'and student_semester='"+comboBox2.Text+"'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {
                    reder.Read();
                   
                    textBox1.Text= reder["student_name"].ToString();
                    textBox2.Text = reder["student_semester"].ToString();
                    textBox3.Text = reder["contact"].ToString();
                    textBox4.Text = reder["status"].ToString();
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
            cmd.CommandText = "SELECT * FROM [Student] WHERE student_semester='"+ comboBox2.Text+"'";
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Name Field is Empty.");
            }
            else if (textBox2.Text == "")
            {
                MessageBox.Show("Semester Field is Empty.");
            }
            else if (textBox3.Text == "")
            {
                MessageBox.Show("Contact Field is Empty.");
            }
            else if (textBox4.Text == "")
            {
                MessageBox.Show("Status Field is Empty.");
            }
            else if (textBox4.Text.ToLower()!= "n" && textBox4.Text.ToLower() != "y")
            {
                MessageBox.Show("Only Y Or N Are Allowed in Status Field.");
            }
            else
            {
                int v = Convert.ToInt32(textBox2.Text);
                if(v>0&&v<7)
                {
                    int d = textBox3.Text.LastIndexOf('@');
                    int a = textBox3.Text.LastIndexOf('.');
                    if (d < 1)
                        MessageBox.Show("Invalid Email Address.");
                    else if (d == -1 || a == -1)
                        MessageBox.Show("Invalid Email Address");
                    else if (a >= textBox3.Text.Length - 2)
                        MessageBox.Show("Invalid Email Address");
                    else if (a - d < 2)
                        MessageBox.Show("Invalid Email Address");
                    else
                    {
                        cmd.CommandText = "UPDATE [Student] SET student_name='"+textBox1.Text+"',student_semester='"+textBox2.Text+"',contact='"+textBox3.Text+ "',status='" + textBox4.Text + "'WHERE ID=" + id;
                        cmd.Connection = conn;
                        try
                        {

                            conn.Open();
                            if(cmd.ExecuteNonQuery()!=0)
                            {
                                MessageBox.Show("Record Successfully Updated.");
                                using (var tw = new StreamWriter(path, true))
                                {

                                    tw.WriteLine("Student:-{0} of Semester {1} Record Updated And Setted To Name={2},Semester={3},contact={4},Status={5}.",comboBox2.Text,comboBox1.Text,textBox1.Text,textBox2.Text,textBox3.Text,textBox4.Text);
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
                else
                {
                    MessageBox.Show("Invalid Semester.");
                }
            }
        }
    }
}
