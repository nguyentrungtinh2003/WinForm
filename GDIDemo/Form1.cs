namespace GDIDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Color MauDangChon = Color.Black;
        private void btnChonMau_Click(object sender, EventArgs e)
        {
            var cd = new ColorDialog();
            cd.FullOpen = true;
            if (cd.ShowDialog() == DialogResult.OK)
            {
                MauDangChon = cd.Color;
                btnChonMau.BackColor = cd.Color;
            }
        }

        private void btnVeChu_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem liệu người dùng đã nhập x và y chưa
            if (!int.TryParse(txtX.Text, out int x) || !int.TryParse(txtY.Text, out int y))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ cho x và y.");
                return;
            }

            // Lấy đối tượng Graphics từ panel1
            using (Graphics g = panel1.CreateGraphics())
            {
                // Tạo một font mới
                Font font = new Font("Arial", 20, FontStyle.Bold);
                // Tạo một brush để vẽ chữ (trong trường hợp này, màu đen)
                Brush brush = Brushes.Black;
                // Vẽ chuỗi văn bản vào vị trí (x, y) trên panel1
                g.DrawString(txtNoiDung.Text, font, brush, x, y);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
