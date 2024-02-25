using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using PrintHouse.src;
namespace PrintHouse
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        StrangeDB db = new StrangeDB();
        public MainWindow()
        {
            InitializeComponent();
            //InitDB();
            PageProvider.Init(frame);
        }
        private void InitDB()
        {
            var data = db.Select();
            if (data.Read())
            {
                LabelFoo.Content = $"{data[0]}, {data[1]}, {data[2]}, {data[3]}";
                data.DisposeAsync();
            }
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            //frame.NavigationService.Navigate(new Uri("./pages/LoginPage.xaml", UriKind.Relative));
            PageProvider.SetPageToFrame("LoginPage");
        }

        private void ButtonShopingCart_Click(object sender, RoutedEventArgs e)
        {
            PageProvider.SetPageToFrame("CreateOrder");
        }
    }
}
