using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class TVRemote6
    {
        public static IElectronicDevice6 GetDevice()
        {
            return new Television6();
        }
    }
}
