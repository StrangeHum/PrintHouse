﻿using PrintHouse.src;
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

namespace PrintHouse.pages
{
    /// <summary>
    /// Логика взаимодействия для CabinetPage.xaml
    /// </summary>
    public partial class CabinetPage : Page
    {
        StrangeDB db;

        public CabinetPage()
        {
            db = new StrangeDB();

            InitializeComponent();
            PersonalData = AuthProvider.personalData;
        }
        public PersonalData PersonalData {  get; set; }
    }
}
