﻿using System;
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
using System.Windows.Shapes;

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для Afisha.xaml
    /// </summary>
    public partial class Afisha
    {
        public Afisha()
        {
            InitializeComponent();
            performancelist_panel.Children.Add(new Performance_list());
            performancelist_panel.Children.Add(new Performance_list());
            performancelist_panel.Children.Add(new Performance_list());
        }
    }
}
