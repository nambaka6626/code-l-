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
    public partial class Form1 : Form
    {
        private SqlConnection connection;
        private DataTable dataTable;
        private string connectionString = "Server=DESKTOP-UN90EKQ;Database=tuyen_sv;Integrated Security=True;";

        public Form1()
        {
            InitializeComponent();
            connection = new SqlConnection("Server=DESKTOP-UN90EKQ;Database=tuyen_sv;Integrated Security=True;");

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lammoi_Click(object sender, EventArgs e)
        {
            //dgvStudent.DataSource = null;
            //dgvStudent.Rows.Clear();
            //dgvStudent.Columns.Clear();
            connection.Open();
            MessageBox.Show("Làm mới hoàn tất! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Filldata();
            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dgvStudent.DataSource = null;
            dgvStudent.Rows.Clear();
            dgvStudent.Columns.Clear();
            connection.Open();
            MessageBox.Show("Kết nối thành công đến cơ sở dữ liệu.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Filldata();

            //// Khởi tạo DataTable và DataGridView
            //dataTable = new DataTable();
            //// Khởi tạo cấu trúc bảng và đọc dữ liệu từ cơ sở dữ liệu vào DataTable
            //ReadDataFromDatabase();

            //// Đặt DataTable làm nguồn dữ liệu cho DataGridView
            //dgvStudent.DataSource = dataTable;
            dgvStudent.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void Filldata()
        {
            string query = "select * from Studentss";
            DataTable tbl = new DataTable();
            SqlDataAdapter ad = new SqlDataAdapter(query, connection);
            ad.Fill(tbl);
            dgvStudent.DataSource = tbl;
            connection.Close();


        }

        private void chinhsua_Click(object sender, EventArgs e)
        {
            UpdateDatabase(dataTable, connectionString);
        }

        private void ReadDataFromDatabase()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT StudentID, FullName,DateOfBirth, Gender from Studentss"; // Thay "YourTableName" bằng tên thực tế của bảng
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);

                try
                {
                    connection.Open();
                    adapter.Fill(dataTable);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Đã xảy ra lỗi khi đọc dữ liệu từ cơ sở dữ liệu: " + ex.Message);
                }
            }
        }

        private void UpdateDatabase(DataTable dataTable, string connectionString)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(connection))
                {
                    bulkCopy.DestinationTableName = "Studentss"; // Thay "YourTableName" bằng tên thực tế của bảng

                    try
                    {
                        bulkCopy.WriteToServer(dataTable);
                        MessageBox.Show("Dữ liệu đã được cập nhật vào cơ sở dữ liệu.");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Đã xảy ra lỗi khi cập nhật dữ liệu vào cơ sở dữ liệu: " + ex.Message);
                    }
                }
            }
        }

        private void btn_logout_Click(object sender, EventArgs e)
        {
                Application.Exit();
        }
    }
}
