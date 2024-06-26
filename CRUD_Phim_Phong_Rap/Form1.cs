using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace CRUD_Phim_Phong_Rap
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection("Data Source=DESKTOP-RAAS25V;Initial Catalog=Tinh_CRUD_winform;Integrated Security=True");

        SqlCommand cmd;
        SqlDataAdapter adapt;
        DataTable dt;

        public Form1()
        {
            InitializeComponent();
            DisplayData();
        }

        // Hiển thị dữ liệu từ DB lên DataGridView
        private void DisplayData()
        {
            con.Open();
            dt = new DataTable();
            adapt = new SqlDataAdapter("select * from Phim", con);
            adapt.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("insert into Phim(TenPhimVN, TenPhimEN, Danhgia, NgayCongChieu, MaTL, AnhPhim, DemoVideo, TrangThai, Dotuoi, Dodai, Mota, Quocgia) values(@tenPhimVN, @tenPhimEN, @danhGia, @ngayCongChieu, @maTL, @anhPhim, @demoVideo, @trangThai, @doTuoi, @doDai, @moTa, @quocGia)", con);
            cmd.Parameters.AddWithValue("@tenPhimVN", txtTenphim.Text);
            cmd.Parameters.AddWithValue("@tenPhimEN", txtTenphimquocte.Text);
            cmd.Parameters.AddWithValue("@danhGia", Convert.ToDouble(txtDanhgia.Text));
            cmd.Parameters.AddWithValue("@ngayCongChieu", dtpCongchieu.Value.Date);
            cmd.Parameters.AddWithValue("@maTL", txtTheloai.Text);
            cmd.Parameters.AddWithValue("@anhPhim", txtAnhphim.Text);
            cmd.Parameters.AddWithValue("@demoVideo", txtDemovideo.Text);
            cmd.Parameters.AddWithValue("@trangThai", txtTrangthai.Text);
            cmd.Parameters.AddWithValue("@doTuoi", Convert.ToInt32(txtDotuoi.Text));
            cmd.Parameters.AddWithValue("@doDai", Convert.ToInt32(txtDodai.Text));
            cmd.Parameters.AddWithValue("@moTa", txtMota.Text);
            cmd.Parameters.AddWithValue("@quocGia", txtQuocgia.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Record Inserted Successfully");
            DisplayData();
            ClearData();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd = new SqlCommand("update Phim set TenPhimVN=@tenPhimVN, TenPhimEN=@tenPhimEN, Danhgia=@danhGia, NgayCongChieu=@ngayCongChieu, MaTL=@maTL, AnhPhim=@anhPhim, DemoVideo=@demoVideo, TrangThai=@trangThai, Dotuoi=@doTuoi, Dodai=@doDai, Mota=@moTa, Quocgia=@quocGia where MaPhim=@maPhim", con);
            cmd.Parameters.AddWithValue("@maPhim", Convert.ToInt32(txtMaphim.Text));
            cmd.Parameters.AddWithValue("@tenPhimVN", txtTenphim.Text);
            cmd.Parameters.AddWithValue("@tenPhimEN", txtTenphimquocte.Text);
            cmd.Parameters.AddWithValue("@danhGia", Convert.ToDouble(txtDanhgia.Text));
            cmd.Parameters.AddWithValue("@ngayCongChieu", dtpCongchieu.Value.Date);
            cmd.Parameters.AddWithValue("@maTL", Convert.ToInt32(txtTheloai.Text));
            cmd.Parameters.AddWithValue("@anhPhim", txtAnhphim.Text);
            cmd.Parameters.AddWithValue("@demoVideo", txtDemovideo.Text);
            cmd.Parameters.AddWithValue("@trangThai", txtTrangthai.Text);
            cmd.Parameters.AddWithValue("@doTuoi", Convert.ToInt32(txtDotuoi.Text));
            cmd.Parameters.AddWithValue("@doDai", Convert.ToInt32(txtDodai.Text));
            cmd.Parameters.AddWithValue("@moTa", txtMota.Text);
            cmd.Parameters.AddWithValue("@quocGia", txtQuocgia.Text);

            cmd.ExecuteNonQuery();
            MessageBox.Show("Record Updated Successfully");
            con.Close();
            DisplayData();
            ClearData();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtMaphim.Text != "")
            {
                con.Open();
                cmd = new SqlCommand("delete Phim where MaPhim=@maPhim", con);
                cmd.Parameters.AddWithValue("@maPhim", Convert.ToInt32(txtMaphim.Text));
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("Record Deleted Successfully!");
                DisplayData();
                ClearData();
            }
            else
            {
                MessageBox.Show("Please Select Record to Delete");
            }
        }

        private void ClearData()
        {
            txtMaphim.Text = "";
            txtTenphim.Text = "";
            txtTenphimquocte.Text = "";
            txtDanhgia.Text = "";
            dtpCongchieu.Value = DateTime.Now;
            txtTheloai.Text = "";
            txtAnhphim.Text = "";
            txtDemovideo.Text = "";
            txtTrangthai.Text = "";
            txtDotuoi.Text = "";
            txtDodai.Text = "";
            txtMota.Text = "";
            txtQuocgia.Text = "";
        }

        private void dataGridView1_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        { 
            txtMaphim.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtTenphim.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtTenphimquocte.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtDanhgia.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            dtpCongchieu.Value = Convert.ToDateTime(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString());
            txtTheloai.Text = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
            txtAnhphim.Text = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
            txtDemovideo.Text = dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString();
            txtTrangthai.Text = dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString();
            txtDotuoi.Text = dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString();
            txtDodai.Text = dataGridView1.Rows[e.RowIndex].Cells[10].Value.ToString();
            txtMota.Text = dataGridView1.Rows[e.RowIndex].Cells[11].Value.ToString();
            txtQuocgia.Text = dataGridView1.Rows[e.RowIndex].Cells[12].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
