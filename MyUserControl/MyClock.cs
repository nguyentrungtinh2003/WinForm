namespace MyUserControl
{
    public partial class MyClock : UserControl
    {
        public MyClock()
        {
            InitializeComponent();
        }
    }

    const string START_TEXT = "Start";
    const string STOP_TEXT = "Stop";
    DateTime timeStart;
    private void btnStart_Click(object sender, EventArgs e)
    {
        if (btnStart.text == START_TEXT)
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
        lable1.Text = (DateTime.Now - timeStart).ToString();
    }

}