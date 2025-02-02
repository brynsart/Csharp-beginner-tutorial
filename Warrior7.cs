using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Warrior7
    {
        public string Name { get; set; }
        public double Health {  get; set; }
        public double AttkMax { get; set; }
        public double BlockMax { get; set; }
        public double Armour { get; set; }

        Random rnd = new Random();

        public Warrior7(string name = "Warrior", double health = 0, double attkMax = 0, double blockMax = 0, double armour = 0)
        {
            Name = name;
            Health = health;
            AttkMax = attkMax;
            BlockMax = blockMax;
            Armour = armour;
        }

        public double Attack()
        {
            return rnd.Next(1, (int)AttkMax);
        }
        public virtual double Block()
        {
            return rnd.Next(1, (int)BlockMax);
        }
        public double fArmour()
        {
            return Armour;
        }
    }
}
