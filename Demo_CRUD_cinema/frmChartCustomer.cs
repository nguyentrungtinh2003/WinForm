using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartCustomer : Form
    {
        public frmChartCustomer()
        {
            InitializeComponent();
        }

        private void frmChartCustomer_Load(object sender, EventArgs e)
        {
            LoadCustomerData();
        }

        private void LoadCustomerData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT MONTH(Created_At_Time) AS Month, COUNT(*) AS Customer_Count FROM Users WHERE Created_At_Time IS NOT NULL GROUP BY MONTH(Created_At_Time)";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    chartCustomer.Series.Clear();
                    chartCustomer.Series.Add("Số lượng khách hàng mới");
                    chartCustomer.Series["Số lượng khách hàng mới"].ChartType = SeriesChartType.Column;

                    // Mảng màu cột
                    System.Drawing.Color[] columnColors = new System.Drawing.Color[] {
                        System.Drawing.Color.Red,
                        System.Drawing.Color.Blue,
                        System.Drawing.Color.Green,
                        System.Drawing.Color.Yellow,
                        System.Drawing.Color.Orange
                    };

                    int colorIndex = 0; // Index của mảng màu

                    foreach (DataRow row in dt.Rows)
                    {
                        int month = Convert.ToInt32(row["Month"]);
                        int customerCount = Convert.ToInt32(row["Customer_Count"]);

                        // Sử dụng màu từ mảng màu cột
                        chartCustomer.Series["Số lượng khách hàng mới"].Points.AddXY(month, customerCount);
                        chartCustomer.Series["Số lượng khách hàng mới"].Points[colorIndex].Color = columnColors[colorIndex];

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
