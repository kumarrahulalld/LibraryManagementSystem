using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    public partial class remove_user : Form
    {
        string path = @"C:\";
        string c = "";
        public remove_user()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form20");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            head.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("select_user").InnerText;
            remove_button.Text = nodeList[0].SelectSingleNode("remove_button").InnerText;
        
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            OleDbConnection conn = new OleDbConnection(c);
            OleDbCommand cmd = new OleDbCommand();
            cmd.CommandText = "SELECT * FROM [User]";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox1.Items.Add(reder["user_id"].ToString());
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

        private void login_button_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "")
                MessageBox.Show("Please Choose A User.");
            else
            {
                OleDbConnection conn = new OleDbConnection(c);
                OleDbCommand cmd = new OleDbCommand();
                cmd.CommandText = "DELETE FROM [User] WHERE user_id='" + comboBox1.Text + "'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    if (cmd.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("User Deletion Successfully.");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("Admin Deleted User:-{0}  At {1}.", comboBox1.Text, DateTime.Now.ToString("HH/mm/ss"));
                        }
                    }
                    else
                        MessageBox.Show("Can't delete User Now.");
                }
#pragma warning disable CS0168 // The variable 'exp' is declared but never used
                catch (Exception exp)
#pragma warning restore CS0168 // The variable 'exp' is declared but never used
                {
                    MessageBox.Show("Can't Process Now.");
                }
            }
        }
    }
}
