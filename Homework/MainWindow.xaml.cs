using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Homework
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void OnCreate_Click(object sender, RoutedEventArgs e)
        {
            Create c = new Create();
            c.Show();
        }

        private void OnModify_Click(object sender, RoutedEventArgs e)
        {
            Modify m = new Modify();
            m.Show();
        }

        private void OnSearch_Click(object sender, RoutedEventArgs e)
        {
            Search s = new Search();
            s.Show();

        }

        private void OnHelp_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OnAlarm_Click(object sender, RoutedEventArgs e)
        {
            Alarm a = new Alarm();
            a.Show();
        }
    }
}
