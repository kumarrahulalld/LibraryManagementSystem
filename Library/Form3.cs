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
using Microsoft.VisualBasic;
namespace Library
{

    public partial class Form3 :Form
    {
        static string c = "";
        string path = @"C:\";
        OleDbConnection conn = new OleDbConnection(c);
            OleDbCommand cmd = new OleDbCommand();
        string i = System.DateTime.Now.ToString("MM/dd/yyyy");
        string d = System.DateTime.Now.AddDays(150).ToString("MM/dd/yyyy");
        string r = "00/00/0000";
        String td = "Book_Bank";
        string da = System.DateTime.Now.AddDays(10).ToString("MM/dd/yyyy");
        String ta = "Reference";
        public Form3()
        {
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            comboBox4.Items.Clear();
            int choice = comboBox1.SelectedIndex;
            if (choice == 0)
            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester1/subject");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; ;
                checkBox3.Text = nodeList[0].SelectSingleNode("subject3").InnerText; ;
                checkBox4.Text = nodeList[0].SelectSingleNode("subject4").InnerText; ;
                checkBox5.Text = nodeList[0].SelectSingleNode("subject5").InnerText; ;
                checkBox6.Text = nodeList[0].SelectSingleNode("subject6").InnerText; ;
                
                
                tableLayoutPanel1.Visible = true;

            }
            else if (choice == 1)
            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester2");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; ;
                checkBox3.Text = nodeList[0].SelectSingleNode("subject3").InnerText; ;
                checkBox4.Text = nodeList[0].SelectSingleNode("subject4").InnerText; ;
                checkBox5.Text = nodeList[0].SelectSingleNode("subject5").InnerText; ;
                checkBox6.Text = nodeList[0].SelectSingleNode("subject6").InnerText; ;
                tableLayoutPanel1.Visible = true;

            }
            else if (choice == 2)
            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester3");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; ;
                checkBox3.Text = nodeList[0].SelectSingleNode("subject3").InnerText; ;
                checkBox4.Text = nodeList[0].SelectSingleNode("subject4").InnerText; ;
                checkBox5.Text = nodeList[0].SelectSingleNode("subject5").InnerText; ;
                checkBox6.Text = nodeList[0].SelectSingleNode("subject6").InnerText; ;
                tableLayoutPanel1.Visible = true;

            }
            else if (choice == 3)
            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester4");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; ;
                checkBox3.Text = nodeList[0].SelectSingleNode("subject3").InnerText; ;
                checkBox4.Text = nodeList[0].SelectSingleNode("subject4").InnerText; ;
                checkBox5.Text = nodeList[0].SelectSingleNode("subject5").InnerText; ;
                checkBox6.Text = nodeList[0].SelectSingleNode("subject6").InnerText; ;
                tableLayoutPanel1.Visible = true;

            }
            else if (choice == 4)
            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester5");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; ;
                checkBox3.Text = nodeList[0].SelectSingleNode("subject3").InnerText; ;
                checkBox4.Text = nodeList[0].SelectSingleNode("subject4").InnerText; ;
                checkBox5.Text = nodeList[0].SelectSingleNode("subject5").InnerText; ;
               
                checkBox6.Visible = false;
                comboBox10.Visible = false;
                tableLayoutPanel1.Visible = true;

            }
            else

            {
                XmlNodeList nodeList = doc.SelectNodes("form/semester/semester6");
                checkBox1.Text = nodeList[0].SelectSingleNode("subject1").InnerText;
                checkBox2.Text = nodeList[0].SelectSingleNode("subject2").InnerText; 
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                checkBox3.Visible = false;
                checkBox4.Visible = false;
                checkBox5.Visible = false;
                checkBox6.Visible = false;
                comboBox7.Visible = false;
                comboBox8.Visible = false;
                comboBox9.Visible = false;
                comboBox10.Visible = false;
                tableLayoutPanel1.Visible = true;

            }
            cmd.CommandText = "SELECT * FROM [Student] WHERE student_semester = '" +(comboBox1.SelectedIndex+1)+ "' and status='y'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if(reder.HasRows)
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
                reder.Close();

