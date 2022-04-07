using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfHelloWorld
{
    /// <summary>
    /// FrmMain.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class FrmMain : Window
    {
        public FrmMain()
        {
            InitializeComponent();

            this.btnOK.Click += (s, a) => { MessageBox.Show("안녕하세요."); }; 
        }
    }
}
