using System.Data;
using System.Data;
using System.Data.SqlClient;
namespace DemoAdoNet
{
    public partial class FrmLop : Form
    {
        public FrmLop()
        {
            InitializeComponent();
        }

        private void FrmLop_Load(object sender, EventArgs e)
        {
            LayDuLieuLop();
        }

        private void LayDuLieuLop()
        {
            SqlConnection con = new SqlConnection(@"server=DESKTOP-RAAS25;database=HocSinhScrip;Integrated Security=True");
            con.Open();
            SqlDataAdapter da = new SqlDataAdapter(con"SELECT MaLop, TenLop FROM Lop", con);
            DataTable dtLop = new DataTable();
            da.Fill(dtLop);
            con.Close;
            dataGridView1.DataSource = dtLop;
        }

    }
}
