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
    /// Search.xaml 的交互逻辑
    /// </summary>
    public partial class Search : Window
    {
        public Search()
        {
            InitializeComponent();
            _Model = new SearchModel();
            this.DataContext = _Model;
        }
        private SearchModel _Model;
        private void OnStartFilter_Executed(object sender, ExecutedRoutedEventArgs e)
        {
                _Model.DoFilter();
                _Model.WriteXml();
                MessageBox.Show("查找成功！");
        }

        private void OnStartFilter_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OnStartHistory_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            _Model.ReadXml();
        }

        private void OnStartHistory_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

    }
}
