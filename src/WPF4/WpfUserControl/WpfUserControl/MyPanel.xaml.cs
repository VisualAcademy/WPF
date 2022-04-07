using System.Windows.Controls;
using System.Windows.Markup; //

namespace WpfUserControl
{
    // BodyText 속성을 기본 Content로 지정
    [ContentProperty("BodyText")]
    public partial class MyPanel : UserControl
    {
        public MyPanel()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 제목 영역
        /// </summary>
        public string TitleText
        {
            get { return txtTitle.Text; }
            set { txtTitle.Text = value; }
        }

        /// <summary>
        /// 내용 영역
        /// </summary>
        public string BodyText
        {
            get { return txtContext.Text; }
            set { txtContext.Text = value; }
        }
    }
}
