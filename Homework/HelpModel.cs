using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework
{
    class HelpModel : INotifyPropertyChanged
    {

        public List<string> HelpMe { get { return _HelpMe; } set { if (_HelpMe == value) return; _HelpMe = value; OnPropertyChanged(nameof(HelpMe)); } }
        private List<string> _HelpMe;
        public HelpModel()
        {
            //HelpMe = "";
        }

        public void GetTxt()
        {
            FileStream fs = new FileStream("HelpMe.txt", FileMode.Open, FileAccess.Read);
            List<string> aList = new List<string>();
            StreamReader sr = new StreamReader(fs, Encoding.GetEncoding("gb2312")); 
            sr.BaseStream.Seek(0, SeekOrigin.Begin);
            string tmp = sr.ReadLine();
            //byte[] buffer = Encoding.UTF8.GetBytes(tmp);
            //tmp = Encoding.GetEncoding("UTF-8").GetString(buffer);
            while (tmp != null)
            {
                aList.Add(tmp);
                tmp = sr.ReadLine();
            }
            sr.Close();
            fs.Close();
            HelpMe = aList;
        }



        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
