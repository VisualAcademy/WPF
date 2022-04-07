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
using System.Threading;
using System.Globalization;

namespace WpfResourceFile
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            // 영어/한국어 중 선택
            //Thread.CurrentThread.CurrentUICulture = new CultureInfo("en-US");

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // 폼 로드시 다국어 정의
            //lblTitle.Text = GlobalLocalResource.TitleLabel;
            //lblName.Text = GlobalLocalResource.NameLabel;
            lblAge.Text = GlobalLocalResource.AgeLabel;
            btnSubmit.Content = GlobalLocalResource.SubmitLabel; 
        }
    }
}
