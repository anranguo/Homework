﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Homework
{
    class SearchModel : INotifyPropertyChanged
    {
        public List<Schedule> Records = new List<Schedule>();
        public const string ConnectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Homework;Integrated Security=True;";
        public SearchModel()
        {
            DataContext = new ScheduleDataDataContext(ConnectionString);

        }

        public void DoFilter()
        {
            Records = DataContext.Schedule.ToList();

            if (string.IsNullOrEmpty(Pattern))
            {
                FilteredResults = Records;
            }
            else
            {
                Regex aRegex = new Regex(Pattern);
                for (int i = 0; i < Records.Count; i++)
                {
                    string Words = (Records[i].Id).ToString() + " " + Records[i].Name + " " + Records[i].BeginDate + " " + Records[i].BeginTime + " " + Records[i].EndDate + " "
                        + Records[i].EndTime + " " + Records[i].Place + " " + Records[i].Memo;
                    MatchCollection aMatches = aRegex.Matches(Words);
                    for(int j = 0; j < aMatches.Count; j++)
                    {
                        if (aMatches[j].Success)
                            FilteredResults.Add(Records[i]);
                    }
                }

            }
            for (int i = 0; i < FilteredResults.Count; i++)
            {
                for (int j = FilteredResults.Count-1; j > i; j--)
                {

                    if (FilteredResults[i] == FilteredResults[j])
                    {
                        FilteredResults.RemoveAt(j);
                    }
                }
            }

        }

        public List<Schedule> FilteredResults { get { return _FilteredResults; } set { if (_FilteredResults == value) return; _FilteredResults = value; OnPropertyChanged(nameof(FilteredResults)); } }
        private List<Schedule> _FilteredResults;

        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;
        /*
        public Table<Schedule> Schedules
        {
            get { return DataContext.Schedule; }
        }
        */

        public ScheduleDataDataContext DataContext { get; }
        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}