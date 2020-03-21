using System;
using System.Data.OleDb;
using System.Windows.Forms;
using System.Xml;
namespace Library
{
    public partial class Form6 : Form
    {
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Form6()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form6");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;

            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }

        private void Form6_Load(object sender, EventArgs e)
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

        private void Form6_FormClosed(object sender, FormClosedEventArgs e)
        {
            
            Form2 f = new Form2("Hello");

        }
    }
}
