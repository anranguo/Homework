using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Runtime.InteropServices;

namespace Homework
{
    class AlarmModel : INotifyPropertyChanged
    {
        public List<Schedule> Records = new List<Schedule>();
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Homework;Integrated Security=True;";
        public AlarmModel()
        {
            DataContext = new ScheduleDataDataContext(ConnectionString);
        }

        public void Alarm()
        {
            
            while (true)
            {
                Records = DataContext.Schedule.ToList();
                for (int i = 0; i < Records.Count; i++)
                {
                    char[] aSplit = { ':', '：'};
                    string[] BeginDateArray = Records[i].BeginDate.Split('/');
                    string[] BeginTimeArray = Records[i].BeginTime.Split(aSplit);
                    if (BeginDateArray.Length == 3 && BeginTimeArray.Length == 3)
                    {
                        int BeginYear = int.Parse(BeginDateArray[0]);
                        int BeginMonth = int.Parse(BeginDateArray[1]);
                        int BeginDay = int.Parse(BeginDateArray[2]);
                        int BeginHour = int.Parse(BeginTimeArray[0]);
                        int BeginMinute = int.Parse(BeginTimeArray[1]);
                        int BeginSecond = int.Parse(BeginTimeArray[2]);
                        if ((BeginYear == System.DateTime.Now.Year) && (BeginMonth == System.DateTime.Now.Month) && (BeginDay == System.DateTime.Now.Day) && (BeginHour == System.DateTime.Now.Hour) && (BeginMinute == System.DateTime.Now.Minute) && (BeginSecond == System.DateTime.Now.Second))
                        {
                            ShowMessage(Records[i].Name);
                        }
                    }
                }
            }
        }

        public void ShowMessage(object Name)
        {
            MessageBox.Show("现在是" + System.DateTime.Now + ",日程“" + Name + "”开始啦!", "提醒");
        }



        public Table<Schedule> Schedules
        {
            get { return DataContext.Schedule; }
        }

        public ScheduleDataDataContext DataContext { get; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
