using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    abstract class Shape4
    {
        public string Name { get; set; }

        public virtual void GetInfo() 
        {
            Console.WriteLine($"This is a {Name}");
        }
        public abstract double Area();
    }
}
