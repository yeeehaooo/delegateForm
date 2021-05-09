using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace delegateForm
{

    public class Student
    {
        public string StudentName { get; set; }
        public string StudentGender { get; set; }
        public int StudentAge { get; set; }
        public string StudentClass { get; set; }


        //建立清單
        public List<Student> Get_newlist()
        {
            List<Student> studentLists = new List<Student>()
            {
                new Student
                {
                    StudentName="Andy",
                    StudentGender="男",
                    StudentAge=20,
                    StudentClass="A"
                },
                new Student
                {
                    StudentName="John",
                    StudentGender="男",
                    StudentAge=19,
                    StudentClass="A"
                },
                new Student
                {
                    StudentName="King",
                    StudentGender="男",
                    StudentAge=19,
                    StudentClass="B"
                },
                new Student
                {
                    StudentName="Mary",
                    StudentGender="女",
                    StudentAge=18,
                    StudentClass="B"
                }
            };
            return studentLists;
        }

        //查詢
        public List<Student> Get_result(List<Student> source , Student_Select student_Select)
        {
            List<Student> studentLists = new List<Student>();
            foreach (var student in source)
            {
                if (student_Select.Invoke(student))
                {
                    studentLists.Add(student);
                }
            }
            return studentLists;
        }

        //Console 顯示結果
        public void show(List<Student> source)
        {
            Console.WriteLine("========================================================================");
            foreach (var student in source)
            {
                Console.WriteLine($"{student.StudentName}:性別 {student.StudentGender}，今年{student.StudentAge}歲，就讀{student.StudentClass}班");
            }
        }

        //查詢條件
        public delegate bool Student_Select(Student student);
        internal bool 男生(Student student)
        {
            return student.StudentGender=="男";
        }
        internal bool A班(Student student)
        {
            return student.StudentClass == "A";
        }

    }

}
