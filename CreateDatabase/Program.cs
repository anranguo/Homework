using Homework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CreateDatabase
{
    class CreateDatabase
    {
        const string ConnectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=Homework;Integrated Security=true;";
        static void Main(string[] args)
        {
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

                    Schedule aNewSchedule = new Schedule { Name = "睡觉", BeginDate = "qqq", BeginTime = "qqqqq" };
                    aDataContext.Schedule.InsertOnSubmit(aNewSchedule);
                    aDataContext.SubmitChanges();

                    List<Schedule> Records = new List<Schedule>();
                    List<Schedule> FilteredResults = new List<Schedule>();
                    Records =aDataContext.Schedule.ToList();
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
        }
    }
}
