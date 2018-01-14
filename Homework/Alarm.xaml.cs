using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Alarm.xaml 的交互逻辑
    /// </summary>
    public partial class Alarm : Window
    {
        public Alarm()
        {
            InitializeComponent();
            _Model = new AlarmModel();
            this.DataContext = _Model;

            BackgroundWorker aBackgroundWorker = new BackgroundWorker();
            aBackgroundWorker.WorkerReportsProgress = true; 
            aBackgroundWorker.WorkerSupportsCancellation = true;
            aBackgroundWorker.DoWork += new DoWorkEventHandler(_Model.Alarm);
            aBackgroundWorker.RunWorkerAsync(this);


        }
        private AlarmModel _Model;

        private void OnAlarm_Click(object sender, RoutedEventArgs e)
        {
           // _Model.Alarm();
        }
    }
}
