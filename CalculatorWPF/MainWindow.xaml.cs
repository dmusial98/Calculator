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

namespace CalculatorWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //reference to controler
        Controler controler;

        //constructor
        public MainWindow()
        {
            InitializeComponent();
            controler = new Controler(this);
        }

        StringBuilder resultLabelStr = new StringBuilder("0");
        StringBuilder historyLabelStr = new StringBuilder("");

        public bool isResultLabelEmpty = true;
            
        //buttons
        private void Button_plus_click(object sender, RoutedEventArgs e)
        {
            controler.buttonPlusClicked(resultLabelStr.ToString());
            isResultLabelEmpty = true;
        }

        private void Button_minus_click(object sender, RoutedEventArgs e)
        {
            controler.buttonMinusClicked(resultLabelStr.ToString());
            isResultLabelEmpty = true;
        }

        private void Button_multiply_click(object sender, RoutedEventArgs e)
        {
            controler.buttonMultiplyClicked(resultLabelStr.ToString());
            isResultLabelEmpty = true;
        }

        private void Button_divide_click(object sender, RoutedEventArgs e)
        {
            controler.buttonDivideClicked(resultLabelStr.ToString());
            isResultLabelEmpty = true;
        }
        private void Button_pow_click(object sender, RoutedEventArgs e)
        {
            controler.buttonPowerClicked(resultLabelStr.ToString());
            isResultLabelEmpty = true;
        }

        private void Button_equals_click(object sender, RoutedEventArgs e)
        {
            controler.buttonEqualsClicked();
        }

        private void Button_left_bracket_click(object sender, RoutedEventArgs e)
        {
            controler.buttonLeftBracketClicked();
        }

        private void Button_right_bracket_click(object sender, RoutedEventArgs e)
        {
            controler.buttonRightBracketClicked(resultLabelStr.ToString());
        }


        private void Button_0_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 0)
            {
                resultLabelStr.Append("0");
            }
            else if(resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
            {

            }
            else if(resultLabelStr.Length >= 1)
            {
                resultLabelStr.Append("0");
            }

            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_1_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();
            
            resultLabelStr.Append("1");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_2_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("2");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_3_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("3");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_4_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("4");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_5_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("5");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_6_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("6");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_7_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("7");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_8_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("8");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_9_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("9");

            isResultLabelEmpty = false;
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_comma_click(object sender, RoutedEventArgs e)
        {
            int index = resultLabelStr.ToString().IndexOf(",");

            if(index == -1)
                resultLabelStr.Append(",");

            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_backspc_click(object sender, RoutedEventArgs e)
        {
            if(resultLabelStr.Length > 0)
            {
                if(resultLabelStr.Length == 1)
                {
                    resultLabelStr.Clear();
                    resultLabelStr.Append("0");
                    isResultLabelEmpty = true;
                }
                else
                {
                    resultLabelStr.Remove(resultLabelStr.Length - 1, 1);
                }

                Label_result.Content = resultLabelStr.ToString();
            }
        }

        private void Button_C_click(object sender, RoutedEventArgs e)
        {
            if (!isResultLabelEmpty)
            {
                resultLabelStr.Clear();
                resultLabelStr.Append("0");
                Label_result.Content = resultLabelStr.ToString();
                isResultLabelEmpty = true;
            }
            else
                //historylabelString is Empty
            {
                historyLabelStr.Clear();
                Label_history.Content = historyLabelStr.ToString();
                controler.ClearButtonClicked();
            }
        }

        private void Button_1_x_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked at " + Mouse.GetPosition(this).ToString());
        }

        private void Button_cos_click(object sender, RoutedEventArgs e)
        {

        }


        //Labels
        public void setResultLabel(double text)
        {
            Label_result.Content = text;
            resultLabelStr.Clear();
        }

        public void appendToHistorylabel(string text)
        {
            historyLabelStr.Append(text);
            Label_history.Content = historyLabelStr.ToString();
        }

        public void removeLastCharHistoryLabel()
        {
            historyLabelStr.Remove(historyLabelStr.Length - 1, 1);
        }

        public char? getLastCharHistoryLabel()
        {
            if (historyLabelStr.ToString().Length != 0)
                return historyLabelStr.ToString().Last();
            else
                return null;
        }
    
    }
}
