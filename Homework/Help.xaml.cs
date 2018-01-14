using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Homework
{
    /// <summary>
    /// Help.xaml 的交互逻辑
    /// </summary>
    public partial class Help : Window
    {
        public Help()
        {
            InitializeComponent();
            try
            {
                _Model = new HelpModel();
                // _Model.LoadXmlFile();
                _Model.LoadXmlFile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.DataContext = _Model;
        }
        private HelpModel _Model;
    }
}
