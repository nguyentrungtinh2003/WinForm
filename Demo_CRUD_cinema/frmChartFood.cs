using System;
using System.Data;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace Demo_CRUD_cinema
{
    public partial class frmChartFood : Form
    {
        public frmChartFood()
        {
            InitializeComponent();
        }

        private void frmChartFood_Load(object sender, EventArgs e)
        {
            LoadPopularFoodData();
        }

        private void LoadPopularFoodData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT TOP 5 Food_Name, Quantity FROM Food ORDER BY Quantity DESC";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dt = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(dt);

                    chartFood.Series.Clear();
                    chartFood.Series.Add("Số lượng");
                    chartFood.Series["Số lượng"].ChartType = SeriesChartType.Column;

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
                        string foodName = row["Food_Name"].ToString();
                        int quantity = Convert.ToInt32(row["Quantity"]);

                        // Sử dụng màu từ mảng màu cột
                        chartFood.Series["Số lượng"].Points.AddXY(foodName, quantity);
                        chartFood.Series["Số lượng"].Points[colorIndex].Color = columnColors[colorIndex];

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
