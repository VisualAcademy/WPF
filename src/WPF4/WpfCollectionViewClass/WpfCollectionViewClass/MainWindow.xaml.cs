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
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace WpfCollectionViewClass
{
    public partial class MainWindow : Window
    {
        // 필드 영역
        private Collection<Person> people = new Collection<Person>();
        private bool isFiltered = false;
        public MainWindow()
        {
            InitializeComponent();

            // 폼 로드 이벤트 핸들러 등록
            this.Loaded += new RoutedEventHandler(MainWindow_Loaded);
            // 버튼에 대한 클릭 이벤트 등록
            btnSortbylast.Click += new RoutedEventHandler(btnSortbylast_Click);
            btnSortbydob.Click += new RoutedEventHandler(btnSortbydob_Click);
            btnFilter.Click += new RoutedEventHandler(btnFilter_Click);
        }        
        void btnFilter_Click(object sender, RoutedEventArgs e)
        {
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(lstPeople.ItemsSource);
            if (isFiltered)
            {
                cv.Filter = null; // 필터링 해제
                isFiltered = false; 
            }
            else
            {
                cv.Filter = new Predicate<object>(FilterBySmith); // 
                isFiltered = true; 
            }
        }
        // 필터링 관련 메서드
        public bool FilterBySmith(object item)
        {
            Person p = item as Person;
            return (p.LastName == "Smith"); 
        }
        void btnSortbydob_Click(object sender, RoutedEventArgs e)
        {
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(lstPeople.ItemsSource);
            cv.SortDescriptions.Clear();
            cv.SortDescriptions.Add(new SortDescription("Dateofbirth", ListSortDirection.Descending));        
        }
        void btnSortbylast_Click(object sender, RoutedEventArgs e)
        {
            // CollectionView 클래스를 사용한 데이터 정렬
            CollectionView cv = (CollectionView)CollectionViewSource.GetDefaultView(lstPeople.ItemsSource);
            cv.SortDescriptions.Clear();
            cv.SortDescriptions.Add(new SortDescription("LastName", ListSortDirection.Ascending)); 
        }
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // people에 샘플 데이터 입력
            people.Add(new Person { FirstName="용준", LastName="박", State="IN", Dateofbirth=new DateTime(1990, 02, 05) });
            people.Add(new Person() { FirstName = "Tom", LastName = "Smith", State = "NY", Dateofbirth = new DateTime(1962, 10, 30) });
            people.Add(new Person() { FirstName = "John", LastName = "Doe", State = "CA", Dateofbirth = new DateTime(1970, 3, 20) });
            people.Add(new Person() { FirstName = "Jane", LastName = "Doe", State = "AL", Dateofbirth = new DateTime(1970, 3, 20) });
            people.Add(new Person() { FirstName = "Bill", LastName = "Johnson", State = "CA", Dateofbirth = new DateTime(1970, 3, 20) });
            people.Add(new Person() { FirstName = "Stacey", LastName = "Zany", State = "GA", Dateofbirth = new DateTime(1970, 3, 20) });
            people.Add(new Person() { FirstName = "Liz", LastName = "Smith", State = "TX", Dateofbirth = new DateTime(1970, 3, 20) });
            people.Add(new Person() { FirstName = "Jim", LastName = "Jones", State = "TX", Dateofbirth = new DateTime(1970, 3, 20) });

            // ListBox에 바인딩
            lstPeople.ItemsSource = people; 
        }

    }

    // Person 클래스 생성
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string State { get; set; }
        public DateTime Dateofbirth { get; set; }
    }

}
