namespace MDIDemo
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }
        string lastLoginForm = "";
        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmLogin();
            if (string.IsNullOrEmpty(lastLoginForm))
            {
                lastLoginForm = "Login 1";
            }
            else
            {
                var newIndex = lastLoginForm.Split(" ")[1] + 1;
                lastLoginForm = $"Login {newIndex}";
            }
            form.Text = lastLoginForm;
            form.MdiParent = this;
            form.Show();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FrmSetting();
            form.MdiParent = this;
            form.Show();
        }

        private void horizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void verticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void systemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}
