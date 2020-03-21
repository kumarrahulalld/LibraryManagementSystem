using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;
using System.Xml;
using System.Net.Mail;

namespace Library
{

    public partial class upload_data : Form
    {
        string path = @"C:\";
        static string c = "";
        Excel.Application xlApp = new Excel.Application();
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();

        string sFileName;
        int iRow, iCol = 0;
        public upload_data()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";


        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();
            int co = 0;
            OpenFileDialog1.Title = "Excel File to Edit";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Filter = "Excel File|*.xlsx;*.xls";
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sFileName = OpenFileDialog1.FileName;

                    if (sFileName.Trim() != "")
                    {
                        xlApp = new Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(sFileName);           // WORKBOOK TO OPEN THE EXCEL FILE.
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];      // NAME OF THE SHEET.
                        conn.Open();
                        
                        for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)  // START FROM THE SECOND ROW.
                        {
                            if (xlWorkSheet.Cells[iRow, 1].value == null)
                            {
                                MessageBox.Show("Book Name Field is Empty At Row" +iRow+ "And Column 1");
                                break;
                            }
                            else if (xlWorkSheet.Cells[iRow, 2].value == null)
                            {
                                MessageBox.Show("Book Id Field is Empty At Row" + iRow + "And Column 2");
                                break;
                            }
                            else if (xlWorkSheet.Cells[iRow, 3].value == null)
                            {
                                MessageBox.Show("Book Author Field is Empty At Row" + iRow + "And Column 3");
                                break;
                            }
                            else if (xlWorkSheet.Cells[iRow, 4].value == null)
                            {
                                MessageBox.Show("Book Publisher Field is Empty At Row" + iRow + "And Column 4");
                                break;
                            }
                            else if (xlWorkSheet.Cells[iRow, 5].value == null)
                            {
                                MessageBox.Show("Book Status Field is Empty At Row" + iRow + "And Column 5");
                                break;
                            }
                            else if (xlWorkSheet.Cells[iRow, 6].value == null)
                            {
                                MessageBox.Show("Book Subject is Empty At Row" + iRow + "And Column 6");
                                break;
                            }
                            else
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM [Book] WHERE book_id='" + xlWorkSheet.Cells[iRow, 2].value + "'";
                                cmd.Connection = conn;
                                if (cmd.ExecuteScalar().ToString() == "0")
                                {
                                    string b_n = (string)xlWorkSheet.Cells[iRow, 1].value;
                                    string b_id = (string)xlWorkSheet.Cells[iRow, 2].value;
                                    string b_a = (string)xlWorkSheet.Cells[iRow, 3].value;
                                    string b_p = (string)xlWorkSheet.Cells[iRow, 4].value;
                                    string b_s = (string)xlWorkSheet.Cells[iRow, 5].value;
                                    string b_sub = (string)xlWorkSheet.Cells[iRow, 6].value;
                                    string b_is = (string)xlWorkSheet.Cells[iRow, 7].value;
                                    cmd.CommandText = "INSERT INTO [Book] (book_id,book_name,book_author,book_publisher,book_allocation,book_subject,isbn_no) VALUES ('" + b_n + "','" + b_id + "','" + b_a + "','" + b_p + "','" + b_s + "','" + b_sub + "','" + b_is + "');";
                                    cmd.Connection = conn;
                                    cmd.ExecuteNonQuery();
                                    co++;
                                }
                                else
                                {
                                    MessageBox.Show("Values With Duplicate Book Id Found At Row " + iRow);
                                    break;
                                }
                            }
                           
                        }
                        MessageBox.Show("Data of "+co+"Rows Uploaded Successfully.");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("Record of {0} Books Uploaded From Excel To Database.", co);
                        }

                    }

                    xlWorkBook.Close();
                    xlApp.Quit();
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                conn.Close();
                MessageBox.Show("Data of " + co + "Rows Uploaded Successfully.");
            }
        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void upload_data_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog OpenFileDialog1 = new OpenFileDialog();

            OpenFileDialog1.Title = "Excel File to Edit";
            OpenFileDialog1.FileName = "";
            OpenFileDialog1.Filter = "Excel File|*.xlsx;*.xls";
            try
            {
                if (OpenFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    sFileName = OpenFileDialog1.FileName;

                    if (sFileName.Trim() != "")
                    {
                        xlApp = new Excel.Application();
                        xlWorkBook = xlApp.Workbooks.Open(sFileName);           // WORKBOOK TO OPEN THE EXCEL FILE.
                        xlWorkSheet = xlWorkBook.Worksheets["Sheet1"];      // NAME OF THE SHEET.
                        conn.Open();
                        for (iRow = 2; iRow <= xlWorkSheet.Rows.Count; iRow++)  // START FROM THE SECOND ROW.
                        {
                            if (xlWorkSheet.Cells[iRow, 1].value == null)
                            {
                                break;
                            }
                            
                            string b_n = xlWorkSheet.Cells[iRow, 1].value;
                            string b_id = xlWorkSheet.Cells[iRow, 2].value;
                            string b_a = xlWorkSheet.Cells[iRow, 3].value;
                            string b_stat = xlWorkSheet.Cells[iRow, 4].value;
                            string b_pass = xlWorkSheet.Cells[iRow, 5].value;
                            if (b_n == "")
                                MessageBox.Show("Student name Field is Empty At Row" + iRow);
                            else if (b_id == "")
                                MessageBox.Show("Student semester Field is Empty At Row" + iRow);
                            else if (b_a == "")
                                MessageBox.Show("Student Contact Field is Empty At Row" + iRow);
                            else if (b_stat == "")
                                MessageBox.Show("Student Status Field is Empty At Row" + iRow);
                            else if (b_pass == "")
                                MessageBox.Show("Student Password Field is Empty At Row" + iRow);
                            else if (IsValid(b_a))
                            {
                                cmd.CommandText = "SELECT COUNT(*) FROM [Student] WHERE contact='" + b_a + "'";
                                cmd.Connection = conn;
                                if (cmd.ExecuteScalar().ToString() == "0")
                                {
                                    cmd.CommandText = "INSERT INTO [Student] (student_name,student_semester,contact,status,password) VALUES ('" + b_n + "','" + b_id + "','" + b_a + "','"+b_stat+"','" + b_pass + "');";
                                    cmd.Connection = conn;


                                    cmd.ExecuteNonQuery();
                                }
                                else
                                {
                                    MessageBox.Show("Duplicate Email Found At Row " + iRow);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Email Is Not Valid At Row" + iRow);
                            }
                        }
                        MessageBox.Show("Data Uploaded Successfully.");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("Record of {0} Students Uploaded From Excel To Database.",xlWorkSheet.Rows.Count);
                        }

                    }

                    xlWorkBook.Close();
                    xlApp.Quit();
                }

            }
            catch (Exception ec)
            {
                MessageBox.Show(ec.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public bool IsValid(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);

                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
    
}
