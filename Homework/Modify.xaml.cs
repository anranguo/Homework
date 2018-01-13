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

namespace Homework
{
    /// <summary>
    /// Modify.xaml 的交互逻辑
    /// </summary>
    public partial class Modify : Window
    {
        public Modify()
        {
            InitializeComponent();
            _Linq = new LinqToSql();
            this.DataContext = _Linq;
        }
        private LinqToSql _Linq;

        private void OnSubmit_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _Linq.Submit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}