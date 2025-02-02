using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp6
{
    class PowerButton6 : ICommand6
    {
        IElectronicDevice6 device;

        public PowerButton6(IElectronicDevice6 device)
        {
            this.device = device;
        }

        public void Execute()
        {
            device.On();
        }

        public void Undo()
        {
            device.Off();
        }
    }
}
