namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer progressBarUpdaterTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            progressBarUpdaterTimer.Tick += new EventHandler(TimerEventProcessor);
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (progressBar.Value == 100)
            {
                progressBarUpdaterTimer.Stop();
                startStopButton.Enabled = true;
                startStopButton.Text = "close";
                return;
            }
            progressBar.Value += 10;
        }

        private void StartStopButton_Click(object sender, EventArgs e)
        {
            if (progressBar.Value == 0)
            {
                progressBarUpdaterTimer.Interval = 500;
                progressBarUpdaterTimer.Start();
                startStopButton.Enabled = false;
            }
            if (progressBar.Value == 100)
            {
                this.Close();
            }
        }
    }
}