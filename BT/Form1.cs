using System;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            // Gọi phương thức thực hiện đổ dữ liệu lên biểu đồ
            LoadChartData();
        }

        private void LoadChartData()
        {
            // Kết nối với cơ sở dữ liệu
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Mở kết nối
                connection.Open();

                // Truy vấn dữ liệu từ cơ sở dữ liệu
                string query = "SELECT Food_Name, Quantity FROM Food";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Xóa sạch dữ liệu cũ trong biểu đồ
                chart2.Series.Clear();

                // Tạo một chuỗi dữ liệu (Series)
                Series series1 = new Series("Quantity");
                series1.ChartType = SeriesChartType.Column; // Loại biểu đồ cột

                // Đổ dữ liệu vào chuỗi dữ liệu của biểu đồ
                while (reader.Read())
                {
                    string foodName = reader.GetString(0);
                    int quantity = reader.GetInt32(1);
                    series1.Points.AddXY(foodName, quantity);
                }

                // Thêm chuỗi dữ liệu vào biểu đồ
                chart2.Series.Add(series1);

                // Đóng kết nối
                connection.Close();
            }
        }
    }
}
