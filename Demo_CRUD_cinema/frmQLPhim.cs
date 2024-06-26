using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmQLPhim : Form
    {
        private const string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
        private SqlConnection connection;
        private SqlDataAdapter adapter;
        private DataTable dataTable;
        private bool isUpdating = false;

        public frmQLPhim()
        {
            InitializeComponent();
            connection = new SqlConnection(connectionString);
            adapter = new SqlDataAdapter("SELECT * FROM Movie", connection);
            dataTable = new DataTable();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
            dataGridView1.SelectionChanged += dataGridView1_SelectionChanged;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();

                // Kiểm tra xem người dùng đã chọn thể loại phim hay chưa
                if (string.IsNullOrEmpty(txtGenreID.Text))
                {
                    MessageBox.Show("Vui lòng chọn thể loại phim.");
                    return;
                }

                SqlCommand command = new SqlCommand("INSERT INTO Movie (MovieID,Movie_Name, Release_Day, Movie_State, Image, Demo_Video, GenreID, Age_Required, Description, Duration, Country) VALUES (@MovieID, @Movie_Name, @Release_Day, @Movie_State, @Image, @Demo_Video, @GenreID, @Age_Required, @Description, @Duration, @Country)", connection);
                command.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
                command.Parameters.AddWithValue("@Movie_Name", txtMovie_Name.Text);
                command.Parameters.AddWithValue("@Release_Day", dtpRelease_Day.Value);
                command.Parameters.AddWithValue("@Movie_State", txtMovie_State.Text);
                command.Parameters.AddWithValue("@Image", txtImage.Text);
                command.Parameters.AddWithValue("@Demo_Video", txtDemo_Video.Text);
                command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                command.Parameters.AddWithValue("@Age_Required", txtAge_Required.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@Duration", txtDuration.Text);
                command.Parameters.AddWithValue("@Country", txtCountry.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Thêm phim thành công.");
                connection.Close();
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
                connection.Open();
                SqlCommand command = new SqlCommand("DELETE FROM Movie WHERE MovieID = @MovieID", connection);
                command.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Xóa phim thành công.");
                connection.Close();
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
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE Movie SET Movie_Name = @Movie_Name, Release_Day = @Release_Day, Movie_State = @Movie_State, Image = @Image, Demo_Video = @Demo_Video, GenreID = @GenreID, Age_Required = @Age_Required, Description = @Description, Duration = @Duration, Country = @Country WHERE MovieID = @MovieID", connection);
                command.Parameters.AddWithValue("@Movie_Name", txtMovie_Name.Text);
                command.Parameters.AddWithValue("@Release_Day", dtpRelease_Day.Value);
                command.Parameters.AddWithValue("@Movie_State", txtMovie_State.Text);
                command.Parameters.AddWithValue("@Image", txtImage.Text);
                command.Parameters.AddWithValue("@Demo_Video", txtDemo_Video.Text);
                command.Parameters.AddWithValue("@GenreID", txtGenreID.Text);
                command.Parameters.AddWithValue("@Age_Required", txtAge_Required.Text);
                command.Parameters.AddWithValue("@Description", txtDescription.Text);
                command.Parameters.AddWithValue("@Duration", txtDuration.Text);
                command.Parameters.AddWithValue("@Country", txtCountry.Text);
                command.Parameters.AddWithValue("@MovieID", txtMovieID.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Cập nhật thông tin phim thành công.");
                connection.Close();
                RefreshDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void RefreshDataGridView()
        {
            dataTable.Clear();
            adapter.Fill(dataTable);
            dataGridView1.DataSource = dataTable;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            // Kiểm tra có hàng nào được chọn hay không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy hàng được chọn đầu tiên
                DataGridViewRow selectedRow = dataGridView1.SelectedRows[0];

                // Lấy dữ liệu từ các ô trong hàng được chọn và gán cho các control tương ứng
                txtMovieID.Text = selectedRow.Cells["MovieID"].Value?.ToString();
                txtMovie_Name.Text = selectedRow.Cells["Movie_Name"].Value?.ToString();

                // Kiểm tra và chuyển đổi ngày phát hành sang định dạng DateTime
                if (DateTime.TryParse(selectedRow.Cells["Release_Day"].Value?.ToString(), out DateTime releaseDay))
                {
                    dtpRelease_Day.Value = releaseDay;
                }

                txtMovie_State.Text = selectedRow.Cells["Movie_State"].Value?.ToString();
                txtImage.Text = selectedRow.Cells["Image"].Value?.ToString();
                txtDemo_Video.Text = selectedRow.Cells["Demo_Video"].Value?.ToString();
                txtGenreID.Text = selectedRow.Cells["GenreID"].Value?.ToString();
                txtAge_Required.Text = selectedRow.Cells["Age_Required"].Value?.ToString();
                txtDescription.Text = selectedRow.Cells["Description"].Value?.ToString();
                txtDuration.Text = selectedRow.Cells["Duration"].Value?.ToString();
                txtCountry.Text = selectedRow.Cells["Country"].Value?.ToString();
            }
        }

    }
}
