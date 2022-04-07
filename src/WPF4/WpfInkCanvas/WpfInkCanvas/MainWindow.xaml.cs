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
using System.IO;

namespace WpfInkCanvas
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnSave.Click += new RoutedEventHandler(btnSave_Click);
            btnLoad.Click += (s, e) => {
                // 저장된 잉크 파일을 읽어서 InkCanvas에 출력
                FileStream fs = new FileStream("myInk.ink", FileMode.Open);
                myPen.Strokes = new System.Windows.Ink.StrokeCollection(fs);
                fs.Close(); 
            };
        }

        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // 잉크 정보를 파일에 저장
            FileStream fs = new FileStream("myInk.ink", FileMode.Create);
            myPen.Strokes.Save(fs);
            fs.Close(); 
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            // 잉크 지우기
            myPen.Strokes.Clear(); 
        }
    }
}
