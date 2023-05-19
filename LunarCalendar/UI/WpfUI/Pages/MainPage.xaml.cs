using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using WpfUI.Pages;

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    public partial class Page1 : Page
    {
        private readonly DIContainer di = new();
        public ObservableCollection<ExampleItem> Items { get; set; }

        public Page1()
        {
            InitializeComponent();

            Items = new ObservableCollection<ExampleItem>()
                {
                    new ExampleItem(DateTime.Today.AddDays(-2)),
                    new ExampleItem(DateTime.Today.AddDays(-1)),
                    new ExampleItem(DateTime.Today),
                    new ExampleItem(DateTime.Today.AddDays(1)),
                    new ExampleItem(DateTime.Today.AddDays(2)),
                    new ExampleItem(DateTime.Today.AddDays(3)),
                    new ExampleItem(DateTime.Today.AddDays(4)),
                };
            exampleList.ItemsSource = Items;
            exampleList.SelectedItem = Items[2];
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = (ExampleItem)exampleList.SelectedItem;
            var lc = di.ServiceProvider.GetRequiredService<ILunarCalendar>();
            textBox1.Text = lc.GetDayInfoRus(p.Date, p.UTC);
        }

        private void Button_GoToCalculate(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new CalculationPage());
        }
    }
}
