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
        public MainWindow()
        {
            InitializeComponent();

            PageProvider.Init(frame);
            ShopingCart.Init();
            PageProvider.SetPageToFrame("ServicePage");

        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            PageProvider.SetPageToFrame("LoginPage");
        }

        private void ButtonShopingCart_Click(object sender, RoutedEventArgs e)
        {
            PageProvider.SetPageToFrame("ShopingCartPage");
        }

        private void ButtonCabinet_Click(object sender, RoutedEventArgs e)
        {
            if (AuthProvider.personalData == null)
            {
                MessageBox.Show("Для начала авторизируйтесь в системе");
                return;
            }
            PageProvider.SetPageToFrame("CabinetPage");
        }

        private void ButtonSignup_Click(object sender, RoutedEventArgs e)
        {
            PageProvider.SetPageToFrame("SignupPage");
        }

        private void ButtonToMainPage_Click(object sender, RoutedEventArgs e)
        {
            PageProvider.SetPageToFrame("ServicePage");
        }
    }
}
