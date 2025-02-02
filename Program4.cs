using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp4;

namespace ConsoleApp3
{
    public class Program4
    {
        //Functions



        //End Of Functions



        static void Main(string[] args)
        {
            Shape4[] shapes = { new Circle4(5), new Rectangle4(4, 5) };
            foreach (Shape4 s in shapes)
            {
                s.GetInfo();

                Console.WriteLine("{0} Area : {1:f2}", s.Name, s.Area);

                Circle4 testCirc = s as Circle4;
                if (testCirc == null)
                {
                    Console.WriteLine("This isn't a Circle");
                }
                if (s is Circle4)
                {
                    Console.WriteLine("This isn't a Rectangle");
                }
            }

            object circ1 = new Circle4(4);

            Circle4 circ2 = (Circle4) circ1;
            Console.WriteLine("The {0} Area is {1:f2}", circ2.Name, circ2.Area());


        }
    }
}