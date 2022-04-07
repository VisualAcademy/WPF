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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfNavigationService
{
    /// <summary>
    /// Page1.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page1 : Page
    {
        public Page1()
        {
            InitializeComponent();

            btnSend.Click += (s, a) => { 
                // Application 변수에 담아서 보내기
                Application.Current.Properties["MyName"] = txtName.Text;
                //NavigationService.Navigate(new Page2());
                NavigationService.Navigate(new Page2(txtAge.Text));
            };
        }
    }
}
