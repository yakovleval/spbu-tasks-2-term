using System;
using System.Collections.Generic;

namespace hw2task2
{
    public interface IStack<T>
    {
        void Push(T value);
        T Pop();
        T Peek();
        bool IsEmpty { get; }
    }

    public class ArrayStack<T> : IStack<T>
    {
        private T[] data;
        private int top;

        public ArrayStack(int capacity)
        {
            data = new T[capacity];
            top = -1;
        }

        public void Push(T value)
        {
            if (top == data.Length - 1)
                throw new OverflowException("Stack is full");
            top++;
            data[top] = value;
        }

        public T Pop()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is empty");
            T value = data[top];
            top--;
            return value;
        }

        public T Peek()
        {
            if (top == -1)
                throw new InvalidOperationException("Stack is empty");
            return data[top];
        }

        public bool IsEmpty
        {
            get { return top == -1; }
        }
    }

    public class ListStack<T> : IStack<T>
    {
        private LinkedList<T> data;

        public ListStack()
        {
            data = new LinkedList<T>();
        }

        public void Push(T value)
        {
            data.AddLast(value);
        }

        public T Pop()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            T value = Peek();
            data.RemoveLast();
            return value;
        }

        public T Peek()
        {
            if (IsEmpty)
                throw new InvalidOperationException("Stack is empty");
            return data.Last.Value;
        }

        public bool IsEmpty
        {
            get { return data.Count == 0; }
        }
    }

    public class Calculator
    {
        private IStack<double> stack;
        private static readonly double epsilon = 0.000001;

        public Calculator(IStack<double> stack)
        {
            this.stack = stack;
        }

        public double Evaluate(string expression)
        {
            if (expression == "")
            {
                return 0;
            }
            string[] tokens = expression.Split(' ');
            foreach (string token in tokens)
            {
                double value;
                if (double.TryParse(token, out value))
                {
                    stack.Push(value);
                }
                else
                {
                    double y = stack.Pop();
                    double x = stack.Pop();
                    switch (token)
                    {
                        case "+":
                            stack.Push(x + y);
                            break;
                        case "-":
                            stack.Push(x - y);
                            break;
                        case "*":
                            stack.Push(x * y);
                            break;
                        case "/":
                            double result = x / y;
                            if (Math.Abs(result - 0) < Calculator.epsilon ||
                                double.IsNegativeInfinity(result) ||
                                double.IsPositiveInfinity(result))
                            {
                                throw new ArithmeticException("division by 0");
                            }
                            stack.Push(result);
                            break;
                        default:
                            throw new ArgumentException("Unknown operator: " + token);
                    }
                }
            }
            return stack.Pop();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            IStack<double> arrayStack = new ArrayStack<double>(100);
            IStack<double> listStack = new ListStack<double>();
            Calculator arrayCalculator = new Calculator(arrayStack);
            Calculator listCalculator = new Calculator(listStack);

            Console.WriteLine("inter the expression");
            string expression = Console.ReadLine();
            double arrayResult;
            double listResult;
            try
            {
                arrayResult = arrayCalculator.Evaluate(expression);
                listResult = listCalculator.Evaluate(expression);
            }
            catch (Exception)
            {
                Console.WriteLine("incorrect input");
                return;
            }
            
            Console.WriteLine("arrayCalculator result: " + arrayResult);
            Console.WriteLine("listCalculator result: " + listResult);
        }
    }
}