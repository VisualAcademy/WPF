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
using System.IO.IsolatedStorage;
using System.IO;

namespace WpfIsolatedStorage
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
        }
        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            // 리스트박스에 색상명 추가
            if (txtColor.Text != String.Empty)
            {
                ListBoxItem lbi = new ListBoxItem();
                lbi.Content = txtColor.Text; 
                lstColors.Items.Add(lbi);
                txtColor.Text = String.Empty; 
            }
        }
        // 폼이 닫힐 때 영구 보관
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream =
                new IsolatedStorageFileStream("MyColorLists.iso", FileMode.Create, f))
            {
                using (StreamWriter sw = new StreamWriter(stream))
                {
                    foreach (ListBoxItem lbi in lstColors.Items)
                    {
                        sw.WriteLine(lbi.Content.ToString());
                    }
                }
            }
        }
        // 폼이 초기화될 때 로드 
        protected override void OnInitialized(EventArgs e)
        {
            base.OnInitialized(e);
            IsolatedStorageFile f = IsolatedStorageFile.GetUserStoreForAssembly();
            using (IsolatedStorageFileStream stream = 
                new IsolatedStorageFileStream("MyColorLists.iso", FileMode.OpenOrCreate, f))
            {
                using (StreamReader sr = new StreamReader(stream))
                {
                    string color = sr.ReadLine();
                    while (color != null)
                    {
                        ListBoxItem lbi = new ListBoxItem(); lbi.Content = color;
                        lstColors.Items.Add(lbi);
                        color = sr.ReadLine(); // 파일 끝까지 읽어오기 
                    }
                }                    
            }
        }
    }
}
