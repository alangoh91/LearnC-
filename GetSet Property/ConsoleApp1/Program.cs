using System;
using ConsoleApp1;
using static Sample4.Trivial;

namespace ConsoleApp1
{
    //#region Sample 1
    //class C1
    //{
    //    private int theRealValue = 10;
    //    public int MyValue
    //    {
    //      //C# 7.0 newly introduction
    //      set => theRealValue = value > 100 ? 100: value; 
    //      get => theRealValue;

    //        /** 
    //        ****** "old" syntax ******
    //        set { theRealValue = value > 100 ? 100 : value; }
    //        get { return theRealValue; }
    //        **/
    //    }
    //}

    //class Program
    //{
    //static void Main()
    //{
    //    C1 c = new C1();
    //    Console.WriteLine("MyValue: {0}", c.MyValue);

    //    c.MyValue = 200;
    //    Console.WriteLine("MyValue: {0}", c.MyValue);
    //}
    //}
    //#endregion

    //#region Sample 2 - RightTriangle
    //class RightTriangle
    //{
    //    public double A = 3;
    //    public double B = 4;
    //    public double Hypotenuse
    //    {
    //        get { return Math.Sqrt((A * A) + (B * B)); }
    //    }
    //}
    //class Program
    //{
    //    static void Main()
    //    {
    //        RightTriangle c = new RightTriangle();
    //        Console.WriteLine($"Hypotenuse: {c.Hypotenuse}");
    //    }
    //}
    //#endregion

    //#region Sample 3 - Auto-properties
    //class C1
    //{
    //    public int myValue
    //    {
    //        set; get;
    //    }
    //}
    //class Program
    //{
    //    static void Main()
    //    {
    //        C1 c = new C1();
    //        Console.WriteLine("MyValue: {0}", c.MyValue);

    //        c.MyValue = 20;
    //        Console.WriteLine("MyValye: {0}",c.MyValue);
    //    }
    //}
    //#endregion

}
namespace Sample4
{
    class Trivial
    {
        public static int MyValue { get; set; }
        public void PrintValue()
        { Console.WriteLine("Value from inside: {0}", MyValue); }
    }
    class Program {
        static void Main()
        {
            Console.WriteLine("Init Value: {0}", Trivial.MyValue);

            Trivial.MyValue = 10;
            Console.WriteLine("New Value: {0}", Trivial.MyValue);

            MyValue = 20;
            Console.WriteLine($"New Value: {MyValue}");

            Trivial tr = new Trivial(); //accessed from outsie the class, but no class name because of using static
            tr.PrintValue();
        }
    }
}

