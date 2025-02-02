using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp7;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp7
{
    public class Program7
    {
        //Functions



        //End Of Functions



        static void Main(string[] args)
        {
            // thor = new Warrior("Thor",100 Health, 26 Damage, 10 Block); 
            // hulk = new Warrior("Hulk",100 Health, 26 Damage, 10 Block); 
            // Battle.StartFight(thor,hulk)
            // goal of minimising lines in main program using different classes to improve robustness of code and readability

            Warrior7 thor = new Warrior7("Thor", 100, 26, 10, 15);
            MagicWarrior7 loki = new MagicWarrior7("Loki", 75, 20, 10, 5, 50);
            Battle7.StartFight(thor, loki);
        }
    }
}