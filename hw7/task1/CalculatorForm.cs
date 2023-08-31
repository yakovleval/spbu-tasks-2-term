namespace task1
{
    public partial class CalculatorForm : Form
    {
        private Calculator calculator = new();
        public CalculatorForm()
        {
            InitializeComponent();

            numberDisplay.DataBindings.Add("Text", calculator, "NumberDisplay", true, DataSourceUpdateMode.OnPropertyChanged);
            operationDisplay.DataBindings.Add("Text", calculator, "OperationDisplay", true, DataSourceUpdateMode.OnPropertyChanged);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void OnDigitClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            calculator.AddDigit(button.Text);
        }

        private void OnClearClick(object sender, EventArgs e)
        {
            calculator.Clear();
        }

        private void OnEqualsClick(object sender, EventArgs e)
        {
            calculator.Equals();
        }


        private void OnOperatorClick(object sender, EventArgs e)
        {
            var button = (Button)sender;
            calculator.AddOp(button.Text);
        }

        private void OnNegateClick(object sender, EventArgs e)
        {
            calculator.Negate();
        }
    }
}