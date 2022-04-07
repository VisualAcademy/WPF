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

namespace WpfNavigation
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOpenPage1_Click(object sender, RoutedEventArgs e)
        {
            //// Window 열기
            //Window1 w1 = new Window1();
            //w1.Show();

            // Tip. Window 폼에서 Page 폼 열기 
            NavigationWindow nw = new NavigationWindow();
            nw.Height = this.Height;
            nw.Width = this.Width;
            nw.Show();
            nw.Navigate(new Uri("Page1.xaml", UriKind.Relative));
            this.Close(); 
        }
    }
}
