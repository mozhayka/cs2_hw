using LunarCalendarVM;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace WpfUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly DIContainer di = new();
        public ObservableCollection<ExampleItem> Items { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            Items = new ObservableCollection<ExampleItem>()
            {
                new ExampleItem {Text = "Позавчера", Date = DateTime.Today.AddDays(-2)},
                new ExampleItem {Text = "Вчера", Date = DateTime.Today.AddDays(-1)},
                new ExampleItem {Text = "Сегодня", Date = DateTime.Today},
                new ExampleItem {Text = "Завтра", Date = DateTime.Today.AddDays(1)},
                new ExampleItem {Text = "Послезавтра", Date = DateTime.Today.AddDays(2)},
            };
            exampleList.ItemsSource = Items;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = (ExampleItem)exampleList.SelectedItem;
            var date = p.Date;
            var lc = di.ServiceProvider.GetRequiredService<ILunarCalendar>();
            textBox1.Text = lc.InfoToString(lc.GetDayInformation(date));
        }
    }
}
