﻿using PrintHouse.pages;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

public static class PageProvider
{
    static Frame frame = null;



    public static void Init(Frame _frame)
    {
        frame = _frame;
    }
    public static void SetPageToFrame(string page)
    {
        frame.NavigationService.Navigate(new Uri($"./pages/{page}.xaml", UriKind.Relative));
    }
    public static void SetPageToFrame(Page page)
    {
        frame.NavigationService.Navigate(page, UriKind.Relative);
    }
}
