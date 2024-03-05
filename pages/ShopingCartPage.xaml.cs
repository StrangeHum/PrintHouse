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
using PrintHouse.src;
using MySqlConnector;

namespace PrintHouse.pages
{
    /// <summary>
    /// Логика взаимодействия для ShopingCartPage.xaml
    /// </summary>
    public partial class ShopingCartPage : Page
    {
        public ShopingCartPage()
        {
            InitializeComponent();
            ServiceList.ItemsSource = ShopingCart.serviceList;
        }

        private void RemoveItemOnCart_Click(object sender, RoutedEventArgs e)
        {
            ServiceCart item = (ServiceCart)ServiceList.SelectedItem;
            ShopingCart.serviceList.Remove(item);
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            if(AuthProvider.personalData == null)
            {
                MessageBox.Show("Для начала авторизируйтесь в системе");
                return;
            }

            StrangeDB db = new StrangeDB();

            foreach (var service in ShopingCart.serviceList)
            {
                db.Insert($"call CreateOrder({service.Count}, {AuthProvider.personalData.Id}, {service.Data.Id})");
            }
        }
    }
}
