using PrintHouse.src;
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

namespace PrintHouse.pages
{
    /// <summary>
    /// Логика взаимодействия для ServicePage.xaml
    /// </summary>
    public partial class ServicePage : Page
    {
        StrangeDB db;
        public ServicePage()
        {
            //Init props
            db = new StrangeDB();
            ServiceDatas = new ObservableCollection<ServiceData>();

            InitializeComponent();

            
            ServiceList.ItemsSource = ServiceDatas;
            UpdateServiceList();
        }

        

        public void UpdateServiceList()
        {
            ServiceDatas.Clear();

            var data = db.Select("select s.title, s.description, sp.price from service as s join serviceprice sp on s.id = sp.idServicePrice;");

            while (data.Read())
            {
                ServiceDatas.Add(new ServiceData
                {
                    title = (string)data[0],
                    description = (string)data[1],
                    price = (float)data[2]
                });
            }
            data.DisposeAsync();
        }

        public void SelectServicesWithTitle(string searchText)
        {
            ServiceDatas.Clear(); //%'` or title like `'
            var data = db.Select($"select title, description from service where title like '%{searchText}%' or description like '%{searchText}%';");

            while (data.Read())
            {
                ServiceDatas.Add(new ServiceData
                {
                    title = (string)data[0],
                    description = (string)data[1],
                    price = 0, //(float)data[2]
                });
            }
            data.DisposeAsync();
        }

        public ObservableCollection<ServiceData> ServiceDatas { get; set; }

        private void SearchBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            SelectServicesWithTitle(SearchBox.Text);
        }

        private void CreateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            int index = ServiceList.SelectedIndex;
            ServiceData item = (ServiceData)ServiceList.SelectedItem;

            if(index == -1)
            {
                MessageBox.Show($"Выберите значение");
                return;
            }

            //todo: Добавление услуги в заказ
            //MessageBox.Show($"{index}");

            ShopingCart.serviceList.Add(new ServiceCart(item, 1));
        }

        private void SearchBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsLetterOrDigit(e.Text, 0))
                e.Handled = true;
        }

        //Todo: Фильтрация
        //https://www.youtube.com/watch?v=blOl-Kg2NHM
    }
}
