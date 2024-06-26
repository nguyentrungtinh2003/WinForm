using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lap09Report
{
    public partial class Form1 : Form
    {
        private DataClasses1DataContext db;
        private List<HangHoaMua> dsmua;

        public Form1()
        {
            InitializeComponent();
            db = new DataClasses1DataContext();
            dsmua = new List<HangHoaMua>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Load data into the combobox
            cboHanghoa.DataSource = db.HangHoas;
            cboHanghoa.DisplayMember = "TenHH";
            cboHanghoa.ValueMember = "MaHH";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            int soluong;
            if (!int.TryParse(numHanghoa.Value.ToString(), out soluong))
            {
                MessageBox.Show("Số lượng không hợp lệ");
                return;
            }

            int mahh = (int)cboHanghoa.SelectedValue;
            HangHoaMua hcm = dsmua.Find(p => p.MaHH == mahh);
            if (hcm == null)
            {
                HangHoa hh = db.HangHoas.SingleOrDefault(p => p.MaHH == mahh);
                dsmua.Add(new HangHoaMua
                {
                    MaHH = hh.MaHH,
                    TenHH = hh.TenHH,
                    DonGia = hh.DonGia,
                    SoLuong = soluong
                });
            }
            else
            {
                hcm.SoLuong += soluong;
            }

            // Bind the data to dataGridView1 and refresh it
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dsmua;
            double tongTien = dsmua.Sum(item => item.ThanhTien);

            // Display total amount
            txtTongtien.Text = tongTien.ToString("N2");
        }
    }
}
