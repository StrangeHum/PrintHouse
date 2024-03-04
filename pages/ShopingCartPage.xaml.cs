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
            MessageBox.Show(item.Price.ToString());
            //ShopingCart.serviceList.Remove(item);
        }

        private void CreateOrder_Click(object sender, RoutedEventArgs e)
        {
            //TODO Сделать оформление заказа, процедуру заказа
            StrangeDB db = new StrangeDB();
            foreach (var service in ShopingCart.serviceList)
            {
                db.Select($"insert into order(count, idClient, idService) values({service.Count}, )"); 
            }
        }
    }
}
