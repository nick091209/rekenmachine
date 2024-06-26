using System;
using System.Windows;
using System.Windows.Controls;

namespace SimpleCalculator
{
    public partial class MainWindow : Window
    {
        private string _currentOperation;
        private double _firstNumber;
        private bool _isOperationClicked;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            if (_isOperationClicked)
            {
                ResultTextBox.Text = button.Content.ToString();
                _isOperationClicked = false;
            }
            else
            {
                if (ResultTextBox.Text == "0")
                {
                    ResultTextBox.Text = button.Content.ToString();
                }
                else
                {
                    ResultTextBox.Text += button.Content.ToString();
                }
            }
        }

        private void Operation_Click(object sender, RoutedEventArgs e)
        {
            var button = sender as Button;
            if (button == null) return;

            _firstNumber = Convert.ToDouble(ResultTextBox.Text);
            _currentOperation = button.Content.ToString();
            _isOperationClicked = true;
        }

        private void Equals_Click(object sender, RoutedEventArgs e)
        {
            double secondNumber;
            double result = 0;

            if (!double.TryParse(ResultTextBox.Text, out secondNumber)) return;

            switch (_currentOperation)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "*":
                    result = _firstNumber * secondNumber;
                    break;
                case "/":
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("door nul delen kan niet eikelbijter.");
                        return;
                    }
                    result = _firstNumber / secondNumber;
                    break;
                default:
                    return;
            }

            ResultTextBox.Text = result.ToString();
            _isOperationClicked = false;
        }

        private void Clear_Click(object sender, RoutedEventArgs e)
        {
            ResultTextBox.Text = "0";
            _firstNumber = 0;
            _currentOperation = string.Empty;
            _isOperationClicked = false;
        }
    }
}
