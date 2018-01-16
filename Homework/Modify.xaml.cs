using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Modify.xaml 的交互逻辑
    /// </summary>
    public partial class Modify : Window
    {
        public Modify()
        {
            InitializeComponent();
            _Model = new ModifyModel();
            this.DataContext = _Model;
        }
        private ModifyModel _Model;



        private void OnStartModify_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            try
            {
                _Model.Submit();
                MessageBox.Show("修改成功！");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void OnStartModify_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
