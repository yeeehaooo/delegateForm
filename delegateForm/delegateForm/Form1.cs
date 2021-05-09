using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static delegateForm.Student;

namespace delegateForm
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //委派 1.宣告一個委託  2.實例委託  3.調用。
        Student _StudentList = new Student();
        private void button1_Click(object sender, EventArgs e)
        {            
            Student_Select student_Select = new Student_Select(_StudentList.男生); //委託傳遞的方法(邏輯)，()裡 可以抽換邏輯，可以新增，不用修改
            var result = _StudentList.Get_result(_StudentList.Get_newlist(), student_Select); //查詢結果(查詢清單，邏輯)
            _StudentList.show(result);
        }


        //get 男生
        private void button2_Click(object sender, EventArgs e)
        {
            List<Student> studentLists = new List<Student>();
            foreach (var student in _StudentList.Get_newlist())
            {
                if (student.StudentGender == "男") //
                {
                    studentLists.Add(student);
                }
            }
            foreach (var item in studentLists)
            {
                Console.WriteLine($"{item.StudentName}:性別 {item.StudentGender}，今年{item.StudentAge}歲，就讀{item.StudentClass}班");
            }

            

        }

        //get A班
        private void button3_Click(object sender, EventArgs e)
        {
            List<Student> studentLists = new List<Student>();
            foreach (var student in _StudentList.Get_newlist())
            {
                if (student.StudentClass == "A")
                {
                    studentLists.Add(student);
                }
            }
            foreach (var item in studentLists)
            {
                Console.WriteLine($"{item.StudentName}:性別 {item.StudentGender}，今年{item.StudentAge}歲，就讀{item.StudentClass}班");
            }
        }
    }
}
