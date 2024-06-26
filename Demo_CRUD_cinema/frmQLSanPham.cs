using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmQLSanPham : Form
    {
        public frmQLSanPham()
        {
            InitializeComponent();
            dataGridView1.CellClick += dataGridView1_CellClick;
            LoadData();
        }

        private void LoadData()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Food";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                dataGridView1.DataSource = dt;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                txtFoodID.Text = row.Cells["FoodID"].Value.ToString();
                txtFood_Name.Text = row.Cells["Food_Name"].Value.ToString();
                txtCategory.Text = row.Cells["Category"].Value.ToString();
                txtQuantity.Text = row.Cells["Quantity"].Value.ToString();
                txtPrice.Text = row.Cells["Price"].Value.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Food (FoodID, Food_Name, Category, Quantity, Price) VALUES (@FoodID, @Food_Name, @Category, @Quantity, @Price)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodID", txtFoodID.Text);
                command.Parameters.AddWithValue("@Food_Name", txtFood_Name.Text);
                command.Parameters.AddWithValue("@Category", txtCategory.Text);
                command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                command.Parameters.AddWithValue("@Price", txtPrice.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Sản phẩm đã được thêm thành công!");
                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "DELETE FROM Food WHERE FoodID = @FoodID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodID", txtFoodID.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Sản phẩm đã được xóa thành công!");
                LoadData();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "UPDATE Food SET Food_Name = @Food_Name, Category = @Category, Quantity = @Quantity, Price = @Price WHERE FoodID = @FoodID";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@FoodID", txtFoodID.Text);
                command.Parameters.AddWithValue("@Food_Name", txtFood_Name.Text);
                command.Parameters.AddWithValue("@Category", txtCategory.Text);
                command.Parameters.AddWithValue("@Quantity", txtQuantity.Text);
                command.Parameters.AddWithValue("@Price", txtPrice.Text);
                command.ExecuteNonQuery();
                MessageBox.Show("Thông tin sản phẩm đã được cập nhật thành công!");
                LoadData();
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
