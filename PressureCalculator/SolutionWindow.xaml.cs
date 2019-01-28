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
using System.Windows.Shapes;

namespace PressureCalculator
{
    /// <summary>
    /// Interaction logic for SolutionWindow.xaml
    /// </summary>
    public partial class SolutionWindow : Window
    {
        public SolutionWindow(double volume, string outputUnits)
        {
            InitializeComponent();

            Label_Solution_Value.Content = volume.ToString();
            Label_Solution_Units.Content = outputUnits;
        }

        private void Button_SolutionWindow_Close_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
