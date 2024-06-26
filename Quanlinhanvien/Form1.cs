using System;
using System.Drawing;
using System.Windows.Forms;

namespace Quanlinhanvien
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Validate dữ liệu đầu vào nếu cần
            if (string.IsNullOrWhiteSpace(txtHoTen.Text) || string.IsNullOrWhiteSpace(txtDiaChi.Text) || string.IsNullOrWhiteSpace(txtDienThoai.Text))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!");
                return;
            }

            // Tạo một mục mới cho ListView
            ListViewItem lvi = lvNhanVien.Items.Add(txtHoTen.Text); // Thêm Họ tên vào cột đầu tiên
            lvi.SubItems.Add(dtpNgaySinh.Value.ToShortDateString()); // Thêm Ngày sinh vào cột thứ hai
            lvi.SubItems.Add(txtDienThoai.Text); // Thêm Điện thoại vào cột thứ ba
            lvi.SubItems.Add(txtDiaChi.Text); // Thêm Địa chỉ vào cột thứ tư

            // Xóa văn bản trong TextBoxes
            txtHoTen.Text = "";
            dtpNgaySinh.Value = DateTime.Now; // Đặt lại ngày giá trị mặc định cho DateTimePicker
            txtDiaChi.Text = "";
            txtDienThoai.Text = "";
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                lvNhanVien.Items.Remove(lvNhanVien.SelectedItems[0]);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (lvNhanVien.SelectedItems.Count > 0) // Kiểm tra đã chọn ít nhất một mục trong ListView
            {
                ListViewItem selectedItem = lvNhanVien.SelectedItems[0];

                // Kiểm tra có đủ SubItems không
                if (selectedItem.SubItems.Count >= 4)
                {
                    selectedItem.SubItems[0].Text = txtHoTen.Text; // Họ tên
                    selectedItem.SubItems[1].Text = dtpNgaySinh.Value.ToShortDateString(); // Ngày sinh
                    selectedItem.SubItems[2].Text = txtDienThoai.Text; // Điện thoại
                    selectedItem.SubItems[3].Text = txtDiaChi.Text; // Địa chỉ
                }
                else
                {
                    // Xử lý nếu không đủ SubItems
                }
            }
        }

        private void lvNhanVien_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Kiểm tra xem có mục nào được chọn không
            if (lvNhanVien.SelectedItems.Count > 0)
            {
                // Duyệt qua tất cả các mục trong ListView để đặt lại màu sắc
                foreach (ListViewItem item in lvNhanVien.Items)
                {
                    item.BackColor = SystemColors.Window; // Đặt màu sắc mặc định cho tất cả các mục
                    item.ForeColor = SystemColors.ControlText; // Đặt màu văn bản mặc định cho tất cả các mục
                }

                // Đặt màu sắc cho mục được chọn
                lvNhanVien.SelectedItems[0].BackColor = Color.Blue; // Màu nền
                lvNhanVien.SelectedItems[0].ForeColor = Color.White; // Màu văn bản

                // Lấy mục được chọn
                ListViewItem selectedItem = lvNhanVien.SelectedItems[0];

                // Kiểm tra xem mục được chọn có đủ thông tin không
                if (selectedItem.SubItems.Count >= 4)
                {
                    // Lấy thông tin từ mục được chọn và gán vào các ô nhập tương ứng
                    txtHoTen.Text = selectedItem.SubItems[0].Text; // Họ tên
                    dtpNgaySinh.Text = selectedItem.SubItems[1].Text; // Ngày sinh
                    txtDienThoai.Text = selectedItem.SubItems[2].Text; // Điện thoại
                    txtDiaChi.Text = selectedItem.SubItems[3].Text; // Địa chỉ
                }
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
