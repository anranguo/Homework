using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Homework
{
    class HelpModel : INotifyPropertyChanged
    {
        public XmlDocument CurrentXml { get { return _CurrentXml; } set { if (_CurrentXml == value) return; _CurrentXml = value; OnPropertyChanged(nameof(CurrentXml)); } }
        private XmlDocument _CurrentXml;
        string aFileName = "E:/HelpMe.xml";
        public void LoadXmlFile()
        {
            XmlDocument aXml = new XmlDocument();
            aXml.Load(aFileName);
            CurrentXml = aXml;
        }

        private void OnPropertyChanged(string aPropertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(aPropertyName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
