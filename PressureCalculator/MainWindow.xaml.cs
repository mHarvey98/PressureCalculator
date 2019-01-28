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

namespace PressureCalculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        pressure_unit unitsIn = pressure_unit.ATM;
        pressure_unit unitsOut = pressure_unit.ATM;

        public MainWindow()
        {
            InitializeComponent();
        }



        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            ComboBox_UnitInput.ItemsSource = Enum.GetValues(typeof(pressure_unit)).Cast<pressure_unit>();
        }

        public enum pressure_unit { ATM, Bar, KgCm2, Pa, PSI, mmHg };
        

        private void Button_Exit_Click(object sender, RoutedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void Button_ClearAll_Click(object sender, RoutedEventArgs e)
        {
            TextBox_ValueInput.Text = "";
            ComboBox_UnitInput.Text = "Units";
            ComboBox_UnitOutput.Text = "Units";
        }

        private void Button_Help_Click(object sender, RoutedEventArgs e)
        {
            HelpWindow helpWindow = new HelpWindow();
            helpWindow.ShowDialog();
        }

        private void Button_Convert_Click(object sender, RoutedEventArgs e)
        {
            string s = (ComboBox_UnitInput.SelectedItem as ComboBoxItem).Content.ToString();
            string s2 = (ComboBox_UnitOutput.SelectedItem as ComboBoxItem).Content.ToString();
            double input = 0;
            double result = 0;

            if (double.TryParse(TextBox_ValueInput.Text, out input))
            {
                switch (s)
                {
                    case "Units": break;

                    case "ATM":
                        unitsIn = pressure_unit.ATM;
                        break;

                    case "Bar":
                        unitsIn = pressure_unit.Bar;
                        break;

                    case "KgCm2":
                        unitsIn = pressure_unit.KgCm2;
                        break;

                    case "Pa":
                        unitsIn = pressure_unit.Pa;
                        break;

                    case "PSI":
                        unitsIn = pressure_unit.PSI;
                        break;

                    case "mmHg":
                        unitsIn = pressure_unit.mmHg;
                        break;

                    default: break;
                }

                switch (s2)
                {
                    case "Units": break;

                    case "ATM":
                        unitsOut = pressure_unit.ATM;
                        break;

                    case "Bar":
                        unitsOut = pressure_unit.Bar;
                        break;

                    case "KgCm2":
                        unitsOut = pressure_unit.KgCm2;
                        break;

                    case "Pa":
                        unitsOut = pressure_unit.Pa;
                        break;

                    case "PSI":
                        unitsOut = pressure_unit.PSI;
                        break;

                    case "mmHg":
                        unitsOut = pressure_unit.mmHg;
                        break;

                    default: break;
                }

                if (s != "Units" || s2 != "Units")
                {
                    result = ConvertPressures(input, unitsIn, unitsOut);

                    SolutionWindow solutionWindow = new SolutionWindow(result, s2);
                    solutionWindow.ShowDialog();
                }
        }
    }

        private double ConvertPressures(double input, pressure_unit units_in, pressure_unit units_out)
        {
            double output_value = 0;

            switch (units_in)
            {
                case pressure_unit.ATM:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input;
                            break;
                        case pressure_unit.Bar:
                            output_value = input * 1.013;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input * 1.033;
                            break;
                        case pressure_unit.Pa:
                            output_value = input * 101325;
                            break;
                        case pressure_unit.PSI:
                            output_value = input * 14.696;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input * 760;
                            break;
                        default:
                            break;
                    }
                    break;

                case pressure_unit.Bar:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input / 1.013;
                            break;
                        case pressure_unit.Bar:
                            output_value = input;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input * 1.02;
                            break;
                        case pressure_unit.Pa:
                            output_value = input * 100000;
                            break;
                        case pressure_unit.PSI:
                            output_value = input * 14.504;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input * 750.062;
                            break;
                        default:
                            break;
                    }
                    break;

                case pressure_unit.KgCm2:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input / 1.033;
                            break;
                        case pressure_unit.Bar:
                            output_value = input / 1.02;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input;
                            break;
                        case pressure_unit.Pa:
                            output_value = input * 98066.5;
                            break;
                        case pressure_unit.PSI:
                            output_value = input * 14.223;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input * 735.559;
                            break;
                        default:
                            break;
                    }
                    break;

                case pressure_unit.Pa:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input / 101325;
                            break;
                        case pressure_unit.Bar:
                            output_value = input / 100000;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input / 98066.5;
                            break;
                        case pressure_unit.Pa:
                            output_value = input;
                            break;
                        case pressure_unit.PSI:
                            output_value = input / 6894.757;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input / 133.322;
                            break;
                        default:
                            break;
                    }
                    break;

                case pressure_unit.PSI:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input / 14.696;
                            break;
                        case pressure_unit.Bar:
                            output_value = input / 14.504;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input / 14.223;
                            break;
                        case pressure_unit.Pa:
                            output_value = input * 6894.757;
                            break;
                        case pressure_unit.PSI:
                            output_value = input;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input * 51.715;
                            break;
                        default:
                            break;
                    }
                    break;

                case pressure_unit.mmHg:
                    switch (units_out)
                    {
                        case pressure_unit.ATM:
                            output_value = input / 760;
                            break;
                        case pressure_unit.Bar:
                            output_value = input / 750.062;
                            break;
                        case pressure_unit.KgCm2:
                            output_value = input / 735.559;
                            break;
                        case pressure_unit.Pa:
                            output_value = input * 133.322;
                            break;
                        case pressure_unit.PSI:
                            output_value = input / 51.715;
                            break;
                        case pressure_unit.mmHg:
                            output_value = input;
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    break;
            }
                       
            return output_value;
        }
    }
}
