namespace task1
{
    partial class CalculatorForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            tableLayoutPanel2 = new TableLayoutPanel();
            clearButton = new Button();
            negateButton = new Button();
            divideButton = new Button();
            nineButton = new Button();
            sevenButton = new Button();
            eightButton = new Button();
            fourButton = new Button();
            fiveButton = new Button();
            sixButton = new Button();
            oneButton = new Button();
            twoButton = new Button();
            threeButton = new Button();
            zeroButton = new Button();
            multiplyButton = new Button();
            subtractButton = new Button();
            addButton = new Button();
            equalsButton = new Button();
            numberDisplay = new Label();
            operationDisplay = new Label();
            calculatorBindingSource = new BindingSource(components);
            calculatorBindingSource1 = new BindingSource(components);
            tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)calculatorBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)calculatorBindingSource1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.ColumnCount = 4;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            tableLayoutPanel2.Controls.Add(clearButton, 0, 2);
            tableLayoutPanel2.Controls.Add(negateButton, 2, 2);
            tableLayoutPanel2.Controls.Add(divideButton, 3, 2);
            tableLayoutPanel2.Controls.Add(nineButton, 2, 3);
            tableLayoutPanel2.Controls.Add(sevenButton, 0, 3);
            tableLayoutPanel2.Controls.Add(eightButton, 1, 3);
            tableLayoutPanel2.Controls.Add(fourButton, 0, 4);
            tableLayoutPanel2.Controls.Add(fiveButton, 1, 4);
            tableLayoutPanel2.Controls.Add(sixButton, 2, 4);
            tableLayoutPanel2.Controls.Add(oneButton, 0, 5);
            tableLayoutPanel2.Controls.Add(twoButton, 1, 5);
            tableLayoutPanel2.Controls.Add(threeButton, 2, 5);
            tableLayoutPanel2.Controls.Add(zeroButton, 0, 6);
            tableLayoutPanel2.Controls.Add(multiplyButton, 3, 3);
            tableLayoutPanel2.Controls.Add(subtractButton, 3, 4);
            tableLayoutPanel2.Controls.Add(addButton, 3, 5);
            tableLayoutPanel2.Controls.Add(equalsButton, 3, 6);
            tableLayoutPanel2.Controls.Add(numberDisplay, 0, 1);
            tableLayoutPanel2.Controls.Add(operationDisplay, 0, 0);
            tableLayoutPanel2.Dock = DockStyle.Fill;
            tableLayoutPanel2.Location = new Point(0, 0);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 7;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857151F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857113F));
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel2.Size = new Size(800, 544);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // clearButton
            // 
            clearButton.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(clearButton, 2);
            clearButton.Dock = DockStyle.Fill;
            clearButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(3, 157);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(394, 71);
            clearButton.TabIndex = 0;
            clearButton.Text = "C";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += OnClearClick;
            // 
            // negateButton
            // 
            negateButton.AutoSize = true;
            negateButton.Dock = DockStyle.Fill;
            negateButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            negateButton.Location = new Point(403, 157);
            negateButton.Name = "negateButton";
            negateButton.Size = new Size(194, 71);
            negateButton.TabIndex = 1;
            negateButton.Text = "+/-";
            negateButton.UseVisualStyleBackColor = true;
            negateButton.Click += OnNegateClick;
            // 
            // divideButton
            // 
            divideButton.AutoSize = true;
            divideButton.Dock = DockStyle.Fill;
            divideButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            divideButton.Location = new Point(603, 157);
            divideButton.Name = "divideButton";
            divideButton.Size = new Size(194, 71);
            divideButton.TabIndex = 2;
            divideButton.Text = "÷";
            divideButton.UseVisualStyleBackColor = true;
            divideButton.Click += OnOperatorClick;
            // 
            // nineButton
            // 
            nineButton.AutoSize = true;
            nineButton.Dock = DockStyle.Fill;
            nineButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            nineButton.Location = new Point(403, 234);
            nineButton.Name = "nineButton";
            nineButton.Size = new Size(194, 71);
            nineButton.TabIndex = 3;
            nineButton.Text = "9";
            nineButton.UseVisualStyleBackColor = true;
            nineButton.MouseClick += OnDigitClick;
            // 
            // sevenButton
            // 
            sevenButton.AutoSize = true;
            sevenButton.Dock = DockStyle.Fill;
            sevenButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            sevenButton.Location = new Point(3, 234);
            sevenButton.Name = "sevenButton";
            sevenButton.Size = new Size(194, 71);
            sevenButton.TabIndex = 4;
            sevenButton.Text = "7";
            sevenButton.UseVisualStyleBackColor = true;
            sevenButton.MouseClick += OnDigitClick;
            // 
            // eightButton
            // 
            eightButton.AutoSize = true;
            eightButton.Dock = DockStyle.Fill;
            eightButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            eightButton.Location = new Point(203, 234);
            eightButton.Name = "eightButton";
            eightButton.Size = new Size(194, 71);
            eightButton.TabIndex = 5;
            eightButton.Text = "8";
            eightButton.UseVisualStyleBackColor = true;
            eightButton.MouseClick += OnDigitClick;
            // 
            // fourButton
            // 
            fourButton.AutoSize = true;
            fourButton.Dock = DockStyle.Fill;
            fourButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            fourButton.Location = new Point(3, 311);
            fourButton.Name = "fourButton";
            fourButton.Size = new Size(194, 71);
            fourButton.TabIndex = 6;
            fourButton.Text = "4";
            fourButton.UseVisualStyleBackColor = true;
            fourButton.MouseClick += OnDigitClick;
            // 
            // fiveButton
            // 
            fiveButton.AutoSize = true;
            fiveButton.Dock = DockStyle.Fill;
            fiveButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            fiveButton.Location = new Point(203, 311);
            fiveButton.Name = "fiveButton";
            fiveButton.Size = new Size(194, 71);
            fiveButton.TabIndex = 7;
            fiveButton.Text = "5";
            fiveButton.UseVisualStyleBackColor = true;
            fiveButton.MouseClick += OnDigitClick;
            // 
            // sixButton
            // 
            sixButton.AutoSize = true;
            sixButton.Dock = DockStyle.Fill;
            sixButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            sixButton.Location = new Point(403, 311);
            sixButton.Name = "sixButton";
            sixButton.Size = new Size(194, 71);
            sixButton.TabIndex = 8;
            sixButton.Text = "6";
            sixButton.UseVisualStyleBackColor = true;
            sixButton.MouseClick += OnDigitClick;
            // 
            // oneButton
            // 
            oneButton.AutoSize = true;
            oneButton.Dock = DockStyle.Fill;
            oneButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            oneButton.Location = new Point(3, 388);
            oneButton.Name = "oneButton";
            oneButton.Size = new Size(194, 71);
            oneButton.TabIndex = 9;
            oneButton.Text = "1";
            oneButton.UseVisualStyleBackColor = true;
            oneButton.MouseClick += OnDigitClick;
            // 
            // twoButton
            // 
            twoButton.AutoSize = true;
            twoButton.Dock = DockStyle.Fill;
            twoButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            twoButton.Location = new Point(203, 388);
            twoButton.Name = "twoButton";
            twoButton.Size = new Size(194, 71);
            twoButton.TabIndex = 10;
            twoButton.Text = "2";
            twoButton.UseVisualStyleBackColor = true;
            twoButton.MouseClick += OnDigitClick;
            // 
            // threeButton
            // 
            threeButton.AutoSize = true;
            threeButton.Dock = DockStyle.Fill;
            threeButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            threeButton.Location = new Point(403, 388);
            threeButton.Name = "threeButton";
            threeButton.Size = new Size(194, 71);
            threeButton.TabIndex = 11;
            threeButton.Text = "3";
            threeButton.UseVisualStyleBackColor = true;
            threeButton.MouseClick += OnDigitClick;
            // 
            // zeroButton
            // 
            zeroButton.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(zeroButton, 3);
            zeroButton.Dock = DockStyle.Fill;
            zeroButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            zeroButton.Location = new Point(3, 465);
            zeroButton.Name = "zeroButton";
            zeroButton.Size = new Size(594, 76);
            zeroButton.TabIndex = 12;
            zeroButton.Text = "0";
            zeroButton.UseVisualStyleBackColor = true;
            zeroButton.MouseClick += OnDigitClick;
            // 
            // multiplyButton
            // 
            multiplyButton.AutoSize = true;
            multiplyButton.Dock = DockStyle.Fill;
            multiplyButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            multiplyButton.Location = new Point(603, 234);
            multiplyButton.Name = "multiplyButton";
            multiplyButton.Size = new Size(194, 71);
            multiplyButton.TabIndex = 13;
            multiplyButton.Text = "×";
            multiplyButton.UseVisualStyleBackColor = true;
            multiplyButton.Click += OnOperatorClick;
            // 
            // subtractButton
            // 
            subtractButton.AutoSize = true;
            subtractButton.Dock = DockStyle.Fill;
            subtractButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            subtractButton.Location = new Point(603, 311);
            subtractButton.Name = "subtractButton";
            subtractButton.Size = new Size(194, 71);
            subtractButton.TabIndex = 14;
            subtractButton.Text = "-";
            subtractButton.UseVisualStyleBackColor = true;
            subtractButton.Click += OnOperatorClick;
            // 
            // addButton
            // 
            addButton.AutoSize = true;
            addButton.Dock = DockStyle.Fill;
            addButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(603, 388);
            addButton.Name = "addButton";
            addButton.Size = new Size(194, 71);
            addButton.TabIndex = 15;
            addButton.Text = "+";
            addButton.UseVisualStyleBackColor = true;
            addButton.Click += OnOperatorClick;
            // 
            // equalsButton
            // 
            equalsButton.AutoSize = true;
            equalsButton.Dock = DockStyle.Fill;
            equalsButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            equalsButton.Location = new Point(603, 465);
            equalsButton.Name = "equalsButton";
            equalsButton.Size = new Size(194, 76);
            equalsButton.TabIndex = 16;
            equalsButton.Text = "=";
            equalsButton.UseVisualStyleBackColor = true;
            equalsButton.Click += OnEqualsClick;
            // 
            // numberDisplay
            // 
            numberDisplay.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(numberDisplay, 4);
            numberDisplay.Dock = DockStyle.Fill;
            numberDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            numberDisplay.Location = new Point(3, 77);
            numberDisplay.Name = "numberDisplay";
            numberDisplay.Size = new Size(794, 77);
            numberDisplay.TabIndex = 17;
            numberDisplay.TextAlign = ContentAlignment.BottomRight;
            // 
            // operationDisplay
            // 
            operationDisplay.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(operationDisplay, 4);
            operationDisplay.Dock = DockStyle.Fill;
            operationDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            operationDisplay.ForeColor = Color.Gray;
            operationDisplay.Location = new Point(3, 0);
            operationDisplay.Name = "operationDisplay";
            operationDisplay.Size = new Size(794, 77);
            operationDisplay.TabIndex = 18;
            operationDisplay.TextAlign = ContentAlignment.BottomRight;
            // 
            // calculatorBindingSource
            // 
            calculatorBindingSource.DataSource = typeof(Calculator);
            // 
            // calculatorBindingSource1
            // 
            calculatorBindingSource1.DataSource = typeof(Calculator);
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 544);
            Controls.Add(tableLayoutPanel2);
            MinimumSize = new Size(400, 600);
            Name = "CalculatorForm";
            Text = "Calculator";
            Load += Form1_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)calculatorBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)calculatorBindingSource1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tableLayoutPanel2;
        private Button clearButton;
        private Button negateButton;
        private Button divideButton;
        private Button nineButton;
        private Button sevenButton;
        private Button eightButton;
        private Button fourButton;
        private Button fiveButton;
        private Button sixButton;
        private Button oneButton;
        private Button twoButton;
        private Button threeButton;
        private Button zeroButton;
        private Button multiplyButton;
        private Button subtractButton;
        private Button addButton;
        private Button equalsButton;
        private Label numberDisplay;
        private Label operationDisplay;
        private BindingSource calculatorBindingSource;
        private BindingSource calculatorBindingSource1;
    }
}