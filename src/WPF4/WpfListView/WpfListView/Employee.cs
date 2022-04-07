using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WpfListView
{
    public class Employee
    {
        public List<Employee> GetEmployees()
        {
            List<Employee> lst = new List<Employee>();

            lst.Add(new Employee() { Num = 1, Name = "박용준" });
            lst.Add(new Employee() { Num = 2, Name = "홍길동" });
            lst.Add(new Employee() { Num = 3, Name = "백두산" });
            lst.Add(new Employee() { Num = 4, Name = "한라산" });
            lst.Add(new Employee() { Num = 5, Name = "지리산" });
            lst.Add(new Employee() { Num = 6, Name = "임꺽정" });

            return lst; 
        }

        public int Num { get; set; }        // 번호
        public string Name { get; set; }    // 이름
    }
}
