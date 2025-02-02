using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class MagicWarrior7 : Warrior7
    {
        int teleportChance = 0;
        CanTeleport7 teleportType = new CanTeleport7();

        public MagicWarrior7(string name = "Warrior", double health = 0, double attkMax = 0, double blockMax = 0, double armour = 0, int teleportChance = 0)
            : base(name, health, attkMax, blockMax, armour)
        {
            this.teleportChance = teleportChance;
        }

        public override double Block()
        {
            Random rnd = new Random();
            int rndDodge = rnd.Next(1, 100);

            if (rndDodge < this.teleportChance)
            {
                Console.WriteLine($"{Name} {teleportType.teleport()}");
                return 10000; //to ensure no damage is taken when teleports
            }
            else
            {
                return base.Block();
            }
        }
    }
}
