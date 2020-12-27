using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Student
    {
        /// <summary>
        /// Student Numberrrr
        /// </summary>
        public string StuNo;

        public string StuName;

        public int StuAge;

        public Student() { } 
        

        public Student(string StuNo, string StuName, int StuAge ) {
            this.StuName = StuName;
            this.StuAge = StuAge;
            this.StuNo = StuNo;
            }

    }
}
