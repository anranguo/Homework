using Homework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace CreateDatabase
{
    class CreateDatabase
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Homework;Integrated Security=true;";
        static void Main(string[] args)
        {
            //没什么用，测试使的
            /*
            try
            {
                // 连接数据库引擎
                using (ScheduleDataDataContext aDataContext = new ScheduleDataDataContext(ConnectionString))
                {
                    if (!aDataContext.DatabaseExists())
                    {
                        aDataContext.CreateDatabase();
                        Console.WriteLine("数据库已经创建！");
                    }
                    else
                    {
                        Console.WriteLine("数据库已经存在！");
                    }

                    Schedule aNewSchedule = new Schedule { Name = "睡wqcfv", BeginDate = "2018/1/14", BeginTime = "17:38:00" };
                    aDataContext.Schedule.InsertOnSubmit(aNewSchedule);
                    aDataContext.SubmitChanges();

                    List<Schedule> Records = new List<Schedule>();
                    List<Schedule> FilteredResults = new List<Schedule>();
                    Records =aDataContext.Schedule.ToList();
                    /*
                    while (true)
                    {
                        for (int i = 0; i < Records.Count; i++)
                        {
                            string[] BeginDateArray = Records[i].BeginDate.Split('/');
                            string[] BeginTimeArray = Records[i].BeginTime.Split(':');
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
                                    Console.WriteLine(Records[i].Name);
                                }
                            }
                        }
                    }
                
                    string Pattern = "2018";
                    Regex aRegex = new Regex(Pattern);
                    for (int i = 0; i < Records.Count; i++)
                    {
                        string Words = (Records[i].Id).ToString() + " " + Records[i].Name + " " + Records[i].BeginDate + " " + Records[i].BeginTime + " " + Records[i].EndDate + " "
                            + Records[i].EndTime + " " + Records[i].Place + " " + Records[i].Memo;
                        MatchCollection aMatches = aRegex.Matches(Words);
                        for (int j = 0; j < aMatches.Count; j++)
                        {
                            if (aMatches[j].Success)
                                FilteredResults.Add(Records[i]);
                        }
                    }
                    for (int i = 0; i < FilteredResults.Count; i++) 
                    {
                        for (int j = FilteredResults.Count - 1; j > i; j--)
                        {

                            if (FilteredResults[i] == FilteredResults[j])
                            {
                                FilteredResults.RemoveAt(j);
                            }

                        }
                    }

                    for (int i = 0; i < FilteredResults.Count; i++)
                    {
                        Schedule se =FilteredResults[i];
                        Console.WriteLine(se.Name);
                        Console.WriteLine(se.Id);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            Console.WriteLine("按回车键退出……");
            Console.ReadLine();
    */
        }
    }
}
