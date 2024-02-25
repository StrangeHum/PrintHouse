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

namespace PrintHouse.theme
{
    /// <summary>
    /// Логика взаимодействия для StrangeField.xaml
    /// </summary>
    public partial class StrangeField : UserControl
    {
        public StrangeField()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleDepensity = DependencyProperty.Register("Title", typeof(string), typeof(StrangeField), new PropertyMetadata(String.Empty));

        public string Title
        {
            get { return (string)GetValue(TitleDepensity); }
            set { SetValue(TitleDepensity, value); }
        }
    }
}
