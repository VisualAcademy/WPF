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

namespace WpfBindingExpression
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

        private void btnBinding_Click(object sender, RoutedEventArgs e)
        {
            // 대상에서 원본으로 바인딩 구현
            BindingExpression be = txtDestination.GetBindingExpression(TextBox.TextProperty);
            be.UpdateSource(); 
        }
    }
}
