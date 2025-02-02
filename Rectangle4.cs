using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Rectangle4 : Shape4
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public Rectangle4(double length, double width)
        {
            Name = "Rectangle";
            Length = length;
            Width = width;
        }

        public override double Area()
        {
            return Length * Width;
        }
        public override void GetInfo()
        {
            base.GetInfo();
            Console.WriteLine($"It has a Length of {Length} and a Width of {Width}");
        }
    }
}
