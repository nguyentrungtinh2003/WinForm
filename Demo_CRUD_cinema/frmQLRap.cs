using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmQLRap : Form
    {
        private const string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public frmQLRap()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("SELECT * FROM Cinema", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connection.Open();

                // Thực thi truy vấn thêm
                SqlCommand command = new SqlCommand("INSERT INTO Cinema (CinemaID, Cinema_Name, Address, Description, Phone_Number) VALUES (@CinemaID, @Cinema_Name, @Address, @Description, @Phone_Number)", connection);
                command.Parameters.AddWithValue("@CinemaID", txtCinemaID.Text);
                command.Parameters.AddWithValue("@Cinema_Name", txtCinema_Name.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@Phone_Number", txtPhone_Number.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Thêm rạp phim thành công.");

                // Đóng kết nối
                connection.Close();

                // Làm mới DataGridView
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connection.Open();

                // Thực thi truy vấn xóa
                SqlCommand command = new SqlCommand("DELETE FROM Cinema WHERE CinemaID = @CinemaID", connection);
                command.Parameters.AddWithValue("@CinemaID", txtCinemaID.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Xóa rạp phim thành công.");

                // Đóng kết nối
                connection.Close();

                // Làm mới DataGridView
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                // Mở kết nối
                connection.Open();

                // Thực thi truy vấn sửa
                SqlCommand command = new SqlCommand("UPDATE Cinema SET Cinema_Name = @Cinema_Name, Address = @Address, Description = @Description, Phone_Number = @Phone_Number WHERE CinemaID = @CinemaID", connection);
                command.Parameters.AddWithValue("@Cinema_Name", txtCinema_Name.Text);
                command.Parameters.AddWithValue("@Address", txtAddress.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@Phone_Number", txtPhone_Number.Text);
                command.Parameters.AddWithValue("@CinemaID", txtCinemaID.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin rạp phim thành công.");

                // Đóng kết nối
                connection.Close();

                // Làm mới DataGridView
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void RefreshDataGridView()
        {
            // Làm mới DataTable và DataGridView
            dataTable.Clear();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            // Đóng ứng dụng
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtCinemaID.Text = row.Cells["CinemaID"].Value.ToString();
                txtCinema_Name.Text = row.Cells["Cinema_Name"].Value.ToString();
                txtAddress.Text = row.Cells["Address"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                txtPhone_Number.Text = row.Cells["Phone_Number"].Value.ToString();
            }
        }
    }
}
