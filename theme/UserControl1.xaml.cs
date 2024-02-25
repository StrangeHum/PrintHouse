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
    /// Логика взаимодействия для UserControl1.xaml
    /// </summary>
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TitleDepensity = DependencyProperty.Register("Title", typeof(string), typeof(UserControl1), new PropertyMetadata(String.Empty));

        public string Title
        {
            get { return (string)GetValue(TitleDepensity); }
            set { SetValue(TitleDepensity, value); }
        }
    }
}
