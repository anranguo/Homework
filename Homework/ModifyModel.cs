using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework
{
    class ModifyModel : INotifyPropertyChanged
    {
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Homework;Integrated Security=True;";
        public ModifyModel()
        {
            DataContext = new ScheduleDataDataContext(ConnectionString);
        }

        public void Submit()
        {
            DataContext.SubmitChanges();
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
