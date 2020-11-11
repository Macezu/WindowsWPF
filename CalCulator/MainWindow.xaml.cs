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

namespace WpfFirstApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double first;
        double second;
        dynamic operatr;
        char[] operatorChars = { '/', '*', '-', '+' };

        public MainWindow()
        {
            InitializeComponent();
        }
        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case (Key.Back):
                    cancel_Click(sender, e);
                    break;
                case (Key.D1):
                    one_Click(sender, e);
                    break;
                case (Key.D2):
                    two_Click(sender, e);
                    break;
                case (Key.D3):
                    three_Click(sender, e);
                    break;
                case (Key.D4):
                    four_Click(sender, e);
                    break;
                case (Key.D5):
                    five_Click(sender, e);
                    break;
                case (Key.D6):
                    six_Click(sender, e);
                    break;
                case (Key.D7):
                    seven_Click(sender, e);
                    break;
                case (Key.D8):
                    eight_Click(sender, e);
                    break;
                case (Key.D9):
                    nine_Click(sender, e);
                    break;
                case (Key.D0):
                    zero_Click(sender, e);
                    break;
            }

        }

        private void one_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 1;
        }

        private void two_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 2;
        }

        private void three_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 3;
        }

        private void four_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 4;
        }

        private void five_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 5;
        }

        private void six_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 6;
        }

        private void seven_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 7;
        }

        private void eight_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 8;
        }

        private void nine_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text += 9;
        }

        private void zero_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text == string.Empty || operatorChars.Contains(txtField.Text.Last()))
            {
                txtField.Text += "0.";
            } else
            {
                txtField.Text += 0;
            }
            
        }

        private void cancel_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text.EndsWith("."))
            {
                txtField.Text = string.Empty;
            }
            else if (txtField.Text != string.Empty)
            {
                txtField.Text = txtField.Text.Remove(txtField.Text.Length - 1);
            }
        }

        private void cancelE_Click(object sender, RoutedEventArgs e)
        {
            txtField.Text = string.Empty;
        }

        private void equals_Click(object sender, RoutedEventArgs e)
        {

            string[] last = txtField.Text.Split(operatorChars);
            try
            {
                second = double.Parse(last[1], System.Globalization.CultureInfo.InvariantCulture);
            }
            catch (IndexOutOfRangeException f)
            {
                second = 1;
            }
            catch (FormatException c)
            {
                second = 1;
            }
            switch (operatr)
            {
                case "+":
                    txtField.Text = (first + second).ToString();
                    break;
                case "-":
                    txtField.Text = (first - second).ToString();
                    break;
                case "/":
                    txtField.Text = (first / second).ToString();
                    break;
                case "*":
                    txtField.Text = (first * second).ToString();
                    break;
            }
            second = 1;



        }

        private void add_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text.IndexOfAny(operatorChars) == -1 && txtField.Text != string.Empty)
            {
                first = double.Parse(txtField.Text, System.Globalization.CultureInfo.InvariantCulture);
                operatr = "+";
                txtField.Text += "+";
            }

        }

        private void sub_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text.IndexOfAny(operatorChars) == -1 && txtField.Text != string.Empty)
            {
                first = double.Parse(txtField.Text, System.Globalization.CultureInfo.InvariantCulture);
                operatr = "-";
                txtField.Text += "-";
            }

        }

        private void multi_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text.IndexOfAny(operatorChars) == -1 && txtField.Text != string.Empty)
            {
                first = double.Parse(txtField.Text, System.Globalization.CultureInfo.InvariantCulture);
                operatr = "*";
                txtField.Text += "*";
            }
        }

        private void div_Click(object sender, RoutedEventArgs e)
        {
            if (txtField.Text.IndexOfAny(operatorChars) == -1 && txtField.Text != string.Empty)
            {
                first = double.Parse(txtField.Text, System.Globalization.CultureInfo.InvariantCulture);
                operatr = "/";
                txtField.Text += "/";
            }

        }
 

    }
}
