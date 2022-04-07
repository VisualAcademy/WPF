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
using System.Runtime.InteropServices;

namespace WpfWallpagerWithIActiveDesktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            btnChange.Click += new RoutedEventHandler(btnChange_Click);
        }

        void btnChange_Click(object sender, RoutedEventArgs e)
        {
            int nResult ;
            nResult = WinAPI.SystemParametersInfo(20, 0, "C:\\Penguins.jpg", 0x1 | 0x2);
            MessageBox.Show("바탕화면이 변경되었습니다.");
        }
    }

    public class WinAPI
    {
        [DllImport("user32.dll", CharSet=CharSet.Auto)]
        public static  extern int SystemParametersInfo (int uAction , int uParam , string lpvParam , int fuWinIni) ;
    }
}
