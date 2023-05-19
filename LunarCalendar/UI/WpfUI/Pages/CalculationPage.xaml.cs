using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
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

namespace WpfUI.Pages
{
    /// <summary>
    /// Interaction logic for CalculationPage.xaml
    /// </summary>
    public partial class CalculationPage : Page
    {
        private readonly DIContainer di = new();

        public CalculationPage()
        {
            InitializeComponent();

            utcPicker.ItemsSource = new int[] { -12, -11, -10, -9, -8, -7, -6, -5, -4, -3, -2, -1, 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            utcPicker.SelectedItem = 3;
            datePicker.SelectedDate = DateTime.Now;
        }

        private void Button_Calculate(object sender, RoutedEventArgs e)
        {
            DateTime date = datePicker.SelectedDate ?? DateTime.Now;
            var utc = (int)utcPicker.SelectedItem;
            var lc = di.ServiceProvider.GetRequiredService<ILunarCalendar>();
            textBox1.Text = lc.GetDayInfoRus(date, utc);
        }
    }
}
