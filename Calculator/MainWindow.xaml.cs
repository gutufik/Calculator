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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumberButtonClick(object sender, RoutedEventArgs e)
        {
            Expression.Text += $"{(sender as Button).Content}";
        }

        private void OperatorButtonClick(object sender, RoutedEventArgs e)
        {
            if (!ExpressionContainsOperator())
                Expression.Text += $"{(sender as Button).Content}";
        }

        private void EqualClick(object sender, RoutedEventArgs e)
        {
            try
            {
                var operation = Expression.Text.Split()[1];

                var firstNumber = int.Parse(Expression.Text.Split()[0]);
                var secondNumber = int.Parse(Expression.Text.Split()[2]);

                if (operation == "+")
                    Expression.Text = (firstNumber + secondNumber).ToString();
                else if (operation == "-")
                    Expression.Text = (firstNumber - secondNumber).ToString();
                else if (operation == "*")
                    Expression.Text = (firstNumber * secondNumber).ToString();
                else
                    Expression.Text = (firstNumber / secondNumber).ToString();
            }
            catch
            {
                Expression.Text = "Wrong expression";
            }
        }

        private void ClearExpression(object sender, RoutedEventArgs e)
        {
            Expression.Text = "";
        }
        private bool ExpressionContainsOperator()
        {
            return Expression.Text.Contains('+')
                || Expression.Text.Contains('-')
                || Expression.Text.Contains('*')
                || Expression.Text.Contains('/');
        }
    }
}
