using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class TestForm : Form
    {
        private Panel rightPanel; // Biến local để lưu trữ panel phải

        public TestForm()
        {
            InitializeComponent();
            InitializeLayout();
            DisplayMovies();
        }

        private void InitializeLayout()
        {
            // Tạo SplitContainer để chia layout
            SplitContainer splitContainer = new SplitContainer();
            splitContainer.Dock = DockStyle.Fill;

            // Panel trái chứa navbar
            Panel leftPanel = new Panel();
            leftPanel.BackColor = System.Drawing.Color.LightGray;
            leftPanel.Width = 200;
            splitContainer.Panel1.Controls.Add(leftPanel); // Thêm Panel trái vào SplitContainer

            // Tạo các điều khiển trong navbar
            Label titleLabel = new Label();
            titleLabel.Text = "Navigation";
            titleLabel.Font = new System.Drawing.Font("Arial", 12, System.Drawing.FontStyle.Bold);
            titleLabel.Location = new System.Drawing.Point(10, 10);
            leftPanel.Controls.Add(titleLabel);

            // Thêm label "Search" và textbox để tìm kiếm phim
            Label searchLabel = new Label();
            searchLabel.Text = "Search:";
            searchLabel.Location = new System.Drawing.Point(10, 50);
            leftPanel.Controls.Add(searchLabel);

            TextBox searchTextBox = new TextBox();
            searchTextBox.Size = new System.Drawing.Size(180, 20);
            searchTextBox.Location = new System.Drawing.Point(10, 75);
            leftPanel.Controls.Add(searchTextBox);

            // Thêm nút "Search"
            Button searchButton = new Button();
            searchButton.Text = "Search";
            searchButton.Size = new System.Drawing.Size(80, 30);
            searchButton.Location = new System.Drawing.Point(10, 105);
            leftPanel.Controls.Add(searchButton);

            // Panel phải để hiển thị dữ liệu
            rightPanel = new Panel();
            rightPanel.AutoScroll = true; // Thêm thanh cuộn tự động
            splitContainer.Panel2.Controls.Add(rightPanel); // Thêm Panel phải vào SplitContainer

            // Thêm SplitContainer vào Form
            this.Controls.Add(splitContainer);
        }

        private void DisplayMovies()
        {
            string connectionString = "Data Source=DESKTOP-RAAS25V;Initial Catalog=CinemaFinaleS;Integrated Security=True";
            SqlConnection connection = new SqlConnection(connectionString);

            try
            {
                connection.Open();
                string query = "SELECT MovieID, Movie_Name, Release_Day, Movie_State, GenreID, Age_Required, Duration, Country FROM Movie";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                CreateHeaderRow();

                int panelTop = 30;
                while (reader.Read())
                {
                    CreateDataRow(reader, panelTop);
                    panelTop += 30;
                }

                connection.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void CreateHeaderRow()
        {
            string[] headers = { "Name", "Release Day", "State", "Genre", "Age Required", "Duration", "Country", "" };
            int labelWidth = rightPanel.Width / headers.Length;
            int labelLeft = 10;
            foreach (string header in headers)
            {
                Label headerLabel = new Label();
                headerLabel.Text = header;
                headerLabel.AutoSize = true;
                headerLabel.Location = new System.Drawing.Point(labelLeft, 5);
                rightPanel.Controls.Add(headerLabel);
                labelLeft += labelWidth;
            }
        }

        private void CreateDataRow(SqlDataReader reader, int panelTop)
        {
            string movieName = reader.GetString(1);
            DateTime releaseDay = reader.GetDateTime(2);
            string movieState = reader.GetString(3);
            int genreID = reader.GetInt32(4);
            int ageRequired = reader.GetInt32(5);
            int duration = reader.GetInt32(6);
            string country = reader.GetString(7);

            string genre = GetGenreName(genreID);

            Panel moviePanel = new Panel();
            moviePanel.BorderStyle = BorderStyle.FixedSingle;
            moviePanel.Size = new System.Drawing.Size(rightPanel.Width, 30);
            moviePanel.Location = new System.Drawing.Point(0, panelTop);

            string[] values = { movieName, releaseDay.ToShortDateString(), movieState, genre, ageRequired.ToString(), duration.ToString(), country };
            int labelWidth = rightPanel.Width / values.Length;
            int labelLeft = 10;
            foreach (string value in values)
            {
                Label valueLabel = new Label();
                valueLabel.Text = value.Length > 20 ? value.Substring(0, 17) + "..." : value;
                valueLabel.AutoSize = true;
                valueLabel.Location = new System.Drawing.Point(labelLeft, 5);
                moviePanel.Controls.Add(valueLabel);
                labelLeft += labelWidth;
            }

            Button editButton = new Button();
            editButton.Text = "Edit";
            editButton.Size = new System.Drawing.Size(50, 20);
            editButton.Location = new System.Drawing.Point(1050, 5);
            editButton.Tag = reader.GetInt32(0);
            editButton.Click += EditButton_Click;
            moviePanel.Controls.Add(editButton);

            Button deleteButton = new Button();
            deleteButton.Text = "Delete";
            deleteButton.Size = new System.Drawing.Size(50, 20);
            deleteButton.Location = new System.Drawing.Point(1110, 5);
            deleteButton.Tag = reader.GetInt32(0);
            deleteButton.Click += DeleteButton_Click;
            moviePanel.Controls.Add(deleteButton);

            rightPanel.Controls.Add(moviePanel);
        }

        private string GetGenreName(int genreID)
        {
            // Thay thế bằng mã thực tế để lấy tên thể loại từ cơ sở dữ liệu dựa trên GenreID
            return "";
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện chỉnh sửa phim
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            // Xử lý sự kiện xóa phim
        }
    }
}
