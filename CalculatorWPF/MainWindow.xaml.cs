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
        Controler controler;

        public MainWindow()
        {
            InitializeComponent();
            controler = new Controler(this);
        }

        StringBuilder resultLabelStr = new StringBuilder("0");
        StringBuilder historyLabelStr = new StringBuilder();

        //buttons
        private void Button_plus_click(object sender, RoutedEventArgs e)
        {
            
        }

        private void Button_minus_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_multiply_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_divide_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_equals_click(object sender, RoutedEventArgs e)
        {

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
            else if(resultLabelStr.Length == 1)
            {
                resultLabelStr.Append("0");
            }
            else if(resultLabelStr.Length > 1)
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
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_2_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("2");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_3_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("3");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_4_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("4");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_5_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("5");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_6_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("6");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_7_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("7");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_8_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("8");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_9_click(object sender, RoutedEventArgs e)
        {
            if (resultLabelStr.Length == 1 && resultLabelStr.ToString() == "0")
                resultLabelStr.Clear();

            resultLabelStr.Append("9");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_comma_click(object sender, RoutedEventArgs e)
        {
            int index = resultLabelStr.ToString().IndexOf(".");

            if(index == -1)
                resultLabelStr.Append(".");

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
            resultLabelStr.Clear();
            resultLabelStr.Append("0");
            Label_result.Content = resultLabelStr.ToString();
        }

        private void Button_1_x_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked at " + Mouse.GetPosition(this).ToString());
        }

        private void Button_cos_click(object sender, RoutedEventArgs e)
        {

        }



        //Labels
        public void setResultlabel(string text)
        {
            Label_result.Content = text;
        }

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

        public void appendToHistoryLabel(Double number)
        {
            historyLabelStr.Append(number.ToString());
            Label_history.Content = historyLabelStr.ToString();
        }
    }
}
