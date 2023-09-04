namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer progressBarUpdater = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            progressBarUpdater.Tick += new EventHandler(TimerEventProcessor);
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (progressBar.Value == 100)
            {
                progressBarUpdater.Stop();
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
                progressBarUpdater.Interval = 500;
                progressBarUpdater.Start();
                startStopButton.Enabled = false;
            }
            if (progressBar.Value == 100)
            {
                this.Close();
            }
        }
    }
}