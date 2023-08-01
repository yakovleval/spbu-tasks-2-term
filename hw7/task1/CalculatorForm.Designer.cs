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
            historyDisplay = new Label();
            tableLayoutPanel2.SuspendLayout();
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
            tableLayoutPanel2.Controls.Add(historyDisplay, 0, 0);
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
            tableLayoutPanel2.Size = new Size(800, 450);
            tableLayoutPanel2.TabIndex = 2;
            // 
            // clearButton
            // 
            tableLayoutPanel2.SetColumnSpan(clearButton, 2);
            clearButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            clearButton.Location = new Point(3, 131);
            clearButton.Name = "clearButton";
            clearButton.Size = new Size(394, 58);
            clearButton.TabIndex = 0;
            clearButton.Text = "C";
            clearButton.UseVisualStyleBackColor = true;
            clearButton.Click += button1_Click;
            // 
            // negateButton
            // 
            negateButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            negateButton.Location = new Point(403, 131);
            negateButton.Name = "negateButton";
            negateButton.Size = new Size(194, 58);
            negateButton.TabIndex = 1;
            negateButton.Text = "+/-";
            negateButton.UseVisualStyleBackColor = true;
            // 
            // divideButton
            // 
            divideButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            divideButton.Location = new Point(603, 131);
            divideButton.Name = "divideButton";
            divideButton.Size = new Size(194, 58);
            divideButton.TabIndex = 2;
            divideButton.Text = "÷";
            divideButton.UseVisualStyleBackColor = true;
            // 
            // nineButton
            // 
            nineButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            nineButton.Location = new Point(403, 195);
            nineButton.Name = "nineButton";
            nineButton.Size = new Size(194, 58);
            nineButton.TabIndex = 3;
            nineButton.Text = "9";
            nineButton.UseVisualStyleBackColor = true;
            // 
            // sevenButton
            // 
            sevenButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            sevenButton.Location = new Point(3, 195);
            sevenButton.Name = "sevenButton";
            sevenButton.Size = new Size(194, 58);
            sevenButton.TabIndex = 4;
            sevenButton.Text = "7";
            sevenButton.UseVisualStyleBackColor = true;
            // 
            // eightButton
            // 
            eightButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            eightButton.Location = new Point(203, 195);
            eightButton.Name = "eightButton";
            eightButton.Size = new Size(194, 58);
            eightButton.TabIndex = 5;
            eightButton.Text = "8";
            eightButton.UseVisualStyleBackColor = true;
            // 
            // fourButton
            // 
            fourButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            fourButton.Location = new Point(3, 259);
            fourButton.Name = "fourButton";
            fourButton.Size = new Size(194, 58);
            fourButton.TabIndex = 6;
            fourButton.Text = "4";
            fourButton.UseVisualStyleBackColor = true;
            // 
            // fiveButton
            // 
            fiveButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            fiveButton.Location = new Point(203, 259);
            fiveButton.Name = "fiveButton";
            fiveButton.Size = new Size(194, 58);
            fiveButton.TabIndex = 7;
            fiveButton.Text = "5";
            fiveButton.UseVisualStyleBackColor = true;
            // 
            // sixButton
            // 
            sixButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            sixButton.Location = new Point(403, 259);
            sixButton.Name = "sixButton";
            sixButton.Size = new Size(194, 58);
            sixButton.TabIndex = 8;
            sixButton.Text = "6";
            sixButton.UseVisualStyleBackColor = true;
            // 
            // oneButton
            // 
            oneButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            oneButton.Location = new Point(3, 323);
            oneButton.Name = "oneButton";
            oneButton.Size = new Size(194, 58);
            oneButton.TabIndex = 9;
            oneButton.Text = "1";
            oneButton.UseVisualStyleBackColor = true;
            // 
            // twoButton
            // 
            twoButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            twoButton.Location = new Point(203, 323);
            twoButton.Name = "twoButton";
            twoButton.Size = new Size(194, 58);
            twoButton.TabIndex = 10;
            twoButton.Text = "2";
            twoButton.UseVisualStyleBackColor = true;
            // 
            // threeButton
            // 
            threeButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            threeButton.Location = new Point(403, 323);
            threeButton.Name = "threeButton";
            threeButton.Size = new Size(194, 58);
            threeButton.TabIndex = 11;
            threeButton.Text = "3";
            threeButton.UseVisualStyleBackColor = true;
            // 
            // zeroButton
            // 
            tableLayoutPanel2.SetColumnSpan(zeroButton, 3);
            zeroButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            zeroButton.Location = new Point(3, 387);
            zeroButton.Name = "zeroButton";
            zeroButton.Size = new Size(594, 58);
            zeroButton.TabIndex = 12;
            zeroButton.Text = "0";
            zeroButton.UseVisualStyleBackColor = true;
            // 
            // multiplyButton
            // 
            multiplyButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            multiplyButton.Location = new Point(603, 195);
            multiplyButton.Name = "multiplyButton";
            multiplyButton.Size = new Size(194, 58);
            multiplyButton.TabIndex = 13;
            multiplyButton.Text = "×";
            multiplyButton.UseVisualStyleBackColor = true;
            // 
            // subtractButton
            // 
            subtractButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            subtractButton.Location = new Point(603, 259);
            subtractButton.Name = "subtractButton";
            subtractButton.Size = new Size(194, 58);
            subtractButton.TabIndex = 14;
            subtractButton.Text = "-";
            subtractButton.UseVisualStyleBackColor = true;
            // 
            // addButton
            // 
            addButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            addButton.Location = new Point(603, 323);
            addButton.Name = "addButton";
            addButton.Size = new Size(194, 58);
            addButton.TabIndex = 15;
            addButton.Text = "+";
            addButton.UseVisualStyleBackColor = true;
            // 
            // equalsButton
            // 
            equalsButton.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            equalsButton.Location = new Point(603, 387);
            equalsButton.Name = "equalsButton";
            equalsButton.Size = new Size(194, 58);
            equalsButton.TabIndex = 16;
            equalsButton.Text = "=";
            equalsButton.UseVisualStyleBackColor = true;
            // 
            // numberDisplay
            // 
            numberDisplay.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(numberDisplay, 4);
            numberDisplay.Dock = DockStyle.Fill;
            numberDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            numberDisplay.Location = new Point(3, 64);
            numberDisplay.Name = "numberDisplay";
            numberDisplay.Size = new Size(794, 64);
            numberDisplay.TabIndex = 17;
            numberDisplay.Text = "0";
            numberDisplay.TextAlign = ContentAlignment.BottomRight;
            // 
            // historyDisplay
            // 
            historyDisplay.AutoSize = true;
            tableLayoutPanel2.SetColumnSpan(historyDisplay, 4);
            historyDisplay.Dock = DockStyle.Fill;
            historyDisplay.Font = new Font("Segoe UI", 22F, FontStyle.Regular, GraphicsUnit.Point);
            historyDisplay.ForeColor = Color.Gray;
            historyDisplay.Location = new Point(3, 0);
            historyDisplay.Name = "historyDisplay";
            historyDisplay.Size = new Size(794, 64);
            historyDisplay.TabIndex = 18;
            historyDisplay.TextAlign = ContentAlignment.BottomRight;
            historyDisplay.Click += label2_Click;
            // 
            // CalculatorForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(tableLayoutPanel2);
            Name = "CalculatorForm";
            Text = "Calculator";
            Load += Form1_Load;
            tableLayoutPanel2.ResumeLayout(false);
            tableLayoutPanel2.PerformLayout();
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
        private Label historyDisplay;
    }
}