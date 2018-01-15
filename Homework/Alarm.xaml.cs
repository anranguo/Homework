using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Alarm.xaml 的交互逻辑
    /// </summary>
    public partial class Alarm : Window
    {
        public Alarm()
        {
            InitializeComponent();
            _Model = new AlarmModel();
            this.DataContext = _Model;
            Thread NowThread = new Thread(new ThreadStart(_Model.Alarm));
            NowThread.Start();
        }
        private AlarmModel _Model;

    }
}
