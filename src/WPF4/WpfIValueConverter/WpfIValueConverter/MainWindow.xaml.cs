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

namespace WpfIValueConverter
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
        }

        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            List<Memo> lst = new List<Memo>();
            lst.Add(new Memo { Num = 1, Title = "안녕하세요.", PostDate = DateTime.Now.AddDays(-2) });
            lst.Add(new Memo { Num = 2, Title = "반갑습니다.", PostDate = DateTime.Now.AddDays(-1) });
            lst.Add(new Memo { Num = 3, Title = "또 만나요.", PostDate = DateTime.Now });
            lstMemo.ItemsSource = lst; 
        }
    }

    // 엔터티 클래스
    public class Memo
    {
        public int Num { get; set; }
        public string Title { get; set; }
        public DateTime PostDate { get; set; }
    }
}
