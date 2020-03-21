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
using System.Net;
using System.Net.Mail;
using System.IO;
namespace Library
{
    public partial class Form2 : Form
    {
        string path = @"C:\";
        OleDbConnection conn = new OleDbConnection(c);
        OleDbCommand cmd = new OleDbCommand();
        static int u = 1;
        string user = "";
       static  string c = "";
        string ml = "";
        string pwd = "";
        
public Form2(string s)
        {
            user = s;
            InitializeComponent();
            path += DateTime.Now.ToString("MM-dd-yyyy");
            path += ".txt";
           

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("string.xml");
            XmlNodeList nodeList = doc.SelectNodes("form/connection");
            c = nodeList[0].SelectSingleNode("str").InnerText;
            conn = new OleDbConnection(c);
            nodeList = doc.SelectNodes("form/email_info");
            ml = nodeList[0].SelectSingleNode("email").InnerText;
            pwd = nodeList[0].SelectSingleNode("password").InnerText;
            label2.Text = "Welcome-" + user;
            cmd.CommandText = "SELECT * FROM [Allocation] WHERE return_date='00/00/0000' AND due_date<='" + DateTime.Now.ToString("MM/dd/yyy") + "'";
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
            quicktab();
            cmd.CommandText = "SELECT * FROM [Student] where status='y'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox2.Items.Add(reder["student_name"].ToString());
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

        private void EntryNewBook_Click(object sender, EventArgs e)
        { 
            Form11 f = new Form11();
            f.Show();
        }

        private void RemoveBook_Click(object sender, EventArgs e)
        {
            Form4 f = new Form4();
            
            f.Show();
            
        }

        private void PurchaseRequest_Click(object sender, EventArgs e)
        {
            Form5 f = new Form5();
            
            f.Show();
            
        }

        private void IssueBook_Click(object sender, EventArgs e)
        {
            Form3 f = new Form3();
            
            f.Show();
            
        }

        private void RenewBook_Click(object sender, EventArgs e)
        {
            Form9 f = new Form9();
            
            f.Show();
            
        }

        private void ReturnBook_Click(object sender, EventArgs e)
        {
            Form10 f = new Form10();
            
            f.Show();
            
        }

        private void StudentRecord_Click(object sender, EventArgs e)
        {
            Form12 f = new Form12();
            
            f.Show();
            
        }

        private void BookRecord_Click(object sender, EventArgs e)
        {
            Form13 f = new Form13();
            
            f.Show();
            
        }

        private void TotalBooks_Click(object sender, EventArgs e)
        {
            Form6 f = new Form6();
            
            f.Show();
            
        }

        private void AllocatedBooks_Click(object sender, EventArgs e)
        {
            Form7 f = new Form7();
            
            f.Show();
            
        }

        private void RemainingBooks_Click(object sender, EventArgs e)
        {
            Form8 f = new Form8();
            
            f.Show();
            
        }

        private void Reports_Click(object sender, EventArgs e)
        {
            Report r = new Report();
            r.Show();
            
        }

        private void PromoteStudent_Click(object sender, EventArgs e)
        {
            sem_up p = new sem_up();
            
            p.Show();
            
        }

        private void SendEmail_Click(object sender, EventArgs e)
        {
            email em = new email();
            em.Show();
            
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgRow in dataGridView1.Rows)
            {
                if (dgRow.Selected)
                {
                    string sub = "CCE Libraary Notification";
                    string body = "Dear " + dgRow.Cells[4].Value.ToString() + " We have isuued a book " + dgRow.Cells[3].Value.ToString() + " With Book Id " + dgRow.Cells[1].Value.ToString() + " On " + dgRow.Cells[6].Value.ToString() + " Last Date To Submit it is " + dgRow.Cells[7].Value.ToString() + " So,Please Renew it or Return It.";

                    cmd.CommandText = "SELECT * FROM [Student] WHERE student_name = '" + dgRow.Cells[4].Value.ToString() + "' AND student_semester = '" + dgRow.Cells[5].Value.ToString() + "'";
                    try
                    {
                        string to = "";

                        conn.Open();
                        
                        OleDbDataReader read = cmd.ExecuteReader();
                        if (read.Read())
                        {
                            to = read[3].ToString();
                        }
                        MailMessage msg = new MailMessage();
                        msg.From = new MailAddress(ml);
                        
                        msg.To.Add(to);
                        msg.Subject = sub;
                        msg.Body = body;

                        SmtpClient smt = new SmtpClient();
                        smt.Host = "smtp.gmail.com";
                        System.Net.NetworkCredential ntcd = new NetworkCredential();
                        ntcd.UserName = ml;
                        ntcd.Password = pwd;
                        smt.Credentials = ntcd;
                        smt.EnableSsl = true;
                        smt.Port = 587;
                        smt.Send(msg);

                        MessageBox.Show("Mail is sended to-" + dgRow.Cells[4].Value.ToString());
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("Email Sended to {0} To Retun Or Renew Issued Book.",dgRow.Cells[4].Value.ToString());
                        }

                    }

                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message+ex.StackTrace);
                    }
                    finally
                    {
                        conn.Close();
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
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
                        comboBox1.Items.Add(reder["book_name"].ToString());
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox3.Items.Clear();
            cmd.CommandText = "SELECT * FROM [Book] WHERE book_allocation = 'No' AND book_name='"+comboBox1.Text+"'";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataReader reder = cmd.ExecuteReader();
                if (reder.HasRows)
                {

                    while (reder.Read())
                    {
                        comboBox3.Items.Add(reder["book_id"].ToString());
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

        private void button2_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                MessageBox.Show("Name is Not Selected.");
            else if (comboBox1.SelectedIndex == -1)
                MessageBox.Show("Book is Not Selected");
            else if (comboBox3.SelectedIndex == -1)
                MessageBox.Show("Book Id is Not Selected");
            else
            {
                cmd.CommandText = "INSERT INTO [Quick] (name,book,id) VALUES ('" + comboBox2.Text + "','"+comboBox1.Text+"','"+comboBox3.Text+"');";
                cmd.Connection = conn;
                try
                {
                    conn.Open();
                    int a = cmd.ExecuteNonQuery();
                    if (a == 1)
                    {
                        cmd.CommandText = "UPDATE [Book] SET book_allocation='Yes' WHERE book_id='"+comboBox3.Text+"'";
                        if (cmd.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Book Issued Successfully");
                            conn.Close();
                            using (var tw = new StreamWriter(path, true))
                            {

                                tw.WriteLine("Quick Book {0} Issued To {1} With Id {2} .", comboBox1.Text, comboBox2.Text, comboBox3.Text);
                            }
                        }
                        comboBox1.ResetText();
                        comboBox2.ResetText();
                        comboBox3.ResetText();


                    }
                    else
                        MessageBox.Show("Book Can't Be Issued Now.");
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Can't Connect To Database."+exc.Message);
                }
                finally
                {
                    
                    quicktab();
                }
            }
        }
        private void quicktab()
        {
            cmd.CommandText = "SELECT * FROM [Quick]";
            cmd.Connection = conn;
            try
            {

                conn.Open();
                OleDbDataAdapter ad = new OleDbDataAdapter(cmd);
                System.Data.DataTable dt = new System.Data.DataTable();

                ad.Fill(dt);

                dataGridView2.DataSource = dt;


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

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow dgRow in dataGridView2.Rows)
            {
                if (dgRow.Selected)
                {
                    cmd.CommandText = "DELETE FROM [Quick] WHERE id='" + dgRow.Cells[3].Value.ToString() + "'";
                    try
                    {
                        conn.Open();
                        int a = cmd.ExecuteNonQuery();
                        if (a == 1)
                        {
                            cmd.CommandText = "UPDATE [Book] SET book_allocation='No' WHERE book_id='" + dgRow.Cells[3].Value.ToString() + "'";
                            if (cmd.ExecuteNonQuery() == 1)
                            {
                                MessageBox.Show("Return Successfull");
                                using (var tw = new StreamWriter(path, true))
                                {

                                    tw.WriteLine("Quick Book Returned With Id {0}.", dgRow.Cells[3].Value.ToString());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Can't Process Query Now.");
                        }
                       
                    }
                    catch(Exception exc)
                    {
                        MessageBox.Show("Can't Connect To Database."+exc.Message);
                    }
                    finally
                    {
                        conn.Close();
                        quicktab();
                    }
                  
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            u++;
            if (u % 2 == 0)
                panel6.Visible = true;
            else
                panel6.Visible = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            panel7.Visible = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
            using (var tw = new StreamWriter(path, true))
            {

                tw.WriteLine("User Logged Out.");
            }
           
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
                MessageBox.Show("Password Field is Blank.");
            else if (textBox1.Text.Length < 8)
                MessageBox.Show("Password Should be of Length 8.");
            else
            {
                cmd.CommandText = "UPDATE [User] SET user_password='" + textBox1.Text + "'where user_id='"+user+"'";
                try
                {
                    conn.Open();
                    int s = cmd.ExecuteNonQuery();
                    if (s == 1)
                    {
                        MessageBox.Show("Password Updation Successfull.");
                        using (var tw = new StreamWriter(path, true))
                        {

                            tw.WriteLine("User Updated His Password.");
                        }
                        textBox1.Text = "";
                        panel7.Visible = false;
                    }
                    else
                        MessageBox.Show("Can't Process Request Now.");
                }
                catch(Exception exc)
                {
                    MessageBox.Show("Can't Connect To Database."+exc.Message);
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            cmd.CommandText = "SELECT COUNT(*) FROM [Quick]";
            try
            {
                conn.Open();
                if(cmd.ExecuteScalar().ToString()!="0")
               
                {
                    MessageBox.Show("Quick Issued Books Not Collected Properly.");
                    Form2 f = new Form2(user);
                    this.Close();
                    f.ShowDialog();
                   
                }
                else
                    MessageBox.Show("Have A Good Day !.");
            }
            catch (Exception exc)
            {
                MessageBox.Show("Can't Connect To Database." + exc.Message);
            }
            finally
            {
                conn.Close();
            }
            using (var tw = new StreamWriter(path, true))
            {

                tw.WriteLine("User Logged Out At {0}.",DateTime.Now.ToString("HH/mm//ss"));
            }
        }

        private void uploadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            upload_data u = new upload_data();
            u.ShowDialog();
        }

        private void updateStudentRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            upstu u = new upstu();
            u.ShowDialog();
        }

        private void updateBookRecordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            upbook u = new upbook();
            u.ShowDialog();
        }
    }
}
