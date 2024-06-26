using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace BaiSQLHocSinh
{
    public partial class Form1 : Form
    {
        private DataProvider dataProvider;

        public Form1()
        {
            InitializeComponent();

            // Khởi tạo một thể hiện của DataProvider với chuỗi kết nối cơ sở dữ liệu
            string connectionString = @"server=DESKTOP-RAAS25V;database=HocSinhScript;Integrated Security=True;";
            dataProvider = new DataProvider(connectionString);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadDataToComboBoxLop();
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboLop.SelectedValue != null)
            {
                string selectedMaLop = cboLop.SelectedValue.ToString();
                cboLop.Text = selectedMaLop; // Hiển thị mã lớp vào textbox
                LoadDataToGridViewHocSinh(selectedMaLop);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maLop = cboLop.SelectedValue.ToString();
            string tenHS = txtTen.Text;
            string diaChi = txtDiaChi.Text;
            string DTB = txtDTB.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            // Thêm học sinh vào cơ sở dữ liệu
            string sql = $"INSERT INTO HocSinh (MaHS, TenHS, NgaySinh, DiaChi, DTB, MaLop) VALUES ('{Guid.NewGuid()}', '{tenHS}', '{ngaySinh}', '{diaChi}', '{DTB}', '{maLop}')";
            if (dataProvider.TruyVan_XuLy(sql))
            {
                MessageBox.Show("Thêm học sinh thành công!");
                // Refresh DataGridView sau khi thêm thành công
                LoadDataToGridViewHocSinh(maLop);
            }
            else
            {
                MessageBox.Show("Thêm học sinh không thành công!");
            }

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string maHS = txtMa.Text;
            string tenHS = txtTen.Text;
            string diaChi = txtDiaChi.Text;
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string dtb = txtDTB.Text;
            // Cập nhật thông tin học sinh trong cơ sở dữ liệu
            string sql = $"UPDATE HocSinh SET TenHS = '{tenHS}', DiaChi = '{diaChi}', NgaySinh = '{ngaySinh}', DTB = '{dtb}' WHERE MaHS = '{maHS}'";
            if (dataProvider.TruyVan_XuLy(sql))
            {
                MessageBox.Show("Cập nhật thông tin học sinh thành công!");
                // Refresh DataGridView sau khi cập nhật thành công
                LoadDataToGridViewHocSinh(dataGridView1.CurrentRow.Cells["MaLop"].Value.ToString());
            }
            else
            {
                MessageBox.Show("Cập nhật thông tin học sinh không thành công!");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string maHS = txtMa.Text;
            // Xóa học sinh khỏi cơ sở dữ liệu
            string sql = $"DELETE FROM HocSinh WHERE MaHS = '{maHS}'";
            if (dataProvider.TruyVan_XuLy(sql))
            {
                MessageBox.Show("Xóa học sinh thành công!");
                // Refresh DataGridView sau khi xóa thành công
                LoadDataToGridViewHocSinh(dataGridView1.CurrentRow.Cells["MaLop"].Value.ToString());
            }
            else
            {
                MessageBox.Show("Xóa học sinh không thành công!");
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string keyword = txtMa.Text;
            // Tìm kiếm học sinh theo tên
            string sql = $"SELECT * FROM HocSinh WHERE TenHS LIKE '%{keyword}%'";
            DataTable resultTable = dataProvider.TruyVan_LayDuLieu(sql);
            dataGridView1.DataSource = resultTable;
        }

        private void LoadDataToComboBoxLop()
        {
            // Đổ dữ liệu vào combobox Lớp
            DataTable lopTable = dataProvider.TruyVan_LayDuLieu("SELECT * FROM Lop");
            cboLop.DataSource = lopTable;
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
        }

        private void LoadDataToGridViewHocSinh(string maLop)
        {
            // Lấy học sinh theo lớp (đang chọn)
            string sql = $"SELECT * FROM HocSinh WHERE MaLop = '{maLop}'";
            DataTable hocSinhTable = dataProvider.TruyVan_LayDuLieu(sql);
            dataGridView1.DataSource = hocSinhTable;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0) // Đảm bảo chỉ xử lý khi người dùng chọn một dòng hợp lệ
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                // Lấy dữ liệu từ các cột của dòng đã chọn và hiển thị lên các textbox tương ứng
                txtMa.Text = row.Cells["MaHS"].Value.ToString();
                txtTen.Text = row.Cells["TenHS"].Value.ToString();
                txtDiaChi.Text = row.Cells["DiaChi"].Value.ToString();
                dtpNgaySinh.Value = Convert.ToDateTime(row.Cells["NgaySinh"].Value);
                txtDTB.Text = row.Cells["DTB"].Value.ToString();
            }
        }
    }

    public class DataProvider
    {
        private string connectionString;

        public DataProvider(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public bool TruyVan_XuLy(string sql)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình thực thi truy vấn: " + ex.Message);
                return false;
            }
        }

        public DataTable TruyVan_LayDuLieu(string sql)
        {
            DataTable resultTable = new DataTable();
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    using (SqlDataAdapter da = new SqlDataAdapter(sql, con))
                    {
                        da.Fill(resultTable);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Lỗi trong quá trình truy vấn dữ liệu: " + ex.Message);
            }
            return resultTable;
        }
    }
}
