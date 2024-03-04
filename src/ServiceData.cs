using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrintHouse.src
{
    public class ServiceData
    {
        public string title { get; set; }
        public string description { get; set; }
        public float price { get; set; }
        public int Id {  get; set; }
        //public Material[] materials { get; set; }
    }
    public class Material
    {
        public string title;
        public string manufacturer;
    }
}
