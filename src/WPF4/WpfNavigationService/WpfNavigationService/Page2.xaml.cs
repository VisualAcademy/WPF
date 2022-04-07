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
    /// Page2.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }
        // 매개변수가 있는 생성자
        public Page2(string age)
        {
            InitializeComponent();
            lblAge.Text = age; // 넘겨온 나이값 출력
        }

        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            // 넘겨온 값 받기
            lblName.Text = App.Current.Properties["MyName"].ToString();
        }
    }
}
