using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            frmQLPhim f = new frmQLPhim();
            f.Owner = this;
            f.Show();
        }

        private void btnPhong_Click(object sender, EventArgs e)
        {
            frmQLPhongChieu f = new frmQLPhongChieu();
            f.Owner = this;
            f.Show();
        }

        private void btnRap_Click(object sender, EventArgs e)
        {
            frmQLRap f = new frmQLRap();
            f.Owner = this;
            f.Show();
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            frmQLSanPham f = new frmQLSanPham();
            f.Owner = this;
            f.Show();
        }

        private void btnXuatChieu_Click(object sender, EventArgs e)
        {
            frmQLXuatChieu f = new frmQLXuatChieu();
            f.Owner = this;
            f.Show();
        }

        private void btnLichSu_Click(object sender, EventArgs e)
        {
            frmQLLichSu f = new frmQLLichSu();
            f.Owner = this;
            f.Show();
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
            frmThongKeMenu f = new frmThongKeMenu();
            f.Owner = this;
            f.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
