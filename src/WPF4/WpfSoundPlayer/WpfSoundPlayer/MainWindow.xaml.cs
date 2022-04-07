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
using System.Media;

namespace WpfSoundPlayer
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        SoundPlayer sp = new SoundPlayer("Dogbark.wav"); 

        public MainWindow()
        {
            InitializeComponent();

            btnQuestion.Click += new RoutedEventHandler(btnQuestion_Click);
            btnExclamation.Click += btnExclamation_Click;
            btnAsterisk.Click += (s, e) => {
                System.Media.SystemSounds.Asterisk.Play(); 
            };
            btnCustom.Click += new RoutedEventHandler(btnCustom_Click);

            sp.LoadAsync(); // 로드
        }

        void btnCustom_Click(object sender, RoutedEventArgs e)
        {            
            sp.Play(); 
        }

        void btnExclamation_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Exclamation.Play();
        }

        void btnQuestion_Click(object sender, RoutedEventArgs e)
        {
            System.Media.SystemSounds.Question.Play(); 
        }
    }
}
