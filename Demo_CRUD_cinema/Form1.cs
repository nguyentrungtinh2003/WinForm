using System;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Demo_CRUD_cinema
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Gọi phương thức tạo biểu đồ khi khởi tạo Form
            CreateChart();
        }

        private void CreateChart()
        {
            // Tạo một instance của control Chart
            Chart chart1 = new Chart();

            // Thiết lập kích thước và vị trí cho biểu đồ
            chart1.Size = new System.Drawing.Size(400, 300);
            chart1.Location = new System.Drawing.Point(50, 50);

            // Tạo một chuỗi dữ liệu (Series)
            Series series1 = new Series("Series1");

            // Thêm các điểm dữ liệu vào chuỗi
            series1.Points.AddXY("A", 10);
            series1.Points.AddXY("B", 20);
            series1.Points.AddXY("C", 30);
            series1.Points.AddXY("D", 40);

            // Thêm chuỗi dữ liệu vào biểu đồ
            chart1.Series.Add(series1);

            // Thêm biểu đồ vào Form
            this.Controls.Add(chart1);
        }
    }
}
