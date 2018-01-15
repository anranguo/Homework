using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Linq;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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
                List<Schedule> Results = new List<Schedule>();
                for (int i = 0; i < Records.Count; i++)
                {
                    string Words = (Records[i].Id).ToString() + " " + Records[i].Name + " " + Records[i].BeginDate + " " + Records[i].BeginTime + " " + Records[i].EndDate + " "
                        + Records[i].EndTime + " " + Records[i].Place + " " + Records[i].Memo;
                    MatchCollection aMatches = aRegex.Matches(Words);
                    for(int j = 0; j < aMatches.Count; j++)
                    {
                        if (aMatches[j].Success)
                            Results.Add(Records[i]);
                    }
                }
                FilteredResults = Results;

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

        public void WriteXml()
        {
            XmlDocument aXml = new XmlDocument();
            XmlElement History;
            if (File.Exists("History.xml"))
            {
                aXml.Load("History.xml");
                History = aXml.DocumentElement;
            }
            else
            {
                XmlDeclaration dec = aXml.CreateXmlDeclaration("1.0", "utf-8", null);
                aXml.AppendChild(dec);
                History = aXml.CreateElement("History");
                aXml.AppendChild(History);
            }
            XmlElement OneHistory = aXml.CreateElement("OneHistory");
            History.AppendChild(OneHistory);
            XmlElement Regular = aXml.CreateElement("Regular");
            Regular.InnerText = Pattern;
            OneHistory.AppendChild(Regular);
            XmlElement Time  = aXml.CreateElement("Time");
            string NowTime = System.DateTime.Now.ToString();
            Time.InnerText = NowTime;
            OneHistory.AppendChild(Time);
            aXml.Save("History.xml");
        }

        public void ReadXml()
        {
            List<string> aList = new List<string>();
            XDocument aXml = XDocument.Load("History.xml");
            XElement aRoot = aXml.Root;
            XElement OneHistory = aRoot.Element("OneHistory");
            XElement shuxing = OneHistory.Element("Regular");
            IEnumerable<XElement> aEnumerable = aRoot.Elements();
            foreach (XElement Item in aEnumerable)
            {
                foreach (XElement Item1 in Item.Elements())
                    if (Item1.Name.Equals(shuxing.Name))
                    {
                        aList.Add(Item1.Value);
                    }
            }
            HistoryList = aList;
        }


        public List<string> HistoryList { get { return _HistoryList; } set { if (_HistoryList == value) return; _HistoryList = value; OnPropertyChanged(nameof(HistoryList)); } }
        private List<string> _HistoryList;

        public List<Schedule> FilteredResults { get { return _FilteredResults; } set { if (_FilteredResults == value) return; _FilteredResults = value; OnPropertyChanged(nameof(FilteredResults)); } }
        private List<Schedule> _FilteredResults;

        public string Pattern { get { return _Pattern; } set { if (_Pattern == value) return; _Pattern = value; OnPropertyChanged(nameof(Pattern)); } }
        private string _Pattern;

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
