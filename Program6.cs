using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp6;

namespace ConsoleApp6
{
    public class Program6
    {
        //Functions



        //End Of Functions



        static void Main(string[] args)
        {
            IElectronicDevice6 TV = TVRemote6.GetDevice();

            PowerButton6 powBut = new PowerButton6(TV);

            powBut.Execute();
            powBut.Undo();
            powBut.Execute();
            powBut.Undo();
            
            Television6 tele = new Television6();
            tele.VolumeUp();
        }
    }
}