//                comboBox4.DataSource = reder;
              
                
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
           
        

        private void Form3_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/form3");
            groupBox1.Text= nodeList[0].SelectSingleNode("book_bank_section").InnerText;
            label1.Text= nodeList[0].SelectSingleNode("book_bank_stu_sem").InnerText;
            label2.Text= nodeList[0].SelectSingleNode("book_bank_stu_name").InnerText;
            label3.Text= nodeList[0].SelectSingleNode("book_bank_name").InnerText;
            label4.Text= nodeList[0].SelectSingleNode("book_bank_id").InnerText;
            button2.Text= nodeList[0].SelectSingleNode("book_bank_button").InnerText;
            groupBox2.Text = nodeList[0].SelectSingleNode("reference_book_section").InnerText;
            label5.Text = nodeList[0].SelectSingleNode("reference_stu_name").InnerText;
            label6.Text = nodeList[0].SelectSingleNode("reference_stu_sem").InnerText;
            label7.Text = nodeList[0].SelectSingleNode("reference_borrow_type").InnerText;
            label16.Text = nodeList[0].SelectSingleNode("reference_book_name").InnerText;
            label17.Text = nodeList[0].SelectSingleNode("reference_book_id").InnerText;
            label8.Text = nodeList[0].SelectSingleNode("detail_book_id").InnerText;
            label9.Text = nodeList[0].SelectSingleNode("detail_book_name").InnerText;
            label10.Text = nodeList[0].SelectSingleNode("detail_book_author").InnerText;
            label11.Text = nodeList[0].SelectSingleNode("detail_book_publisher").InnerText;
            button1.Text = nodeList[0].SelectSingleNode("reference_issue_button").InnerText;
            nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
        }
        private void button2_Click(object sender, EventArgs e)
        {

            if (comboBox1.Text == "")
                MessageBox.Show("Semester Field can't be Blank.");
            else if (comboBox4.Text == "")
                MessageBox.Show("Student Name Can't be Blank.");

            else if ((checkBox1.Checked && comboBox5.Text == "") || (checkBox2.Checked && comboBox6.Text == "") || (checkBox3.Checked && comboBox7.Text == "") || (checkBox4.Checked && comboBox8.Text == "") || (checkBox5.Checked && comboBox9.Text == "") || (checkBox6.Checked && comboBox10.Text == ""))
                MessageBox.Show("Book Id Field Can't Be blank Where Book Is Selected.");
            else if ((!checkBox1.Checked && comboBox5.Text != "") || (!checkBox2.Checked && comboBox6.Text != "") || (!checkBox3.Checked && comboBox7.Text != "") || (!checkBox4.Checked && comboBox8.Text != "") || (!checkBox5.Checked && comboBox9.Text != "") || (!checkBox6.Checked && comboBox10.Text != ""))
                MessageBox.Show("Book Id Can't Be Selected Where Book is Not Selected.");
            else
            {
                cmd.CommandText = @"SELECT Count (*) FROM [Allocation] WHERE book_type='Book_Bank' AND return_date ='00/00/0000' AND student_name='"+comboBox4.Text+"' AND student_semester='"+comboBox1.Text+"';";
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    int t = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (t>0)
                    {
                        MessageBox.Show("Book Bank Already Given .");
                    }
                else
                {
                        passwordBox ps = new passwordBox();
                        string pw = ps.Show("Enter Your Password.","Password Prompt");
                        if (pw == "")
                        {
                            MessageBox.Show("Password Field is Empty.");
                        }
                        else if (pw.Length != 8)
                        {
                            MessageBox.Show("Password Should be of Length 8.");
                        }
                        else
                        {
                            cmd.CommandText = "SELECT password FROM [Student] WHERE student_name='"+comboBox4.Text+"'and student_semester='" + comboBox1.Text + "'";
                            string val = cmd.ExecuteScalar().ToString();
                            if (pw == val)
                            {
                                if (checkBox1.Checked && comboBox5.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox5.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();

                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox5.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + Convert.ToInt32(comboBox1.Text) + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation ='Yes' WHERE book_id='" + comboBox5.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 1 Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox5.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox5.ResetText();
                                            comboBox5.Items.Clear();
                                            checkBox1.Checked = false;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }


                                }

                                if (checkBox2.Checked && comboBox6.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox6.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox6.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox6.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 2 Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox6.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox6.ResetText();
                                            comboBox6.Items.Clear();
                                            checkBox2.Checked = false;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }


                                }
                                if (checkBox3.Checked && comboBox7.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox7.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox7.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox7.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 3 Allocation Successfull.");


                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox7.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox7.ResetText();
                                            comboBox7.Items.Clear();
                                            checkBox3.Checked = false;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }


                                }
                                if (checkBox4.Checked && comboBox8.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox8.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox8.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox8.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 4 Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox8.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox8.ResetText();
                                            comboBox8.Items.Clear();
                                            checkBox4.Checked = false;

                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }


                                }
                                if (checkBox5.Checked && comboBox9.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox9.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox9.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox9.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 5 Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox9.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox9.ResetText();
                                            comboBox9.Items.Clear();
                                            checkBox5.Checked = false;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }


                                }
                                if (checkBox6.Checked && comboBox10.Text != "")
                                {
                                    string to = "";
                                    cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox10.Text + "'";
                                    OleDbDataReader read = cmd.ExecuteReader();
                                    if (read.Read())
                                    {
                                        to = read[2].ToString();
                                    }
                                    read.Close();
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox10.Text.ToString() + "','" + td + "','" + to + "','" + comboBox4.Text.ToString() + "','" + comboBox1.Text.ToString() + "','" + i + "','" + d + "','" + r + "');";
                                    cmd.Connection = conn;

                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox10.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            MessageBox.Show("Book 6 Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", to, comboBox10.Text.ToString(), td, comboBox4.Text.ToString(), comboBox1.Text);
                                            }
                                            comboBox10.ResetText();
                                            comboBox10.Items.Clear();
                                            checkBox6.Checked = false;
                                            tableLayoutPanel1.Visible = true;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }

                                }
                            
                            }
                            else
                            {
                                MessageBox.Show("Invalid Password.");
                            }
                        }
                          

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Can't Connect To Database." + ex.Message);
                }
                finally
                {
                    comboBox1.ResetText(); comboBox4.ResetText();
                    conn.Close();
                }
            }
                    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox3.Text == "")
                MessageBox.Show("Type is Not Selected .");
            else if (comboBox2.Text == "" && comboBox3.Text == "Student")

                MessageBox.Show("Semester is Not Selected.");
            else if (comboBox11.Text == "")
                MessageBox.Show("Name is Not Selected.");
            else if (comboBox12.Text == "")
                MessageBox.Show("Book is Not Selected.");
            else if (comboBox13.Text == "")
                MessageBox.Show("Book id is Not Selected");
            else
            {
                cmd.CommandText = @"SELECT Count (*) FROM [Allocation] WHERE book_name='" + comboBox12.Text + "' AND return_date ='00/00/0000' AND student_name='" + comboBox11.Text + "' AND student_semester='" + comboBox2.Text + "';";
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    int dup = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                    if (dup > 0)
                    {
                        MessageBox.Show("Book is Already Allocated.");
                    }
                    else
                    {

                        cmd.CommandText = @"SELECT Count (*) FROM [Allocation] WHERE book_type='Reference' AND return_date ='00/00/0000' AND student_name='" + comboBox11.Text + "' AND student_semester='" + comboBox2.Text + "';";
                        cmd.Connection = conn;

                        int b = Convert.ToInt32(cmd.ExecuteScalar().ToString());
                        if (b >= 3)
                        {
                            MessageBox.Show(" Maximum No. of Books Already Given .");
                        }
                        else
                        {
                            passwordBox ps = new passwordBox();
                            string pw = ps.Show("Enter Your Password.", "Password Prompt");
                            if (pw == "")
                            {
                                MessageBox.Show("Password Field is Empty.");
                            }
                            else if (pw.Length != 8)
                            {
                                MessageBox.Show("Password Should be of Length 8.");
                            }
                            else
                            {
                                if (comboBox3.SelectedIndex == 0)
                                    cmd.CommandText = "SELECT password FROM [Student] WHERE student_name='" + comboBox11.Text + "'and student_semester='" + comboBox2.Text + "'";
                                
                                else
                                    cmd.CommandText = "SELECT password FROM [Teacher] WHERE teacher_name='" + comboBox11.Text + "'";
                                
                                cmd.Connection = conn;
                                string va = cmd.ExecuteScalar().ToString();
                                if (pw == va)
                                {
                                    cmd.CommandText = @"INSERT INTO [Allocation] (book_id,book_type,book_name,student_name,student_semester,issue_date,due_date,return_date) VALUES ('" + comboBox13.Text.ToString() + "','" + ta + "','" + comboBox12.Text.ToString() + "','" + comboBox11.Text.ToString() + "','" + Convert.ToInt32(comboBox2.Text) + "','" + i + "','" + da + "','" + r + "');";
                                    cmd.Connection = conn;


                                    if (cmd.ExecuteNonQuery() == 1)
                                    {
                                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='" + comboBox13.Text + "'";
                                        if (cmd.ExecuteNonQuery() == 1)
                                        {
                                            conn.Close();
                                            MessageBox.Show("Book  Allocation Successfull.");

                                            using (var tw = new StreamWriter(path, true))
                                            {

                                                tw.WriteLine("User Allocated Book {0} With Id {1} Of Type {2} To Student {3} Of Semester {4}.", comboBox12.Text.ToString(), comboBox13.Text.ToString(), ta, comboBox11.Text.ToString(), comboBox2.Text);
                                            }
                                            comboBox13.ResetText(); comboBox12.ResetText(); comboBox11.ResetText(); comboBox2.ResetText(); comboBox3.ResetText();
                                            comboBox3.Items.Clear();
                                            comboBox2.Items.Clear(); comboBox11.Items.Clear(); comboBox12.Items.Clear(); comboBox13.Items.Clear();
                                            tableLayoutPanel2.Visible = false;
                                        }
                                        else
                                            MessageBox.Show("Can't Issue Book Try Later.");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Can't Process Query Now.");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Invalid Password.");
                            }
                            }



                        }
                    }
                }




                catch (Exception exce)
                {
                    MessageBox.Show("Can't Connect To Database" + exce.Message);
                }
                finally
                {
                    conn.Close();
                }

            }
            }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            comboBox4.Items.Clear();
            if (checkBox1.Checked)
            {
                comboBox5.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox1.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox5.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();
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
        }

        private void checkBox2_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox6.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox2.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox6.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();

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
        }

        private void checkBox3_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                comboBox7.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox3.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox7.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();
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
        }

        private void checkBox4_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox4.Checked)
            {
                comboBox8.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox4.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox8.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();
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
        }

        private void checkBox5_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox5.Checked)
            {
                comboBox9.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox5.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox9.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();
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
        }

        private void checkBox6_CheckStateChanged(object sender, EventArgs e)
        {
            if (checkBox6.Checked)
            {
                comboBox10.Items.Clear();
                cmd.CommandText = "SELECT * FROM [Book] WHERE book_subject = '" + checkBox6.Text + "'AND book_allocation = 'No'";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox10.Items.Add(reder["book_id"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                    }
                    reder.Close();

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
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
            if (comboBox3.SelectedIndex==1)
            {
                comboBox2.Visible = false;
                comboBox2.Text = "0";
                cmd.CommandText = "SELECT * FROM [Teacher] ORDER BY teacher_name";
                cmd.Connection = conn;
                try
                {

                    conn.Open();
                    OleDbDataReader reder = cmd.ExecuteReader();
                    if (reder.HasRows)
                    {

                        while (reder.Read())
                        {
                            comboBox11.Items.Add(reder["teacher_name"].ToString());
                        }
                    }
                    else
                    {
                        MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                        comboBox2.Visible = true;
                    }
                    reder.Close();

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
            else
            {
                comboBox2.Visible = true;
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox11.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Student] WHERE student_semester = '" + (comboBox2.SelectedIndex + 1) + "'and status='y'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox11.Items.Add(reder["student_name"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }
                reder.Close();
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

        private void groupBox1_Enter(object sender, EventArgs e)
        {


        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox13.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_name='" + comboBox12.GetItemText(comboBox12.SelectedItem) + "' AND book_allocation='No'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox13.Items.Add(reder["book_id"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }
                reder.Close();

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

        private void comboBox11_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox12.Items.Clear();

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
                        comboBox12.Items.Add(reder["book_name"].ToString());
                    }
                }
                else
                {
                    MessageBox.Show("Not able to get output!", "Error", MessageBoxButtons.OK);
                }
                reder.Close();
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

        private void comboBox13_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_id = '" + comboBox13.GetItemText(comboBox13.SelectedItem) + "' AND book_allocation = 'No'";
            cmd.Connection = conn;
            try
            {
                conn.Open();
                OleDbDataReader read = cmd.ExecuteReader();
                

                if (read.Read())
                {
                    label12.Text = read[1].ToString();
                    label13.Text = read[2].ToString();
                    label14.Text = read[4].ToString();
                    label15.Text = read[3].ToString();
                    tableLayoutPanel2.Visible = true;
                    button1.Visible = true;

                }
                read.Close();
            }
            catch(Exception exp)
            {
                MessageBox.Show("Unable To Connect To Database ."+exp.Message);
            }
            finally
            {
                conn.Close();
            }
        }
    }
}
