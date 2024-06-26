using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartAge : Form
    {
        public frmChartAge()
        {
            InitializeComponent();
        }

        private void frmChartAge_Load(object sender, EventArgs e)
        {
            LoadAgeRequiredData();
        }

        private void LoadAgeRequiredData()
        {
            string chuoiKetNoi = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string truyVan = "SELECT Age_Required, COUNT(*) AS SoLuongPhim FROM Movie GROUP BY Age_Required";

            using (SqlConnection ketNoi = new SqlConnection(chuoiKetNoi))
            {
                SqlCommand lenh = new SqlCommand(truyVan, ketNoi);
                SqlDataAdapter adapter = new SqlDataAdapter(lenh);
                DataTable dt = new DataTable();

                try
                {
                    ketNoi.Open();
                    adapter.Fill(dt);

                    chartAge.Series.Clear();
                    chartAge.ChartAreas[0].AxisX.Interval = 1;
                    chartAge.ChartAreas[0].AxisX.MajorGrid.LineWidth = 0;
                    chartAge.ChartAreas[0].AxisY.MajorGrid.LineWidth = 0;

                    foreach (DataRow dong in dt.Rows)
                    {
                        int doTuoiYeuCau = Convert.ToInt32(dong["Age_Required"]);
                        int soLuongPhim = Convert.ToInt32(dong["SoLuongPhim"]);

                        // Tạo một màu ngẫu nhiên cho mỗi cột
                        Random random = new Random();
                        System.Drawing.Color randomColor = System.Drawing.Color.FromArgb(random.Next(256), random.Next(256), random.Next(256));

                        chartAge.Series.Add(doTuoiYeuCau.ToString());
                        chartAge.Series[doTuoiYeuCau.ToString()].Points.AddXY(doTuoiYeuCau, soLuongPhim);
                        chartAge.Series[doTuoiYeuCau.ToString()].ChartType = SeriesChartType.Column;
                        chartAge.Series[doTuoiYeuCau.ToString()].Color = randomColor;
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
