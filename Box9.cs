using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp9
{
    class Box9
    {
        public double Length { get; set; }
        public double Width { get; set; }
        public double Breadth { get; set; }

        public Box9()
            : this(1, 1, 1) { }

        public Box9(double length, double width, double breadth)
        {
            Length = length;
            Width = width;
            Breadth = breadth;
        }

        public static Box9 operator +(Box9 box1, Box9 box2) // makes it possible to add boxes in main program
        {
            Box9 box = new Box9() //makes a new box when adding the other boxes
            {
                Length = box1.Length + box2.Length,
                Width = box1.Width + box2.Width,
                Breadth = box1.Breadth + box2.Breadth
            };
            return box;
        }

        public static Box9 operator -(Box9 box1, Box9 box2) //returns Box
        {
            Box9 box = new Box9()
            {
                Length = box1.Length - box2.Length,
                Width = box1.Width - box2.Width,
                Breadth = box1.Breadth - box2.Breadth
            };
            return box;
        }

        public static bool operator ==(Box9 box1, Box9 box2) //returns bool
        {
            if ((box1.Length == box2.Length) && (box1.Width == box2.Width) && (box1.Breadth == box2.Breadth))
            {
                return true;
            }
            return false;
        }
        public static bool operator !=(Box9 box1, Box9 box2) //returns bool
        {
            if ((box1.Length != box2.Length) || (box1.Width != box2.Width) || (box1.Breadth != box2.Breadth))
            {
                return true;
            }
            return false;
        }

        public override string ToString() //whenever a box is called in string form it automatically uses this format
        {
            return String.Format("Box with height : {0} Width : {1} and Breadth : {2}", Length, Width, Breadth);
        }

        public static explicit operator int(Box9 b) //explicit and implicit already learnt but applying it to class conversion
        {
            return (int)(b.Length + b.Width + b.Breadth) / 3;
        }

        public static implicit operator Box9(int i)
        {
            return new Box9(i, i, i);
        }
    }
}