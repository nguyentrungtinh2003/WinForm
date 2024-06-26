namespace MyUserControl2
{
    public partial class MyClock1 : UserControl
    {
        public MyClock1()
        {
            InitializeComponent();
        }

        const string START_TEXT = "Start";
        const string STOP_TEXT = "Stop";
        int lapstep = 0;
        const int LapCount = 5;
        DateTime timeStart;
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (btnStart.Text == START_TEXT)
            {
                btnStart.Text = STOP_TEXT;
                timer1.Enabled = true;
                timeStart = DateTime.Now;
            }
            else
            {
                btnStart.Text = START_TEXT;
                timer1.Enabled = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            lblDongHo.Text = (DateTime.Now - timeStart).ToString();
        }

        private void UserControl1_Load(object sender, EventArgs e)
        {

        }

        private void btnlap_Click(object sender, EventArgs e)
        {
            lapstep++;
            StreamWriter sw = new StreamWriter("data.txt", true);
            sw.WriteLine(string.Format("lap {0}:{1}", lapstep, lblDongHo.Text));
            if(lapstep == LapCount)
            {
                sw.WriteLine("Ket thuc");
                lapstep = 0;
                timer1.Stop();
                btnStart.Text = "Start";
            }
            sw.Close();
        }
    }
}
