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
    public partial class Form1 : Form
    {
        string path = @"C:\";
        
        int attempt = 0;
        string c = "";
        
       

        public Form1()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";

            label6.Visible = false;
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form1");
            this.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            institute_name.Text = nodeList[0].SelectSingleNode("institute_name").InnerText;
            login_area.Text = nodeList[0].SelectSingleNode("groupbox_name").InnerText;
            center_name.Text = nodeList[0].SelectSingleNode("center_name").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("id_label").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("password_label").InnerText;
            login_button.Text = nodeList[0].SelectSingleNode("login_button").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("copyright").InnerText;
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;

        }

        private void user_id_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_button_Click(object sender, EventArgs e)
        {
            
            string var;
            string pass;
            var = user_id.Text;
            pass = user_password.Text;
            if (var == "" || pass == "")
                MessageBox.Show("Fields Can't Be Blank");
            else if (var.Length < 8)
            {
                MessageBox.Show("User Id Should be of Length 8");
                user_id.Text = ""; user_password.Text = "";
            }
            else if (pass.Length < 8)
            {
                MessageBox.Show("Password Should be of Length 8");
            user_id.Text = "";
                user_password.Text = "";
            }
            else
            {
                OleDbConnection conn = new OleDbConnection();
                conn.ConnectionString = c;
                OleDbCommand cmd = new OleDbCommand();

                cmd.CommandText = "SELECT count (*) FROM [User] WHERE user_id = '" + var + "' and user_password = '" + pass + "'";
                
                cmd.Connection = conn;
                    try
                    {
                   
                    conn.Open();
                    if(cmd.ExecuteScalar().ToString()!="1")
                    {
                        
                        attempt++;
                        MessageBox.Show("Invalid User Id Or Password and You Have Left Only " + (3-attempt));
                        if (attempt == 3)
                        {
                            MessageBox.Show("You Exceeded The Limit of Login");
                        }
                        user_id.Text = "";
                        user_password.Text = "";
                            
                    }
                    else
                    {
                        if (!File.Exists(path))
                        {
                            File.Create(path).Dispose();

                            using (TextWriter tw = new StreamWriter(path))
                            {
                                tw.WriteLine("Application Started.");
                                tw.WriteLine("User:-{0} Logged In At {1}.",var,DateTime.Now.ToString("HH/mm/ss"));
                            }

                        }
                        else if (File.Exists(path))
                        {
                            using (var tw = new StreamWriter(path, true))
                            {
                                
                                tw.WriteLine("User:-{0} Logged In At {1}.", var, DateTime.Now.ToString("HH/mm/ss"));
                            }
                        }
                        user_id.Text = ""; user_password.Text = "";
                        if (var == "admin123")
                        {
                            admin_panel a = new admin_panel();
                            a.ShowDialog();
                        }
                        else
                        {
                            Form2 f = new Form2(var);
                            f.ShowDialog();
                            
                            // closes the Form2 instance.
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Unable to Connect To Database"+ex.Message);
                }
                finally
                {
                    conn.Close();
                }
                    
                
                
            }

        }

        private void forget_password_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            Forgot_Password f = new Forgot_Password();
            f.ShowDialog();
            
        }

        private void institute_name_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var tw = new StreamWriter(path, true))
            {

                tw.WriteLine("Application Closed At {0}.",DateTime.Now.ToString("HH/mm/ss"));
            }
            Application.Exit();
                
        }
    }
}
