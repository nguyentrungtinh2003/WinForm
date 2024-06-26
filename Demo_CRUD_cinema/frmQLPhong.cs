using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmQLPhongChieu : Form
    {
        private const string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";

        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;

        public frmQLPhongChieu()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("SELECT * FROM Room", connection);
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
                SqlCommand command = new SqlCommand("INSERT INTO Room (RoomID, CinemaID, Room_State, Room_Name, Capacity, Description) VALUES (@RoomID, @CinemaID, @Room_State, @Room_Name, @Capacity, @Description)", connection);
                command.Parameters.AddWithValue("@RoomID", txtRoomID.Text);
                command.Parameters.AddWithValue("@CinemaID", txtCinemaID.Text);
                command.Parameters.AddWithValue("@Room_State", txtRoom_State.Text);
                command.Parameters.AddWithValue("@Room_Name", txtRoom_Name.Text);
                command.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Thêm phòng chiếu thành công.");

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
                SqlCommand command = new SqlCommand("DELETE FROM Room WHERE RoomID = @RoomID", connection);
                command.Parameters.AddWithValue("@RoomID", txtRoomID.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Xóa phòng chiếu thành công.");

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
                SqlCommand command = new SqlCommand("UPDATE Room SET CinemaID = @CinemaID, Room_State = @Room_State, Room_Name = @Room_Name, Capacity = @Capacity, Description = @Description WHERE RoomID = @RoomID", connection);
                command.Parameters.AddWithValue("@CinemaID", txtCinemaID.Text);
                command.Parameters.AddWithValue("@Room_State", txtRoom_State.Text);
                command.Parameters.AddWithValue("@Room_Name", txtRoom_Name.Text);
                command.Parameters.AddWithValue("@Capacity", txtCapacity.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@RoomID", txtRoomID.Text);
                command.ExecuteNonQuery();

                MessageBox.Show("Cập nhật thông tin phòng chiếu thành công.");

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
                txtRoomID.Text = row.Cells["RoomID"].Value.ToString();
                txtCinemaID.Text = row.Cells["CinemaID"].Value.ToString();
                txtRoom_State.Text = row.Cells["Room_State"].Value.ToString();
                txtRoom_Name.Text = row.Cells["Room_Name"].Value.ToString();
                txtCapacity.Text = row.Cells["Capacity"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
            }
        }
    }
}
