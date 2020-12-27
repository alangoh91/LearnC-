using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Net;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApp1
{

    class Program
    {
        static void Main(string[] args)
        {

            Student stu1 = new Student("2040","Alan",29);
            Student stu2 = new Student("2050", "John", 30);
            Student stu3 = new Student("2060", "Undertaker", 50);

            Dictionary<string, Student> dict = new Dictionary<string, Student>(); 
           
            dict.Add("alan",stu1); 
            dict.Add("John",stu2);
            dict.Add("WWE",stu3);

            Student stu = dict["WWWE"];

            Console.WriteLine(stu.StuName);
            Console.ReadLine();
        }
           
    }
}
