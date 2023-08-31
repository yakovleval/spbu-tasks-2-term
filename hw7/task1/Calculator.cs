using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    public class Calculator : INotifyPropertyChanged
    {
        private readonly string errorMsg = "Error";
        private string numberDisplay = "0";
        private string operationDisplay = "";
        public string NumberDisplay
        {
            get
            {
                return numberDisplay;
            }
            set
            {
                numberDisplay = value;
                OnPropertyChanged();
            }
        }
        public string OperationDisplay
        {
            get
            {
                return operationDisplay;
            }
            set
            {
                operationDisplay = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        private void OnPropertyChanged([CallerMemberName]string propertyName = "")
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        private enum State
        {
            FirstNumber,
            SecondNumber,
            Error
        }
        private State currentState = State.FirstNumber;
        private string currentOp = "";
        private string firstNumber = "";

        public void AddDigit(string digit)
        {
            if (currentState == State.Error)
                currentState = State.FirstNumber;
            if (numberDisplay == errorMsg || numberDisplay == "0")
                NumberDisplay = digit;
            else
                NumberDisplay += digit;
        }

        public void AddOp(string op)
        {
            if (currentState == State.Error)
                return;
            if (currentState == State.FirstNumber)
            {
                currentState = State.SecondNumber;
                currentOp = op;
                firstNumber = NumberDisplay;
                OperationDisplay = $"{NumberDisplay} {op}";
                NumberDisplay = "0";
            }
            else
            {
                try
                {
                    double result = Evaluate(firstNumber, currentOp, NumberDisplay);
                    currentOp = op;
                    OperationDisplay = $"{result} {op}";
                    NumberDisplay = "0";
                    firstNumber = result.ToString();
                }
                catch
                {
                    OperationDisplay = "";
                    NumberDisplay = errorMsg;
                    currentState = State.Error;
                }
                
            }
        }
        public double Evaluate(string firstNumber, string op, string secondNumber)
        {
            double first = double.Parse(firstNumber);
            double second = double.Parse(secondNumber);
            double result;
            switch (op)
            {
                case "÷":
                    if (Math.Abs(second) < 0.0001)
                        throw new DivideByZeroException();
                    result = first / second;
                    return result;
                case "×":
                    return first * second;
                case "+":
                    return first + second;
                case "-":
                    return first - second;
                default:
                    throw new ArgumentException();
            }
        }
        public void Equals()
        {
            if (currentState == State.FirstNumber)
                return;
            try
            {
                double result = Evaluate(firstNumber, currentOp, NumberDisplay);
                OperationDisplay = "";
                NumberDisplay = result.ToString();
                currentState = State.FirstNumber;
            }
            catch
            {
                OperationDisplay = "";
                NumberDisplay = errorMsg;
                currentState = State.Error;
            }
        }
        public void Clear()
        {
            currentState = State.FirstNumber;
            NumberDisplay = "0";
            OperationDisplay = "";
        }
        public void Negate()
        {
            if (NumberDisplay == "0")
                return;
            double currentNumber = double.Parse(NumberDisplay);
            currentNumber *= -1;
            NumberDisplay = currentNumber.ToString();
        }
    }
}
