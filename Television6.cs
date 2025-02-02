using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class Television6 : IElectronicDevice6
    {
        private int volume; // Volume = { get; set; }
        public int Volume
        {
            get { return volume; }
            set { volume = value; }
        }

        public void Off()
        {
            Console.WriteLine("The TV is Off");
        }

        public void On()
        {
            Console.WriteLine("The TV is On");
        }

        public void VolumeDown()
        {
            if (Volume != 0) Volume--;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }

        public void VolumeUp()
        {
            if (Volume != 100) Volume++ ;
            Console.WriteLine($"The TV Volume is at {Volume}");
        }
    }
}
