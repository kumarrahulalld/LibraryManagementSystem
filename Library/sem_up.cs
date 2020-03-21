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
    public partial class sem_up : Form
    {
        string path = @"C:\";
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public sem_up()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Student] WHERE student_semester = '" + (comboBox1.SelectedIndex + 1) + "' and status='y'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox4.Items.Add(reder["student_name"].ToString());
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

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (comboBox1.Text == "")
                MessageBox.Show("Semester is Not Selected.");
            else if (comboBox4.Text == "")
                MessageBox.Show("Name is Not Selected.");
            else
            {
                cmd.CommandText = "SELECT COUNT(*) FROM [Allocation] WHERE student_name='" + comboBox4.Text + "'AND student_semester='" + comboBox1.Text + "'";
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    if (cmd.ExecuteNonQuery() != 0)
                    {
                        MessageBox.Show("First collect all the Books From Student Only After can be Promoted.");
                    }
                    else
                    {
                        int sem = Convert.ToInt32(comboBox1.Text);
                        sem++;
                        cmd.CommandText = "UPDATE [Student] SET student_semester='" + sem + "' WHERE student_name='" + comboBox4.Text + "'AND student_semester='" + comboBox1.Text + "'";
                        cmd.Connection = conn;


                        if (cmd.ExecuteNonQuery() != 0)
                        {
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("Student:-{0} of Semester:-{1} Promoted To Semester:-{2}.", comboBox4.Text, comboBox1.Text, sem);
                            }
                            MessageBox.Show("Student Successfully Promoted.");
                        }
                        else
                            MessageBox.Show("Can't Execute Query Now.");
                    }
                }
#pragma warning disable CS0168 // The variable 'd' is declared but never used
                catch(Exception d)
#pragma warning restore CS0168 // The variable 'd' is declared but never used
                {
                    MessageBox.Show("Can't Connect To Database.");
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void sem_up_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form17");
            label1.Text = nodeList[0].SelectSingleNode("stu_sem").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("stu_name").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("promote_button").InnerText;
      
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }
    }
}
