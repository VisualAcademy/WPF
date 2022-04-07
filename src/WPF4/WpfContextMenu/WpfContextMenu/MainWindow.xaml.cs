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

namespace WpfContextMenu
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            miSecond.Click += new RoutedEventHandler(miSecond_Click);
            miThird.Click += (s, e) => { MessageBox.Show("세번째"); };
        }

        void miSecond_Click(object sender, RoutedEventArgs e)
        {
            //MessageBox.Show("두번째");
        }

        private void miFirst_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("첫번째 메뉴 클릭됨");
        }
    }
}
