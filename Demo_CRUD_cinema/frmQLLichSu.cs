using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using OfficeOpenXml; // Thêm thư viện EPPlus

namespace Demo_CRUD_cinema
{
    public partial class frmQLLichSu : Form
    {
        private DataTable historyData; // DataTable lưu trữ dữ liệu lịch sử

        public frmQLLichSu()
        {
            InitializeComponent();
            LoadHistoryData();
            CalculateTotalRevenue();
        }

        // Hàm tải dữ liệu lịch sử giao dịch
        public void LoadHistoryData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = "SELECT RevenueID, TicketID, Total_Amount, Payment_Date, 'Bán vé' AS Transaction_Type FROM Revenue " +
                           "UNION ALL " +
                           "SELECT BillID, TicketID, Total_Amount, Created_AT AS Payment_Date, 'Bán hàng' AS Transaction_Type FROM Bill";

            // Tạo câu truy vấn để lấy dữ liệu từ bảng Customer
            string customerQuery = "SELECT * FROM Customer";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                historyData = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(historyData);
                    dataGridView1.DataSource = historyData;

                    // Tạo một DataTable mới để lưu dữ liệu từ bảng Customer
                    DataTable customerData = new DataTable();

                    // Thực hiện truy vấn và điền dữ liệu vào DataTable customerData
                    SqlCommand customerCommand = new SqlCommand(customerQuery, connection);
                    SqlDataAdapter customerAdapter = new SqlDataAdapter(customerCommand);
                    customerAdapter.Fill(customerData);

                    // Kiểm tra xem DataTable customerData có cột "CustomerID" hay không trước khi gán nguồn dữ liệu cho dataGridView2
                    if (customerData.Columns.Contains("CustomerID"))
                    {
                        // Gán nguồn dữ liệu của dataGridView2 là DataTable chứa dữ liệu từ bảng Customer
                        dataGridView2.DataSource = customerData;
                    }
                    else
                    {
                        MessageBox.Show("Không có cột 'CustomerID' trong DataTable của bảng Customer.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message);
                }
            }
        }

        // Hàm tìm kiếm dữ liệu dựa trên từ khóa nhập vào
        public void SearchData(string keyword1, string keyword2)
        {
            // Tạo mới một đối tượng DataView từ DataTable của DataGridView1
            DataView dv1 = new DataView((DataTable)dataGridView1.DataSource);

            // Tạo mới một đối tượng DataView từ DataTable của DataGridView2
            DataView dv2 = new DataView((DataTable)dataGridView2.DataSource);

            // Áp dụng bộ lọc cho DataView của DataGridView1 với từ khóa từ txtSearch
            dv1.RowFilter = $"Convert(RevenueID, 'System.String') LIKE '%{keyword1}%' OR " +
                            $"Convert(Total_Amount, 'System.String') LIKE '%{keyword1}%' OR " +
                            $"Convert(Payment_Date, 'System.String') LIKE '%{keyword1}%' OR " +
                            $"Transaction_Type LIKE '%{keyword1}%'";

            // Kiểm tra xem keyword1 có thể chuyển đổi sang kiểu int hay không
            int keywordInt1;
            bool isKeywordInt1 = int.TryParse(keyword1, out keywordInt1);

            // Nếu keyword1 không phải là số, thêm điều kiện cho cột Transaction_Type với keyword1 là chuỗi
            if (!isKeywordInt1)
            {
                dv1.RowFilter += $" OR Convert(Transaction_Type, 'System.String') LIKE '%{keyword1}%'";
            }

            // Áp dụng bộ lọc cho DataView của DataGridView2 với từ khóa từ txtSearch2
            dv2.RowFilter = $"Convert(CustomerID, 'System.String') LIKE '%{keyword2}%' OR " +
                            $"Full_Name LIKE '%{keyword2}%' OR " +
                            $"Email LIKE '%{keyword2}%' OR " +
                            $"Convert(Phone_Number, 'System.String') LIKE '%{keyword2}%' OR " +
                            $"Address LIKE '%{keyword2}%' OR " +
                            $"Convert(Ismember, 'System.String') LIKE '%{keyword2}%'";

            // Kiểm tra xem có kết quả tìm kiếm trong DataView của DataGridView1 không
            if (dv1.Count > 0)
            {
                // Gán lại DataView đã lọc vào DataSource của DataGridView1
                dataGridView1.DataSource = dv1.ToTable();
                // Ẩn DataGridView2
             
               
            }
            else
            {
                // Nếu không có kết quả tìm kiếm trong DataView của DataGridView1 với keyword1, hiển thị lại dữ liệu ban đầu của DataGridView1
                dataGridView1.DataSource = historyData;
                // Hiển thị lại cả hai DataGridView
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                LoadHistoryData();
            }

            // Kiểm tra xem có kết quả tìm kiếm trong DataView của DataGridView2 không
            if (dv2.Count > 0)
            {
                // Gán lại DataView đã lọc vào DataSource của DataGridView2
                dataGridView2.DataSource = dv2.ToTable();
                // Ẩn DataGridView1
               
                
            }
            else
            {
                // Nếu không có kết quả tìm kiếm trong DataView của DataGridView2 với keyword2, hiển thị lại dữ liệu ban đầu của DataGridView2
                dataGridView2.DataSource = historyData;
                // Hiển thị lại cả hai DataGridView
                dataGridView1.Visible = true;
                dataGridView2.Visible = true;
                LoadHistoryData();
            }
        }


