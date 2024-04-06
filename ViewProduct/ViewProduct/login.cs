using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ViewProduct
{
    public partial class login : Form
    {
        private SqlConnection connection;
        public login()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-UN90EKQ;Database=login;Integrated Security=True;");

        }

        private void btn_login_Click(object sender, EventArgs e)
        {
            string username = tbx_username.Text;
            string pass = tbx_pass.Text;
            string query = "SELECT * FROM account WHERE username = @username AND u_password = @u_password";
            connection.Open();
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@u_password", pass);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                string roll = reader["u_roll"].ToString();
                if (roll.Equals("admin"))
                {
                    MessageBox.Show(this, "Login successful :))", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Form1 f1 = new Form1();
                    f1.ShowDialog();
                    this.Dispose();
                }
                else if (roll.Equals("user"))
                {
                    MessageBox.Show(this, "Login successful :)))", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
                    this.Hide();
                    Form2 f2 = new Form2();
                    f2.ShowDialog();
                    this.Dispose();
                }
                else
                {
                    MessageBox.Show(this, "Invalid user role", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show(this, "Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            connection.Close();
            //string username = tbx_username.Text;
            //string pass = tbx_pass.Text;
            //string query = "select * from account where username = @username and pass = @u_password";
            //connection.Open();
            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("username", SqlDbType.VarChar);

            //cmd.Parameters.AddWithValue("@username", username);
            //cmd.Parameters.AddWithValue("@pass", pass);





            //cmd.Parameters["@username"].Value = username;
            //cmd.Parameters.AddWithValue ("pass", SqlDbType.VarChar);
            //cmd.Parameters["@pass"].Value = pass;
            //SqlDataReader reader = cmd.ExecuteReader();
            //if (reader.Read())
            //{
            //    string roll = reader["u_roll"].ToString();
            //    if (roll.Equals("admin"))
            //    {
            //        MessageBox.Show(this, "Login successful :))", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
            //        this.Hide();
            //        Form1 f1 = new Form1();
            //        f1.ShowDialog();
            //        this.Dispose();

            //    }
            //    else if (roll.Equals("user"))
            //    {
            //        MessageBox.Show(this, "Login successful :)))", "result", MessageBoxButtons.OK, MessageBoxIcon.None);
            //        this .Hide();
            //        Form2 f2 = new Form2();
            //        f2.ShowDialog();
            //        this.Dispose();
            //    }
            //}





            //connection.Close();
        }

    }
}
 