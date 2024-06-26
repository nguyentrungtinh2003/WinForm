using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo_CRUD_cinema
{
    public partial class TestDashboard : Form
    {
        public TestDashboard()
        {
            InitializeComponent();
            LoadChartData();
        }

        private void LoadChartData()
        {
            // Kết nối đến cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn dữ liệu từ cơ sở dữ liệu
                string query = "SELECT Genre_Name, COUNT(*) AS MovieCount FROM Movie INNER JOIN Genre ON Movie.GenreID = Genre.GenreID GROUP BY Genre_Name";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Tạo series cho biểu đồ
                Series series = new Series();
                series.ChartType = SeriesChartType.Column; // Chuyển sang loại biểu đồ cột

                // Thêm dữ liệu vào series
                while (reader.Read())
                {
                    string genreName = reader["Genre_Name"].ToString();
                    int movieCount = Convert.ToInt32(reader["MovieCount"]);
                    series.Points.AddXY(genreName, movieCount);
                }

                // Thêm series vào biểu đồ
                chart1.Series.Add(series);

                // Đặt tên cho biểu đồ và trục
                chart1.Titles.Add("Number of Movies by Genre");
                chart1.ChartAreas[0].AxisX.Title = "Genre";
                chart1.ChartAreas[0].AxisY.Title = "Number of Movies";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối sau khi sử dụng
                connection.Close();
            }
        }
    }
}
