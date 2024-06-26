using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace testSQLAdo
{
    public partial class Form1 : Form
    {
        private string connectionString = @"server=DESKTOP-RAAS25V;database=HocSinhScrip;Integrated Security=True";

        public Form1()
        {
            InitializeComponent();
            LayDuLieuLop();
        }

        private void LayDuLieuLop()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    SqlDataAdapter da = new SqlDataAdapter("SELECT MaLop, TenLop, SiSo FROM Lop", con);
                    DataTable dtLop = new DataTable();
                    da.Fill(dtLop);
                    con.Close();
                    dataGridView1.DataSource = dtLop;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dataGridView1.SelectedRows[0];
                txtMaLop.Text = row.Cells["MaLop"].Value.ToString();
                txtTenLop.Text = row.Cells["TenLop"].Value.ToString();
                txtSiSo.Text = row.Cells["SiSo"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string lenhInsert = $"INSERT INTO Lop(MaLop, TenLop, SiSo) VALUES ('{txtMaLop.Text}', '{txtTenLop.Text}', '{txtSiSo.Text}')";
                    using (SqlCommand cmd = new SqlCommand(lenhInsert, con))
                    {
                        cmd.ExecuteNonQuery();
                    }
                }

                LayDuLieuLop(); // Cập nhật lại dữ liệu sau khi thêm
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "UPDATE Lop SET TenLop = @TenLop, SiSo = @SiSo WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        cmd.Parameters.AddWithValue("@TenLop", txtTenLop.Text);
                        cmd.Parameters.AddWithValue("@SiSo", txtSiSo.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                LayDuLieuLop(); // Cập nhật lại dữ liệu sau khi sửa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "DELETE FROM Lop WHERE MaLop = @MaLop";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", txtMaLop.Text);
                        cmd.ExecuteNonQuery();
                    }
                }

                LayDuLieuLop(); // Cập nhật lại dữ liệu sau khi xóa
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
