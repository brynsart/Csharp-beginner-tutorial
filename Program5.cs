using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp5;

namespace ConsoleApp5
{
    public class Program5
    {
        //Functions



        //End Of Functions



        static void Main(string[] args)
        {


            Vehicle5 buick = new Vehicle5("Buick", 4, 160);
            if (buick is IDrivable5)
            {
                buick.Move();
                buick.Stop();
            } else
            {
                Console.WriteLine("{0} Car is faulty so cannot be driven", buick.Brand);
            }


        }
    }
}