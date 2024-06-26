using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo_CRUD_cinema
{
    public partial class frmChartPhim : Form
    {
        public frmChartPhim()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmChartPhim_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT m.Movie_Name, SUM(r.Total_Amount) AS TotalRevenue " +
                           "FROM Movie m " +
                           "INNER JOIN Ticket t ON m.MovieID = t.MovieID " +
                           "INNER JOIN Revenue r ON t.TicketID = r.TicketID " +
                           "GROUP BY m.Movie_Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    chartRevenue.Series.Clear();
                    chartRevenue.ChartAreas.Clear();

                    // Thêm ChartArea mới để hiển thị dữ liệu
                    chartRevenue.ChartAreas.Add(new ChartArea());

                    // Tạo series mới cho biểu đồ
                    Series series = new Series("Doanh thu theo phim");

                    // Thiết lập loại biểu đồ
                    series.ChartType = SeriesChartType.Column;

                    // Thêm series vào biểu đồ
                    chartRevenue.Series.Add(series);

                    // Thiết lập dữ liệu cho series
                    foreach (DataRow row in dt.Rows)
                    {
                        string movieName = row["Movie_Name"].ToString();
                        double totalRevenue = Convert.ToDouble(row["TotalRevenue"]);

                        // Thêm dữ liệu vào series
                        series.Points.AddXY(movieName, totalRevenue);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
