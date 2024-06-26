using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartState : Form
    {
        public frmChartState()
        {
            InitializeComponent();
        }

        private void frmChartState_Load(object sender, EventArgs e)
        {
            LoadMovieStateData();
        }

        private void LoadMovieStateData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT Movie_State, COUNT(*) AS MovieCount FROM Movie GROUP BY Movie_State";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    chartMovieState.Series.Clear();
                    chartMovieState.Series.Add("Tỷ lệ");
                    chartMovieState.Series["Tỷ lệ"].ChartType = SeriesChartType.Column;

                    foreach (DataRow row in dt.Rows)
                    {
                        string movieState = row["Movie_State"].ToString();
                        int movieCount = Convert.ToInt32(row["MovieCount"]);

                        // Tạo một cột mới
                        DataPoint dataPoint = new DataPoint();
                        dataPoint.SetValueXY(movieState, movieCount);

                        // Thay đổi màu của cột
                        dataPoint.Color = System.Drawing.Color.Green;

                        // Thêm cột vào biểu đồ
                        chartMovieState.Series["Tỷ lệ"].Points.Add(dataPoint);
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
