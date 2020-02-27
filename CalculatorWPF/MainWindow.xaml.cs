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

        private void Button_plus_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked at " + Mouse.GetPosition(this).ToString());
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

        }

        private void Button_1_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_2_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_3_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_4_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_5_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_6_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_7_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_8_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_9_click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_1_x_click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("You clicked at " + Mouse.GetPosition(this).ToString());
        }

        private void Button_cos_click(object sender, RoutedEventArgs e)
        {

        }

    }
}
