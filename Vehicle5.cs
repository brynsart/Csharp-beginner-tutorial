using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Vehicle5 : IDrivable5
    {
        public string Brand { get; set; }

        public Vehicle5(string brand = "No Brand", int wheels = 0, double speed = 0)
        {
            Brand = brand;
            Wheels = wheels;
            Speed = speed;
        }
        public double Speed { get; set; }
        public int Wheels { get; set; }

        public void Move()
        {
            Console.WriteLine($"The {Brand} moves forward at {Speed} MPH");
        }
        public void Stop()
        {
            Console.WriteLine($"The {Brand} Stops");
            Speed = 0;
        }
    }
}
