using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmQLXuatChieu : Form
    {
        public frmQLXuatChieu()
        {
            InitializeComponent();
            LoadData();
            dataGridView1.CellClick += dataGridView1_CellClick;
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Showtime";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtShowtimeID.Text = row.Cells["ShowtimeID"].Value.ToString();
                txtRoomID.Text = row.Cells["RoomID"].Value.ToString();
                txtSeatID.Text = row.Cells["SeatID"].Value.ToString();
                dtpMovie_Day.Value = Convert.ToDateTime(row.Cells["Movie_Day"].Value);
                txtTime_Start.Text = row.Cells["Time_Start"].Value.ToString();
                txtTime_End.Text = row.Cells["Time_End"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Showtime (ShowtimeID, RoomID, SeatID, Movie_Day, Time_Start, Time_End) VALUES (@ShowtimeID, @RoomID, @SeatID, @Movie_Day, @Time_Start, @Time_End)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShowtimeID", txtShowtimeID.Text);
                command.Parameters.AddWithValue("@RoomID", txtRoomID.Text);
                command.Parameters.AddWithValue("@SeatID", txtSeatID.Text);
                command.Parameters.AddWithValue("@Movie_Day", dtpMovie_Day.Value.Date);
                command.Parameters.AddWithValue("@Time_Start", TimeSpan.Parse(txtTime_Start.Text));
                command.Parameters.AddWithValue("@Time_End", TimeSpan.Parse(txtTime_End.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Xuất chiếu đã được thêm thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Showtime WHERE ShowtimeID = @ShowtimeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShowtimeID", txtShowtimeID.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Xuất chiếu đã được xóa thành công!");
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Showtime SET RoomID = @RoomID, SeatID = @SeatID, Movie_Day = @Movie_Day, Time_Start = @Time_Start, Time_End = @Time_End WHERE ShowtimeID = @ShowtimeID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ShowtimeID", txtShowtimeID.Text);
                command.Parameters.AddWithValue("@RoomID", txtRoomID.Text);
                command.Parameters.AddWithValue("@SeatID", txtSeatID.Text);
                command.Parameters.AddWithValue("@Movie_Day", dtpMovie_Day.Value.Date);
                command.Parameters.AddWithValue("@Time_Start", TimeSpan.Parse(txtTime_Start.Text));
                command.Parameters.AddWithValue("@Time_End", TimeSpan.Parse(txtTime_End.Text));
                command.ExecuteNonQuery();
                MessageBox.Show("Thông tin xuất chiếu đã được cập nhật thành công!");
                LoadData();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
