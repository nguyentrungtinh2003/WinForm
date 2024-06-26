using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartRevenue : Form
    {
        private string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";

        public frmChartRevenue()
        {
            InitializeComponent();
        }

        private void frmChartRevenue_Load(object sender, EventArgs e)
        {
            LoadRevenueByTimeData();
        }

        private void LoadRevenueByTimeData()
        {
            string query = "SELECT FORMAT(Payment_Date, 'MM/yyyy') AS MonthYear, SUM(Total_Amount) AS TotalRevenue FROM Revenue GROUP BY FORMAT(Payment_Date, 'MM/yyyy')";

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
                    chartRevenue.Series.Add("Doanh thu");
                    chartRevenue.Series["Doanh thu"].ChartType = SeriesChartType.Column;

                    // Thay đổi màu của cột
                    chartRevenue.Series["Doanh thu"].Color = System.Drawing.Color.Green;

                    foreach (DataRow row in dt.Rows)
                    {
                        string monthYear = row["MonthYear"].ToString();
                        double totalRevenue = Convert.ToDouble(row["TotalRevenue"]);
                        chartRevenue.Series["Doanh thu"].Points.AddXY(monthYear, totalRevenue);
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
