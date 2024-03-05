using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintHouse.src
{
    internal static class ShopingCart
    {
        public static ObservableCollection<ServiceCart> serviceList; 

        public static void Init()
        {
            serviceList = new ObservableCollection<ServiceCart>();
        }
    }
    internal class ServiceCart
    {
        public ServiceData Data { get; set; }
        public int _count; 
        private float _price;

        public int Count { 
            get { return _count; } 
            set {
                _count = value;
                _price = Data.price * _count;
            } 
        }
        public string Title => Data.title;
        public float Price => _price;

        public ServiceCart(ServiceData data, int count)
        {
            this.Data = data;
            this.Count = count;
        }


    }
}
