using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace WpfAddressBook
{
    public partial class MainWindow : Window
    {
        #region Private Member Variables
        // 필드 선언부 : 주소록 정보 저장
        private List<Address> addr = new List<Address>();
        private string dir = System.IO.Path.Combine(
            AppDomain.CurrentDomain.BaseDirectory, "MyAddress.txt");
        private int currentIndex = 0;
        private bool blnModified = false; 
        #endregion

        #region Constructors
        public MainWindow()
        {
            InitializeComponent();

            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);

            miExit.Click += new RoutedEventHandler(miExit_Click);
            miBackup.Click += new RoutedEventHandler(miBackup_Click);
            miAbout.Click += new RoutedEventHandler(miAbout_Click);

            txtName.TextChanged += new TextChangedEventHandler(txtModify_TextChanged);
            txtMobile.TextChanged += new TextChangedEventHandler(txtModify_TextChanged);
            txtEmail.TextChanged += new TextChangedEventHandler(txtModify_TextChanged);

            btnAdd.Click += new RoutedEventHandler(btnAdd_Click);
            btnSave.Click += new RoutedEventHandler(btnSave_Click);
            btnModify.Click += new RoutedEventHandler(btnModify_Click);
            btnDelete.Click += new RoutedEventHandler(btnDelete_Click);

            btnFirst.Click += new RoutedEventHandler(btnMove_Click);
            btnPrev.Click += new RoutedEventHandler(btnMove_Click);
            btnNext.Click += new RoutedEventHandler(btnMove_Click);
            btnLast.Click += new RoutedEventHandler(btnMove_Click);

            btnGo.Click += new RoutedEventHandler(btnGo_Click);
            btnSearch.Click += new RoutedEventHandler(btnSearch_Click);

            dgvAddress.SelectedCellsChanged += new SelectedCellsChangedEventHandler(dgvAddress_SelectedCellsChanged);
        } 
        #endregion

        #region Event Handers
        // DataGrid의 셀 선택시 해당 레코드를 텍스트박스에 바인딩 
        void dgvAddress_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (dgvAddress.SelectedIndex != -1)
            {
                ShowRecord(dgvAddress.SelectedIndex); // 현재 선택된 인덱스 보이기 
            }
        }
        // 검색 
        void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            DisplayData(txtSearch.Text); 
        }
        // 이동
        void btnGo_Click(object sender, RoutedEventArgs e)
        {
            if (txtGo.Text != "" && Convert.ToInt32(txtGo.Text) > 0 && 
                Convert.ToInt32(txtGo.Text) <= addr.Count)
            {
                ShowRecord(Convert.ToInt32(txtGo.Text) - 1);
            }
        }
        // 처음/이전/다음/마지막
        void btnMove_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Name == "btnFirst") {
                if (currentIndex > 0) {
                    currentIndex = 0; // 0번째 인덱스로 표시
                }
            }
            else if (btn.Name == "btnPrev") {
                if (currentIndex > 0) {
                    currentIndex--;
                }
            }
            else if (btn.Name == "btnNext") {
                if (currentIndex < addr.Count - 1) {
                    currentIndex++;
                }
            }
            else if (btn.Name == "btnLast") {
                if (currentIndex != -1) {
                    currentIndex = addr.Count - 1;
                }
            }
            ShowRecord(currentIndex); // 다시 데이터 표시
        }
        // 삭제
        void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (txtNum.Text != "" && currentIndex != -1)
            {
                if (MessageBox.Show("정말로 삭제하시겠습니~?", "삭제", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {

                    addr.RemoveAt(currentIndex);
                    MessageBox.Show("삭제 완료");
                    DisplayData();
                }
            }
        }
        // 수정
        void btnModify_Click(object sender, RoutedEventArgs e)
        {
            if (currentIndex != -1 && blnModified == true)
            {
                // 변경된 데이터로 addr 개체의 현재 인덱스 데이터 변경
                addr[currentIndex].Name = txtName.Text;
                addr[currentIndex].Mobile = txtMobile.Text;
                addr[currentIndex].Email = txtEmail.Text;
                MessageBox.Show("수정되었습니다.", "수정완료");
                DisplayData();
                blnModified = false; // 다시 초기화
            }
        }
        // 저장
        void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (addr.Count > 0)
            {
                SaveData();
            }
        }
        // 입력/추가 버튼
        void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (btnAdd.Content.ToString() == "입력")
            {
                Address a = new Address();
                a.Num = addr.Count + 1; // 
                a.Name = txtName.Text.Trim();
                a.Mobile = txtMobile.Text.Trim();
                a.Email = txtEmail.Text.Trim();
                addr.Add(a);
                DisplayData(); // 출력 
            }
            else
            {
                btnAdd.Content = "입력";
            }
            ClearTextBox();
        }
        // 3개의 텍스트박스에서 공통 사용 이벤트 처리기
        void txtModify_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtNum.Text != "") // 데이터가 로드된 상태에서만
            {
                blnModified = true; // 변경되었다... 
            }
        }
        // 폼 로드
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            if (File.Exists(dir))
            {
                LoadData();
            }
            this.sslCount.Content = "총 레코드 수 : " + addr.Count.ToString();
            if (addr.Count > 0)
            {
                ShowRecord(0); // 첫번째 데이터를 표시
                btnAdd.Content = "추가";
            }
        }

        // 정보 메뉴
        void miAbout_Click(object sender, RoutedEventArgs e)
        {
            FrmAbout fa = new FrmAbout();
            fa.ShowDialog();
        }

        // 백업 메뉴
        void miBackup_Click(object sender, RoutedEventArgs e)
        {
            string name = System.IO.Path.GetFileNameWithoutExtension(dir);
            string ext = System.IO.Path.GetExtension(dir).Replace(".", "");

            // MyAddress20100101.txt로 저장가능하도록
            string newDir =
                System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                    String.Format("{0}{1}.{2}"
                        , name
                        , String.Format("{0}{1:0#}{2}"
                            , DateTime.Now.Year
                            , DateTime.Now.Month
                            , DateTime.Now.Day.ToString().PadLeft(2, '0')
                          )
                        , ext
                    )
                );

            if (File.Exists(dir))
            {
                File.Copy(dir, newDir, true); // 원본을 복사해서 백업
            }
        }

        // 끝내기 메뉴
        void miExit_Click(object sender, RoutedEventArgs e)
        {
            // Windows Forms
            // Application.Exit(); 
            // WPF
            Application.Current.Shutdown(); // 프로그램 종료
        } 
        #endregion

        #region Public Methods
        /// <summary>
        /// DB/File로부터 데이터를 읽어와 List&lt;T&gt;에 저장
        /// </summary>
        public void LoadData()
        {
            StreamReader sr = new StreamReader(dir, Encoding.Default);
            while (sr.Peek() >= 0) // -1 : 더 이상 읽을 문자가 없을때
            {
                string[] arr = sr.ReadLine().Trim().Split(',');

                if (arr[0] != "" && arr[0] != null)
                {
                    Address a = new Address();
                    a.Num = Convert.ToInt32(arr[0]); // 번호 : 인덱스+1
                    a.Name = arr[1];
                    a.Mobile = arr[2];
                    a.Email = arr[3];

                    addr.Add(a);
                }
            }
            sr.Close(); // 
            sr.Dispose(); // 
            DisplayData();  
        }
        /// <summary>
        /// List<T>에 있는 자료를 다시 DB/File로 영구 저장
        /// </summary>
        public void SaveData()
        {
            // 레코드는 엔터구분, 필드는 콤마구분으로 저장
            StringBuilder sb = new StringBuilder();
            int index = 0;
            foreach (Address a in addr)
            {
                sb.AppendLine(String.Format("{0},{1},{2},{3}"
                    , ++index, a.Name, a.Mobile, a.Email));
            }
            StreamWriter sw = new StreamWriter(dir, false, Encoding.Default);
            sw.Write(sb.ToString());
            sw.Close();
            sw.Dispose(); // 
            MessageBox.Show("저장되었습니다.");
        }
        // 데이터 표시 : DataGrid에 현재 주소록 정보 List<Address>를 출력
        public void DisplayData() 
        {
            var q = (from a in addr select a).ToList();
            this.dgvAddress.ItemsSource = q;
        }
        // 검색어를 넘겨서 필터링
        public void DisplayData(string query) 
        {
            var q = (from a in addr
                     where
                        a.Name == query ||
                        a.Mobile == query ||
                        a.Email == query
                     select a).ToList();
            this.dgvAddress.ItemsSource = q;
        }
        // 레코드 보이기 : 현재 선택된 또는 현재 인덱스의 레코드를 텍스트박스에 바인딩
        public void ShowRecord(int index)
        {
            // 현재 선택된 인덱스 + 1을 번호 출력
            this.txtNum.Text = (index + 1).ToString();
            this.txtName.Text = addr[index].Name;
            this.txtMobile.Text = addr[index].Mobile;
            this.txtEmail.Text = addr[index].Email;

            btnAdd.Content = "추가";
            txtGo.Text = txtNum.Text; // 현재 선택된 인덱스 값 출력
        }
        // 텍스트박스 클리어
        private void ClearTextBox()
        {
            txtName.Text = txtMobile.Text = txtEmail.Text = String.Empty;
        }
        #endregion
    }
}
