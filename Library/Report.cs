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
    public partial class Report : Form
    {
        string path = @"C:\";
        static string c = "";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        public Report()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt;
                cmd.CommandText = "SELECT * FROM Allocation";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd.CommandText, conn))
                {
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                }
                System.IO.StreamWriter wr = new System.IO.StreamWriter(@"C:\\Allocation.xlsx");
                // Write Columns to excel file
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }
                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    wr.WriteLine();
                }
                wr.Close();
                MessageBox.Show("Excel File Has Been Saved To C:Drive.");
                using (var tw = new StreamWriter(path, true))
                {

                    tw.WriteLine("Transaction Excel Report Generated.");
                }
            }
            catch(Exception ep)
            {
                MessageBox.Show("Some Error Occured." + ep.Message);
            }
            finally
            {
                conn.Close();
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt;
                cmd.CommandText = "SELECT * FROM Book";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd.CommandText, conn))
                {
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                }
                System.IO.StreamWriter wr = new System.IO.StreamWriter(@"C:\\Books.xls");
                // Write Columns to excel file
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }
                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    wr.WriteLine();
                }
                wr.Close();
                MessageBox.Show("Excel File Has Been Saved To C:Drive.");
                using (var tw = new StreamWriter(path, true))
                {

                    tw.WriteLine("Books Excel Report Generated.");
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show("Some Error Occured." + ep.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt;
                cmd.CommandText = "SELECT * FROM Student";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd.CommandText, conn))
                {
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                }
                System.IO.StreamWriter wr = new System.IO.StreamWriter(@"C:\\Students.xls");
                // Write Columns to excel file
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }
                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    wr.WriteLine();
                }
                wr.Close();
                MessageBox.Show("Excel File Has Been Saved To C:Drive.");
                using (var tw = new StreamWriter(path, true))
                {

                    tw.WriteLine("Student Excel Report Generated.");
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show("Some Error Occured." + ep.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                System.Data.DataTable dt;
                cmd.CommandText = "SELECT * FROM Purchase";
                using (OleDbDataAdapter dataAdapter = new OleDbDataAdapter(cmd.CommandText, conn))
                {
                    dt = new System.Data.DataTable();
                    dataAdapter.Fill(dt);
                }
                System.IO.StreamWriter wr = new System.IO.StreamWriter(@"C:\\Purchase.xls");
                // Write Columns to excel file
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    wr.Write(dt.Columns[i].ToString().ToUpper() + "\t");
                }
                wr.WriteLine();
                //write rows to excel file
                for (int i = 0; i < (dt.Rows.Count); i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (dt.Rows[i][j] != null)
                        {
                            wr.Write(Convert.ToString(dt.Rows[i][j]) + "\t");
                        }
                        else
                        {
                            wr.Write("\t");
                        }
                    }
                    wr.WriteLine();
                }
                wr.Close();
                MessageBox.Show("Excel File Has Been Saved To C:Drive.");
                using (var tw = new StreamWriter(path, true))
                {

                    tw.WriteLine("Purchase Excel Report Generated.");
                }
            }
            catch (Exception ep)
            {
                MessageBox.Show("Some Error Occured." + ep.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        private void Report_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form16");
            label1.Text = nodeList[0].SelectSingleNode("transaction_report_label").InnerText;
            label2.Text = nodeList[0].SelectSingleNode("book_report_label").InnerText;
            label3.Text = nodeList[0].SelectSingleNode("student_report_label").InnerText;
            label4.Text = nodeList[0].SelectSingleNode("purchase_report_label").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("transaction_report_button").InnerText;
            button2.Text = nodeList[0].SelectSingleNode("book_report_button").InnerText;
            button3.Text = nodeList[0].SelectSingleNode("student_report_button").InnerText;
            button4.Text = nodeList[0].SelectSingleNode("purchase_report_button").InnerText;
           
             nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }
    }
}
