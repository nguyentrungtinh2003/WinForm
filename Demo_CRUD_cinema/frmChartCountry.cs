using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartCountry : Form
    {
        public frmChartCountry()
        {
            InitializeComponent();
        }

        private void frmChartCountry_Load(object sender, EventArgs e)
        {
            LoadCountryData();
        }

        private void LoadCountryData()
        {
            string chuoiKetNoi = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string truyVan = "SELECT Country, COUNT(*) AS SoLuongPhim FROM Movie GROUP BY Country";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                SqlCommand lenh = new SqlCommand(truyVan, ketNoi);
                SqlDataAdapter adapter = new SqlDataAdapter(lenh);
                DataTable dt = new DataTable();

                try
                {
                    ketNoi.Open();
                    adapter.Fill(dt);

                    chartCountry.Series.Clear();
                    chartCountry.Series.Add("Số lượng phim");
                    chartCountry.Series["Số lượng phim"].ChartType = SeriesChartType.Column;

                    // Mảng màu cột
                    System.Drawing.Color[] columnColors = new System.Drawing.Color[] {
                        System.Drawing.Color.Red,
                        System.Drawing.Color.Blue,
                        System.Drawing.Color.Green,
                        System.Drawing.Color.Yellow,
                        System.Drawing.Color.Orange
                    };

                    int colorIndex = 0; // Index của mảng màu

                    foreach (DataRow dong in dt.Rows)
                    {
                        string quocGia = dong["Country"].ToString();
                        int soLuongPhim = Convert.ToInt32(dong["SoLuongPhim"]);

                        // Sử dụng màu từ mảng màu cột
                        chartCountry.Series["Số lượng phim"].Points.AddXY(quocGia, soLuongPhim);
                        chartCountry.Series["Số lượng phim"].Points[colorIndex].Color = columnColors[colorIndex];

                        // Tăng chỉ số mảng màu
                        colorIndex = (colorIndex + 1) % columnColors.Length;
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
