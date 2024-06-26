using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TestAdoSQL
{
    public partial class FrmManaStu : Form
    {
        private string connectionString = "Server=DESKTOP-RAAS25V;Database=HocSinhScript;Integrated Security=SSPI;";

        public FrmManaStu()
        {
            InitializeComponent();
        }

        private void FrmManaStu_Load(object sender, EventArgs e)
        {
            LoadDataGridViewData();
            btnThem.Click += btnThem_Click;
            btnXoa.Click += btnXoa_Click;
            btnSua.Click += btnSua_Click;
        }

        private void LoadDataGridViewData()
        {
            try
            {
                DataTable dataTable = new DataTable();

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT MaLop, TenLop, SiSo FROM Lop";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataTable);
                        }
                    }
                }

                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu từ cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                string maLop = txtMaLop.Text;
                string tenLop = txtTenLop.Text;
                int siSo;

                if (!int.TryParse(txtSiSo.Text, out siSo))
                {
                    MessageBox.Show("Sĩ số phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    con.Open();
                    string sql = "INSERT INTO Lop(MaLop, TenLop, SiSo) VALUES (@MaLop, @TenLop, @SiSo)";
                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@MaLop", maLop);
                        cmd.Parameters.AddWithValue("@TenLop", tenLop);
                        cmd.Parameters.AddWithValue("@SiSo", siSo);
                        cmd.ExecuteNonQuery();
                    }
                }

                LoadDataGridViewData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string maLop = dataGridView1.SelectedRows[0].Cells["MaLop"].Value.ToString();

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string sql = "DELETE FROM Lop WHERE MaLop = @MaLop";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@MaLop", maLop);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadDataGridViewData();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một lớp học để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.SelectedRows.Count > 0)
                {
                    string maLop = txtMaLop.Text;
                    string tenLop = txtTenLop.Text;
                    int siSo;

                    if (!int.TryParse(txtSiSo.Text, out siSo))
                    {
                        MessageBox.Show("Sĩ số phải là một số nguyên dương.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        string sql = "UPDATE Lop SET TenLop = @TenLop, SiSo = @SiSo WHERE MaLop = @MaLop";
                        using (SqlCommand cmd = new SqlCommand(sql, con))
                        {
                            cmd.Parameters.AddWithValue("@MaLop", maLop);
                            cmd.Parameters.AddWithValue("@TenLop", tenLop);
                            cmd.Parameters.AddWithValue("@SiSo", siSo);
                            cmd.ExecuteNonQuery();
                        }
                    }

                    LoadDataGridViewData();
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một lớp học để sửa thông tin.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi sửa dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
