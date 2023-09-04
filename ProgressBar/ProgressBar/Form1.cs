using System.Runtime.CompilerServices;

namespace ProgressBar
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer myTimer = new System.Windows.Forms.Timer();

        public Form1()
        {
            InitializeComponent();
            myTimer.Tick += new EventHandler(TimerEventProcessor);
        }

        private void TimerEventProcessor(Object myObject,
                                            EventArgs myEventArgs)
        {
            if (progressBar1.Value == 100)
            {
                myTimer.Stop();
                button1.Enabled = true;
                button1.Text = "close";
                return;
            }
            progressBar1.Value += 10;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (progressBar1.Value == 0)
            {
                myTimer.Interval = 500;
                myTimer.Start();
                button1.Enabled = false;
            }
            if (progressBar1.Value == 100)
            {
                this.Close();
            }
        }
    }
}