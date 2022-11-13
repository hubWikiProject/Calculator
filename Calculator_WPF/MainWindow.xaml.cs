using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Calculator_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double number1;
        double number2;
        string operation = "";
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_num_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            String number = button.Content.ToString();
            if (text_result.Text == "0")
            {
                text_result.Text = number;
            }
            else
            {
                text_result.Text += number;
            }

            if (operation == "")
            {
                number1 = Convert.ToDouble(text_result.Text);
            }
            else
            {
                number2 = Convert.ToDouble(text_result.Text);
            }
        }

        private void btn_operation_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            operation = button.Content.ToString();
            text_result.Text = "0";
        }

        private void btn_eq_Click(object sender, RoutedEventArgs e)
        {
            double result = 0;
            switch (operation)
            {
                case "+":
                    result = number1 + number2;
                    break;
                case "-":
                    result = number1 - number2;
                    break;
                case "*":
                    result = number1 * number2;
                    break;
                case "/":
                    result = number1 / number2;
                    break;
                case "MIN":
                    result = Math.Min(number1, number2);
                    break;
                case "MAX":
                    result = Math.Max(number1, number2);
                    break;
                case "AVG":
                    result = (number1 + number2) / 2;
                    break;
                case "x^y":
                    result = GetPow(number1, (int)number2);
                    break;
            }

            operation = "";
            number1 = result;
            number2 = 0;
            text_result.Text = result.ToString();
        }

        // x^4 = x * x * x * x = x^3 * x
        // x^3 = x * x * x = x^2 * x
        // x^2 = x * x = x^1 * x
        // x^1 = x = x^0 * x
        // x^0 = 1
        static double GetPow(double x, int y)
        {
            if (y == 0)
            {
                return 1;
            }

            return GetPow(x, y - 1) * x;
        }

        private void btn_CE_Click(object sender, RoutedEventArgs e)
        {
            number1 = 0;
            number2 = 0;
            operation = "";
            text_result.Text = "0";
        }

        private void btn_C_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 = 0;
            }
            else
            {
                number2 = 0;
            }
            text_result.Text = "0";
        }

        private void btn_backspase_Click(object sender, RoutedEventArgs e)
        {
            text_result.Text = DropLastChar(text_result.Text);
            if (operation == "")
            {
                number1 = Convert.ToDouble(text_result.Text);
            }
            else
            {
                number2 = Convert.ToDouble(text_result.Text);
            }

        }

        private void btn_plusminus_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                number1 *= -1;
                text_result.Text = number1.ToString();
            }
            else
            {
                number2 *= -1;
                text_result.Text = number2.ToString();
            }
        }

        private string DropLastChar(string text)
        {
            if (text.Length <= 1)
            {
                text = "0";
            }
            else
            {
                text = text.Remove(text.Length - 1, 1);
                if (text[text.Length - 1] == ',')
                    text = text.Remove(text.Length - 1, 1);
            }
            return text;
        }

        private void btn_comma_Click(object sender, RoutedEventArgs e)
        {
            if (operation == "")
            {
                SetComma(number1);
            }
            else
            {
                SetComma(number2);
            }
        }

        private void SetComma(double x)
        {
            if (text_result.Text.Contains(','))
                return;

            text_result.Text += ',';
        }
    }
}
