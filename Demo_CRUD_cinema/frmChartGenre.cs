using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartGenre : Form
    {
        public frmChartGenre()
        {
            InitializeComponent();
        }

        private void frmChartGenre_Load(object sender, EventArgs e)
        {
            LoadGenreData();
        }

        private void LoadGenreData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT Genre_Name, COUNT(*) AS Movie_Count FROM Movie INNER JOIN Genre ON Movie.GenreID = Genre.GenreID GROUP BY Genre_Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    chartGenre.Series.Clear();
                    chartGenre.Series.Add("Number of Movies");
                    chartGenre.Series["Number of Movies"].ChartType = SeriesChartType.Column;

                    // Mảng màu cột
                    System.Drawing.Color[] columnColors = new System.Drawing.Color[] {
                        System.Drawing.Color.Red,
                        System.Drawing.Color.Blue,
                        System.Drawing.Color.Green,
                        System.Drawing.Color.Yellow,
                        System.Drawing.Color.Orange
                    };

                    int colorIndex = 0; // Chỉ số của mảng màu

                    foreach (DataRow row in dt.Rows)
                    {
                        string genreName = row["Genre_Name"].ToString();
                        int movieCount = Convert.ToInt32(row["Movie_Count"]);

                        // Thêm cột vào biểu đồ và sử dụng màu từ mảng màu cột
                        chartGenre.Series["Number of Movies"].Points.AddXY(genreName, movieCount);
                        chartGenre.Series["Number of Movies"].Points[colorIndex].Color = columnColors[colorIndex];

                        // Tăng chỉ số mảng màu
                        colorIndex = (colorIndex + 1) % columnColors.Length;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error loading data: " + ex.Message);
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
