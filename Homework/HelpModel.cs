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
        }

        public void GetTxt()
        {
            FileStream aFileStream = new FileStream("HelpMe.txt", FileMode.Open, FileAccess.Read);
            List<string> aList = new List<string>();
            StreamReader aStreamReader = new StreamReader(aFileStream, Encoding.GetEncoding("gb2312"));
            aStreamReader.BaseStream.Seek(0, SeekOrigin.Begin);
            string Temp = aStreamReader.ReadLine();
            while (Temp != null)
            {
                aList.Add(Temp);
                Temp = aStreamReader.ReadLine();
            }
            aStreamReader.Close();
            aFileStream.Close();
            HelpMe = aList;
        }



        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
