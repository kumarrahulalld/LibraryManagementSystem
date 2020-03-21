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
namespace Library
{
    public partial class Form12 : Form
    {
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Form12()
        {
            InitializeComponent();
        }

        private void Form12_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form12");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("search_user_type").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("search_user_sem").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("search_user_name").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("search_user_status").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("find_button").InnerText;
            
             nodeList = doc.SelectNodes("form/connection");
            c= nodeList[0].SelectSingleNode("str").InnerText;
             conn = new OleDbConnection(c);
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
            if(comboBox3.SelectedIndex==-1)
            {
                MessageBox.Show("Type is Not Selected .");
            }
            else if(comboBox3.SelectedIndex==1)
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Name is Not Selected .");
                }
                else if (comboBox4.SelectedIndex == -1)
                {
                    MessageBox.Show("Status is Not Selected .");
                }
                else
                {
                    string d = "00/00/0000";
                    if (comboBox4.SelectedIndex == 0)
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'";
                    }
                    else if (comboBox4.SelectedIndex == 1)
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and [return_date]='"+ d +"'";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and [return_date]<>'"+ d +"'";

                    }
                    cmd.Connection = conn;
                    try
                    {

                        conn.Open();
                        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                        System.Data.DataTable dt = new System.Data.DataTable();

                        ad.Fill(dt);

                        dataGridView1.DataSource = dt;


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
            else
            {
                if (comboBox1.SelectedIndex == -1)
                {
                    MessageBox.Show("Name is Not Selected .");
                }
                else if (comboBox2.SelectedIndex == -1)
                {
                    MessageBox.Show("Semester is Not Selected .");
                }
                else
                {
                    string d = "00/00/0000";
                    if (comboBox4.SelectedIndex == 0)
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and student_semester='" + comboBox2.Text + "'";
                    }
                    else if (comboBox4.SelectedIndex == 1)
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and [return_date]='"+d+"'and [student_semester]='" + comboBox2.Text+"'";
                    }
                    else
                    {
                        cmd.CommandText = "SELECT * FROM [Allocation] WHERE student_name='" + comboBox1.GetItemText(comboBox1.SelectedItem) + "'and [return_date]<>'"+d+"'and [student_semester]='" + comboBox2.Text + "'";

                    }
                    cmd.Connection = conn;
                    try
                    {

                        conn.Open();
                        OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                        System.Data.DataTable dt = new System.Data.DataTable();

                        ad.Fill(dt);

                        dataGridView1.DataSource = dt;


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
        }
    }
}
