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
    public partial class Form8 : Form
    {
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Form8()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form8");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;

            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form8");
            label1.Text = nodeList[0].SelectSingleNode("head_label").InnerText;
           
            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            // TODO: This line of code loads data into the 'testDataSet6.Book' table. You can move, or remove it, as needed.
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_allocation='No'";
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
