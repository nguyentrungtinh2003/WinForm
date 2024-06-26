using System;
using System.Windows.Forms;

namespace NguyenTrungTinh_2100002099
{
    public partial class frmTinhTong : Form
    {
        public frmTinhTong()
        {
            InitializeComponent();
        }

        private void btnTinh_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtN.Text, out int N) && double.TryParse(txtX.Text, out double X) && N >= 0)
            {
                double tong = 0;

                double mu = 1;
                string congthuc = "";
                for (int i = 2; i <= N; i++)
                {
                    mu *= i;
                    tong += Math.Pow(X, i) / mu;
                    if (i == 2)
                        congthuc += $"{X}^{i}/{i}!";
                    else
                        congthuc += $" + {X}^{i}/{i}!";
                }
                txtKQ.Text = Math.Round(tong + X, 3).ToString();
                txtCongthuc.Text = $" {X} + {congthuc}";
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị nguyên dương cho N và số thực cho X.", "Lỗi Nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