        // Sự kiện khi nhấn nút Tìm kiếm
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text.Trim();
            string keyword2 = txtSearch2.Text.Trim();
            SearchData(keyword,keyword2);
        }

        // Sự kiện khi thay đổi giá trị trong ô tìm kiếm
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword1 = txtSearch.Text.Trim();
            string keyword2 = txtSearch2.Text.Trim();
            SearchData(keyword1, keyword2);

            // Kiểm tra xem từ khóa tìm kiếm từ txtSearch có rỗng hay không
            if (string.IsNullOrWhiteSpace(keyword1))
            {
                // Nếu rỗng, gọi lại phương thức LoadHistoryData để hiển thị lại dữ liệu ban đầu
                LoadHistoryData();
            }
        }
        private void txtSearch2_TextChanged(object sender, EventArgs e)
        {
            string keyword1 = txtSearch.Text.Trim();
            string keyword2 = txtSearch2.Text.Trim();
            SearchData(keyword1, keyword2);

            // Kiểm tra xem từ khóa tìm kiếm từ txtSearch có rỗng hay không
            if (string.IsNullOrWhiteSpace(keyword2))
            {
                // Nếu rỗng, gọi lại phương thức LoadHistoryData để hiển thị lại dữ liệu ban đầu
                LoadHistoryData();
            }
        }

        // Hàm lọc dữ liệu theo thời gian
        private void FilterDataByTime(DateTime startDate, DateTime endDate)
        {
            DataView dv = historyData.DefaultView;
            dv.RowFilter = $"Payment_Date >= '{startDate}' AND Payment_Date <= '{endDate}'";
            dataGridView1.DataSource = dv.ToTable();
        }

        // Sự kiện khi nhấn nút Lọc theo thời gian
        private void btnFilter_Click(object sender, EventArgs e)
        {
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            FilterDataByTime(startDate, endDate);
        }

        // Sự kiện khi chọn một hàng trong DataGridView
        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RevenueID"].Value);
                // Hiển thị thông tin chi tiết về giao dịch khi chọn nó từ danh sách
                ShowTransactionDetail(selectedID);
            }
        }

        // Hàm hiển thị thông tin chi tiết về giao dịch
        private void ShowTransactionDetail(int transactionID)
        {
            // Viết mã để hiển thị thông tin chi tiết về giao dịch ở đây
        }

        // Sự kiện khi nhấn nút Xuất dữ liệu
        private void btnExport_Click(object sender, EventArgs e)
        {
            // Viết mã để xuất dữ liệu lịch sử ra file Excel
            ExportToExcel();
        }

        // Hàm xuất dữ liệu ra file Excel
        private void ExportToExcel()
        {

            // Hàm xuất dữ liệu ra Excel sử dụng EPPlus

            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
            saveFileDialog.FileName = "LichSuGiaoDich.xlsx";
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileInfo file = new FileInfo(saveFileDialog.FileName);

                // Thiết lập LicenseContext
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

                using (ExcelPackage package = new ExcelPackage(file))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("LichSuGiaoDich");

                    // Copy dữ liệu từ DataGridView ra Excel
                    for (int i = 0; i < dataGridView1.Columns.Count; i++)
                    {
                        worksheet.Cells[1, i + 1].Value = dataGridView1.Columns[i].HeaderText;
                    }
                    for (int i = 0; i < dataGridView1.Rows.Count; i++)
                    {
                        for (int j = 0; j < dataGridView1.Columns.Count; j++)
                        {
                            worksheet.Cells[i + 2, j + 1].Value = dataGridView1.Rows[i].Cells[j].Value;
                        }
                    }

                    package.Save();
                }
                MessageBox.Show("Dữ liệu đã được xuất ra file Excel thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    

       
        // Sự kiện khi nhấn nút Xóa giao dịch
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Viết mã để xóa giao dịch được chọn từ lịch sử
            // Kiểm tra xem có hàng nào được chọn không
            if (dataGridView1.SelectedRows.Count > 0)
            {
                // Lấy ID của giao dịch cần xóa
                int selectedID = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells["RevenueID"].Value);

                // Hiển thị hộp thoại xác nhận xóa
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa giao dịch này?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Nếu người dùng chọn Yes, thực hiện xóa
                if (result == DialogResult.Yes)
                {
                    // Gọi hàm để xóa giao dịch
                    DeleteTransaction(selectedID);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một giao dịch để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Hàm xóa giao dịch từ lịch sử
        private void DeleteTransaction(int transactionID)
        {
            // Kiểm tra xem giao dịch thuộc bảng nào
            DataRow[] rows = historyData.Select($"RevenueID = {transactionID}");
            if (rows.Length > 0)
            {
                // Nếu giao dịch thuộc bảng Revenue, thực hiện xóa từ bảng Revenue
                string deleteRevenueQuery = $"DELETE FROM Revenue WHERE RevenueID = {transactionID}";
                // Thực hiện xóa từ bảng Revenue
                ExecuteQuery(deleteRevenueQuery);
            }
            else
            {
                // Nếu không, giao dịch thuộc bảng Bill, thực hiện xóa từ bảng Bill
                string deleteBillQuery = $"DELETE FROM Bill WHERE BillID = {transactionID}";
                // Thực hiện xóa từ bảng Bill
                ExecuteQuery(deleteBillQuery);
            }
        }

        // Hàm thực hiện câu lệnh truy vấn không trả về kết quả
        private void ExecuteQuery(string query)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Giao dịch đã được xóa thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadHistoryData(); // Tải lại dữ liệu sau khi xóa
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi xóa giao dịch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        // Sự kiện khi nhấn nút Báo cáo và thống kê
        private void btnReport_Click(object sender, EventArgs e)
        {
            // Viết mã để tạo báo cáo và thống kê dựa trên dữ liệu lịch sử
            DisplayReport();
        }
        // Hàm hiển thị báo cáo trong ReportViewer
        private void DisplayReport()
        {
            ReportViewer reportViewer = new ReportViewer();
            reportViewer.Dock = DockStyle.Fill;

            // Kết nối đến cơ sở dữ liệu và lấy dữ liệu cho báo cáo
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string query = @"SELECT 
                        Ticket.MovieID, 
                        Movie.Movie_Name, 
                        COUNT(*) AS Total_Tickets_Sold, 
                        SUM(Ticket.Quantity * Ticket.Price) AS Total_Revenue 
                    FROM 
                        Ticket 
                    INNER JOIN 
                        Movie ON Ticket.MovieID = Movie.MovieID 
                    GROUP BY 
                        Ticket.MovieID, 
                        Movie.Movie_Name";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable reportData = new DataTable();

                try
                {
                    connection.Open();
                    adapter.Fill(reportData);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi truy vấn dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Thiết lập nguồn dữ liệu cho report
                ReportDataSource reportDataSource = new ReportDataSource("DataSet1", reportData);
                reportViewer.LocalReport.DataSources.Add(reportDataSource);

                // Thiết lập đường dẫn đến tệp Report trong dự án của bạn
                reportViewer.LocalReport.ReportPath = "Report1.rdlc";

                // Hiển thị report trong form mới
                Form reportForm = new Form();
                reportForm.Controls.Add(reportViewer);
                reportForm.WindowState = FormWindowState.Maximized;
                reportForm.ShowDialog();
            }
        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //tong doanh thu
        // Hàm tính tổng doanh thu từ bảng Revenue và Bill
        private void CalculateTotalRevenue()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            string revenueQuery = "SELECT SUM(Total_Amount) AS TotalRevenue FROM Revenue";
            string billQuery = "SELECT SUM(Total_Amount) AS TotalRevenue FROM Bill";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand revenueCommand = new SqlCommand(revenueQuery, connection);
                    SqlCommand billCommand = new SqlCommand(billQuery, connection);

                    connection.Open();

                    // Tính tổng doanh thu từ bán vé xem phim
                    object revenueResult = revenueCommand.ExecuteScalar();
                    if (revenueResult != DBNull.Value)
                    {
                        txtDoanhthu.Text = revenueResult.ToString();
                    }
                    else
                    {
                        txtDoanhthu.Text = "0";
                    }

                    // Tính tổng doanh thu từ bán hàng
                    object billResult = billCommand.ExecuteScalar();
                    if (billResult != DBNull.Value)
                    {
                        txtDoanhthubanhang.Text = billResult.ToString();
                    }
                    else
                    {
                        txtDoanhthubanhang.Text = "0";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tính toán tổng doanh thu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        // tui co datagridview2 tui muon nhap vao txtSearch thi se hien thi du lieu co lien quan o datagridview1 va datagridview2 , trong datagridview2 tui muon gien thi thong tin cua customer

    }
}
