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
                    new ExampleItem {Text = "Позавчера", Date = DateTime.Today.AddDays(-2), UTC = 3},
                    new ExampleItem {Text = "Вчера", Date = DateTime.Today.AddDays(-1), UTC = 3},
                    new ExampleItem {Text = "Сегодня", Date = DateTime.Today, UTC = 3},
                    new ExampleItem {Text = "Завтра", Date = DateTime.Today.AddDays(1), UTC = 3},
                    new ExampleItem {Text = "Послезавтра", Date = DateTime.Today.AddDays(2), UTC = 3},
                    new ExampleItem {Text = "19.02.2021", Date = new DateTime(2021, 02, 19), UTC = 3},
                    new ExampleItem {Text = "13.05.2020", Date = new DateTime(2020, 05, 13), UTC = 3},
                    new ExampleItem {Text = "13.01.2020", Date = new DateTime(2020, 01, 13), UTC = 3},
                };
            exampleList.ItemsSource = Items;
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
