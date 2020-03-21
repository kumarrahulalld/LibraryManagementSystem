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
    public partial class Form13 : Form
    {
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Form13()
        {
          
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form13");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("select_book_name").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("find_button").InnerText;

            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
            cmd.CommandText = "SELECT DISTINCT book_name FROM [Book]";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox3.Items.Add(reder["book_name"].ToString());
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

            if (comboBox3.SelectedIndex==-1)
                MessageBox.Show("Please Select the book name");
            else
            {

                cmd.CommandText = "SELECT * FROM [Book] WHERE book_name='" + comboBox3.GetItemText(comboBox3.SelectedItem) + "'";
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

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form13_Load(object sender, EventArgs e)
        {
           
        }
    }
}
