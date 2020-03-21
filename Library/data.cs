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
    public partial class data : Form
    {
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public data()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form21");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("select_table").InnerText;
           
            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Please Select A Table");
            else if (comboBox1.SelectedIndex == 0)
            {
                cmd.CommandText = "SELECT * FROM [Student]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else if (comboBox1.SelectedIndex == 1)
            {
                cmd.CommandText = "SELECT * FROM [User]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else if (comboBox1.SelectedIndex == 1)
            {
                cmd.CommandText = "SELECT * FROM [Allocation]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else if (comboBox1.SelectedIndex == 2)
            {
                cmd.CommandText = "SELECT * FROM [Book]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else if (comboBox1.SelectedIndex == 3)
            {
                cmd.CommandText = "SELECT * FROM [Purchase]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else if (comboBox1.SelectedIndex == 4)
            {
                cmd.CommandText = "SELECT * FROM [Legacy]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
            else
            {
                cmd.CommandText = "SELECT * FROM [Quick]";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                    System.Data.DataTable dt = new System.Data.DataTable();

                    ad.Fill(dt);

                    dataGridView1.DataSource = dt;
                    dataGridView1.Visible = true;
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
