using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace demoLinQ
{
    public partial class Form1 : Form
    {
        QLHSDataContext db = new QLHSDataContext();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cboLop.DisplayMember = "TenLop";
            cboLop.ValueMember = "MaLop";
            cboLop.DataSource = db.Lops;

            cboLop.SelectedIndex = 0;
            LayHocSinhTheoLop();
        }

        private void LayHocSinhTheoLop()
        {
            var data = db.HocSinhs.Where(hs => hs.MaLop == cboLop.SelectedValue.ToString()).ToList();
            dataGridView1.DataSource = data;
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                var hs = new HocSinh
                {
                    MaHS = txtMa.Text,
                    TenHS = txtTen.Text,
                    DiaChi = txtDiachi.Text,
                    DTB = float.Parse(txtDTB.Text),
                    NgaySinh = dtpNgaysinh.Value,
                    MaLop = cboLop.SelectedValue.ToString()
                };

                db.HocSinhs.InsertOnSubmit(hs);
                db.SubmitChanges();
                LayHocSinhTheoLop();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm học sinh: " + ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                var hs = db.HocSinhs.SingleOrDefault(h => h.MaHS == txtMa.Text);
                if (hs != null)
                {
                    hs.TenHS = txtTen.Text;
                    hs.DiaChi = txtDiachi.Text;
                    hs.DTB = float.Parse(txtDTB.Text);
                    hs.NgaySinh = dtpNgaysinh.Value;

                    db.SubmitChanges();
                    LayHocSinhTheoLop();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy học sinh nào để sửa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa học sinh: " + ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                var hs = db.HocSinhs.SingleOrDefault(h => h.MaHS == txtMa.Text);
                if (hs != null)
                {
                    db.HocSinhs.DeleteOnSubmit(hs);
                    db.SubmitChanges();
                    LayHocSinhTheoLop();
                }
                else
                {
                    MessageBox.Show("Không tìm thấy học sinh để xóa.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa học sinh: " + ex.Message);
            }
        }

        private void cboLop_SelectedIndexChanged(object sender, EventArgs e)
        {
            LayHocSinhTheoLop();
        }
    }
}
