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
    public partial class admin_panel : Form
    {

        string c = "";
        public static int a = 1;
        public admin_panel()
        {
            InitializeComponent();
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form18");
            title.Text = nodeList[0].SelectSingleNode("form_name").InnerText;
            label1.Text = nodeList[0].SelectSingleNode("welcome_message").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("book_panel_head").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("user_panel_head").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("student_panel_head").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("teacher_panel_head").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("purchase_panel_head").InnerText;
            label7.Text = nodeList[0].SelectSingleNode("today_panel_head").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("user_button").InnerText;
            button3.Text = nodeList[0].SelectSingleNode("report_button").InnerText;
            button4.Text = nodeList[0].SelectSingleNode("data_button").InnerText;
            button5.Text = nodeList[0].SelectSingleNode("record_button").InnerText;
            email_button.Text = nodeList[0].SelectSingleNode("mail_button").InnerText;
            button6.Text = nodeList[0].SelectSingleNode("add_user_button").InnerText;
            button7.Text = nodeList[0].SelectSingleNode("remove_user_button").InnerText;
            button8.Text = nodeList[0].SelectSingleNode("find_stu_button").InnerText;
            button9.Text = nodeList[0].SelectSingleNode("find_book_button").InnerText;

            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
           

            OleDbConnection conn = new OleDbConnection(c);
            
            OleDbCommand cmd = new OleDbCommand();

            cmd.CommandText = "SELECT count (*) FROM [User]";

            cmd.Connection = conn;
            try
            {

                conn.Open();
                label9.Text = cmd.ExecuteScalar().ToString();
                progressBar2.Value = Convert.ToInt32(label9.Text);
                cmd.CommandText = "SELECT count (*) FROM [Book]";
                label8.Text = cmd.ExecuteScalar().ToString();
                progressBar1.Value = Convert.ToInt32(label8.Text);
                cmd.CommandText = "SELECT count (*) FROM [Teacher]";
                label10.Text = cmd.ExecuteScalar().ToString();
                progressBar6.Value = Convert.ToInt32(label10.Text);
                cmd.CommandText = "SELECT count (*) FROM [Student]";
                label13.Text = cmd.ExecuteScalar().ToString();
                progressBar3.Value = Convert.ToInt32(label13.Text);
                cmd.CommandText = "SELECT count (*) FROM [Purchase]";
                label12.Text = cmd.ExecuteScalar().ToString();
                progressBar4.Value = Convert.ToInt32(label12.Text);
                cmd.CommandText = "SELECT count (*) FROM [Allocation] WHERE issue_date='"+DateTime.Now.ToString("MM/dd/yy")+ "'OR return_date='" + DateTime.Now.ToString("MM/dd/yy") + "'";
                label11.Text = cmd.ExecuteScalar().ToString();
                progressBar5.Value = Convert.ToInt32(label11.Text);
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.ShowDialog();
            
        }

        private void button9_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            f.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel10.Visible = true;
            button6.Visible = true;
            button7.Visible = true;
            button8.Visible = false;
            button9.Visible = false;

        }


        private void button4_Click(object sender, EventArgs e)
        {

            data d = new data();
            d.ShowDialog();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            button8.Visible = true;
            button9.Visible = true;
            button6.Visible = false;
            button7.Visible = false;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            f.ShowDialog();
        }


        private void button6_Click(object sender, EventArgs e)
        {
            add_user a = new add_user();
            a.ShowDialog();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            remove_user r = new remove_user();
            r.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button16_Click(object sender, EventArgs e)
        {
            a++;
            if (a % 2 == 0)
                panel2.Visible = true;
            else
                panel2.Visible = false;
        }

        private void email_Click(object sender, EventArgs e)
        {
            email em = new email();
            em.ShowDialog();
        }

        private void admin_panel_Load(object sender, EventArgs e)
        {
           


        }

        private void button10_Click(object sender, EventArgs e)
        {
            Pwdmgmt p = new Pwdmgmt();
            p.ShowDialog();
        }
    }
}
