using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class CreateModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Homework;Integrated Security=True;";

        public CreateModel()
        {
            DataContext = new ScheduleDataDataContext(ConnectionString);
        }
        public void Submit()
        {
            Schedule aNewSchedule = new Schedule { Name = this.Name, BeginDate = this.BeginDate, BeginTime = this.BeginTime, EndDate = this.EndDate, EndTime = this.EndTime, Place = this.Place, Memo = this.Memo };

            //Schedule aNewSchedule = new Schedule { Name=this.Name, BeginDate=this.BeginDate.ToString("yyyy/mm/dd"), BeginTime=this.BeginTime, EndDate=this.EndDate.ToLongDateString(),EndTime=this.EndTime,Place = this.Place,Memo=this.Memo};
            DataContext.Schedule.InsertOnSubmit(aNewSchedule);
            DataContext.SubmitChanges();
        }

        public string Name { get { return _Name; } set { if (_Name == value) return; _Name = value; OnPropertyChanged(nameof(Name)); } }
        private string _Name;

        public string  BeginDate { get { return _BeginDate; } set { if (_BeginDate == value) return; _BeginDate = value; OnPropertyChanged(nameof(BeginDate)); } }
        private string  _BeginDate;

        public string BeginTime { get { return _BeginTime; } set { if (_BeginTime == value) return; _BeginTime = value; OnPropertyChanged(nameof(BeginTime)); } }
        private string _BeginTime;

        public string EndDate { get { return _EndDate; } set { if (_EndDate == value) return; _EndDate = value; OnPropertyChanged(nameof(EndDate)); } }
        private string _EndDate;

        public string EndTime { get { return _EndTime; } set { if (_EndTime == value) return; _EndTime = value; OnPropertyChanged(nameof(EndTime)); } }
        private string _EndTime;

        public string Place { get { return _Place; } set { if (_Place == value) return; _Place = value; OnPropertyChanged(nameof(Place)); } }
        private string _Place;


        public string Memo { get { return _Memo; } set { if (_Memo == value) return; _Memo = value; OnPropertyChanged(nameof(Memo)); } }
        private string _Memo;

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
