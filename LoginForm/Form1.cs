using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Text.RegularExpressions;


namespace LoginForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            label4.Visible = false;
            //label5.Visible = false;

        }
        SqlConnection conn = new SqlConnection(@"Data Source=JITHIN\SQLEXPRESS03;Initial Catalog=logindb;Integrated Security=True");

        private void label2_Click(object sender, EventArgs e)
        {

        }

        // private void button2_Click(object sender, EventArgs e)
        // {


        /*  String username, user_password;
          username = textBox1.Text;
          user_password = textBox2.Text;*/
        //try
        // {
        /* String queryy = "select * from Login where username='" + textBox1.Text + "' AND password= '" + textBox2.Text + "'";
         SqlDataAdapter sda = new SqlDataAdapter(queryy, conn);
         DataTable dt = new DataTable();
         sda.Fill(dt);

         if (dt.Rows.Count > 0)
         {
             username = textBox1.Text;
             user_password = textBox2.Text;
             Form2 form2 = new Form2();
             form2.Show();
             this.Hide();
         }
         else
         {
             MessageBox.Show("invalid details", "error", MessageBoxButtons.OK);
             textBox1.Clear();
             textBox2.Clear();
             textBox1.Focus();


         }*/
        /*
                        conn.Open();
                        SqlCommand cmd = new SqlCommand("loginProcedure", conn);
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@Username", textBox1.Text);
                        cmd.Parameters.AddWithValue("@Password", textBox2.Text);

                        SqlDataReader reader = cmd.ExecuteReader();
                        if (reader.Read())
                        {
                            //  MessageBox.Show("Login successfully");
                            Form2 form2 = new Form2();
                            form2.Show();
                            this.Hide();
                        }
                        else
                        {
                            MessageBox.Show("Login failed");

                        }


                    }
                    catch
                    {
                        MessageBox.Show("error");


                    }
                    finally
                    {
                        conn.Close();

                    }
                }*/
        private void button2_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;


            // Check if username or password is empty
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                label4.Text = "Please enter both username and password.";
                label4.Visible = true;
            }
            // Check if username contains only characters
            if (!Regex.IsMatch(username, "^[a-zA-Z]+$"))
            {
                label4.Text = "Invalid username. Only characters are allowed.";
                label4.Visible = true;
                return;
            }

            else
            {
                try
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("loginProcedure", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@Password", password);

                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        // Login successful
                        Form2 form2 = new Form2();
                        form2.Show();
                        this.Hide();
                    }
                    else
                    {
                        label4.Text = "Invalid username or password";
                        label4.Visible = true;
                    }
                }
                catch (Exception ex)
                {
                    label4.Text = "An error occurred: " + ex.Message;
                    label4.Visible = true;
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                textBox2.UseSystemPasswordChar = false;
            }
            else
            {
                textBox2.UseSystemPasswordChar = true;
            }
        }
    }
}

