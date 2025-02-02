using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    interface IDrivable5
    {
        int Wheels { get; set; }
        double Speed { get; set; }

        void Move();

        void Stop();
    }
}
