using System;
using System.Windows.Forms;

namespace AddName
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Thêm các mục vào ComboBox
            comboBox1.Items.Add("Mr");
            comboBox1.Items.Add("Ms");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem cả hai ô văn bản đã được điền đầy đủ hay chưa
            if (string.IsNullOrWhiteSpace(txtFirst.Text) || string.IsNullOrWhiteSpace(txtLast.Text))
            {
                MessageBox.Show("Vui lòng nhập cả tên và họ.");
                return;
            }

            // Lấy thông tin từ hai ô văn bản
            string firstName = txtFirst.Text;
            string lastName = txtLast.Text;

            // Kiểm tra xem người dùng đã chọn Mr hay Ms trong ComboBox
            string title = comboBox1.SelectedItem as string;

            if (string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Vui lòng chọn Mr hoặc Ms.");
                return;
            }

            // Kết hợp tiêu đề, tên và họ và thêm vào ListBox
            string fullName = title + " " + firstName + " " + lastName;
            listBox1.Items.Add(fullName);

            // Xóa nội dung của hai ô văn bản và Combobox sau khi thêm
            txtFirst.Clear();
            txtLast.Clear();
            comboBox1.SelectedIndex = -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Đóng form
            Close();
        }
    }
}
