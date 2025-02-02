using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp7
{
    class Battle7
    {
        // StartFight
        // war1 attacks war2, war2 is damaged and health decreases fight end when one warrior health == 0 or -
        public static void StartFight(Warrior7 warrior1, Warrior7 warrior2)
        {
            while (true)
            {
                if (GetAttackResult(warrior1, warrior2) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
                if (GetAttackResult(warrior2, warrior1) == "Game Over")
                {
                    Console.WriteLine("Game Over");
                    break;
                }
            }
            
        }

        public static string GetAttackResult(Warrior7 warriorA, Warrior7 warriorB)
        {
            double warAAttkAmt = warriorA.Attack();
            double warBBlkAmt = warriorB.Block();
            double warBArmour = warriorB.fArmour();

            double dmg2WarB = (warAAttkAmt - warBBlkAmt);

            if (dmg2WarB > 0)
            {
                warriorB.Health = (warriorB.Health - dmg2WarB) + (warBArmour/10);
            }
            else dmg2WarB = 0;

            Console.WriteLine("{0} Attacks {1} and Deals {2} Damage and {3}'s Armour protects {4} damage",warriorA.Name, warriorB.Name,dmg2WarB,warriorB.Name,(warBArmour / 10));
            Console.WriteLine("{0} Has {1} Health\n", warriorB.Name, warriorB.Health);
            if (warriorB.Health <= 0)
            {
                Console.WriteLine("{0} has Died and {1} is victorious", warriorB.Name, warriorA.Name);

                return "Game Over";
            }
            else return "Fight Again";

        }
    }
}
