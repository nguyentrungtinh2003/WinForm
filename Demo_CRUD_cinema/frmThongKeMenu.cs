using System;
using System.Windows.Forms;

namespace Demo_CRUD_cinema
{
    public partial class frmThongKeMenu : Form
    {
        public frmThongKeMenu()
        {
            InitializeComponent();
        }

        private void btnGenre_Click(object sender, EventArgs e)
        {
            frmChartGenre f = new frmChartGenre();
            f.Owner = this;
            f.Show();
        }

        private void btnCountry_Click(object sender, EventArgs e)
        {
            frmChartCountry f = new frmChartCountry();
            f.Owner = this;
            f.Show();
        }

        private void btnRevenue_Click(object sender, EventArgs e)
        {
            frmChartRevenue f = new frmChartRevenue();
            f.Owner = this;
            f.Show();
        }

        private void btnState_Click(object sender, EventArgs e)
        {
            frmChartState f = new frmChartState();
            f.Owner = this;
            f.Show();
        }

        private void btnAge_Click(object sender, EventArgs e)
        {
            frmChartAge f = new frmChartAge();
            f.Owner = this;
            f.Show();
        }

        private void btnFood_Click(object sender, EventArgs e)
        {
            frmChartFood f = new frmChartFood();
            f.Owner = this;
            f.Show();
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            frmChartCustomer f = new frmChartCustomer();
            f.Owner = this;
            f.Show();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnShowtime_Click(object sender, EventArgs e)
        {
            frmChartPhim f = new frmChartPhim();
            f.Owner = this;
            f.Show();
        }
    }
}
