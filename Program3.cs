using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp3
{
    public class Program
    {
        //Functions



        //End Of Functions



        static void Main(string[] args)
        {

            Animal3 cat = new Animal3();
            /*cat.SetName("Whiskers");
            cat.SoundB = "Meow";*/

            Animal3 whiskers = new Animal3()
            {
                Name = "Whiskers",
                Sound = "Meow"
            };

            Dog grover = new Dog()
            {
                Name = "Grover",
                Sound = "Woof",
                Sound2 = "Grrrrrr"
            };

            grover.Sound = "Wooooooooof";

            whiskers.MakeSound();
            grover.MakeSound();
            whiskers.SetAnimalIDInfo(12345, "Sally Smith");
            grover.SetAnimalIDInfo(12346, "Paul Brown");
            whiskers.GetAnimalIDInfo();
            Animal3.AnimalHealth getHealth = new Animal3.AnimalHealth();
            Console.WriteLine("Is my animal healthy : {0}", getHealth.HealthyWeight(11, 46));
            Animal3 monkey = new Animal3()
            {
                Name = "Happy",
                Sound = "Eeeeeee"
            };
            Animal3 spot = new Dog()
            {
                Name = "Spot",
                Sound = "Woffff",
                Sound2 = "Gyarrr"
            };
            spot.MakeSound();

            /*Console.WriteLine("The cat is named {0} and makes sound {1}",
                cat.GetName(), cat.Sound);
            cat.Owner = "Dave";
            Console.WriteLine("{0} owner is {1}",cat.GetName(),cat.Owner);
            Console.WriteLine("{0} shelter id is {1}", cat.GetName(), cat.idNum);
            Console.WriteLine("Number of animals is {0}", Animal.NumOfAnimals);*/

            /*Rectangle rect1;
            rect1.length = 200;
            rect1.width = 50;
            Console.WriteLine("Area of rect1 : {0}",
                rect1.Area());
            Rectangle rect2 = new Rectangle(100,40);
            rect2 = rect1;
            rect1.length = 33;
            Console.WriteLine("Rect2.length : {0}",
                rect2.length);

            Animal fox = new Animal()
            {
                name = "Red",
                sound = "Raaw"
            };

            Console.WriteLine("# of Animals : {0}",
                Animal.GetNumAnimals());

            Console.WriteLine("Area of Rectangle : {0}",
                ShapeMath.GetArea("Rectangle", 5, 6));

            int? randNum = null;
            if (randNum == null)
            {
                Console.WriteLine("randNum is null");
            }
            if (!randNum.HasValue) 
            {
                Console.WriteLine("randNum is null");
            }*/
        }
        /*struct Rectangle
        {
            public double length;
            public double width;

            public Rectangle(double l = 1, double w = 1)
            {

                length = l; width = w;
            }
            public double Area()
            {
                return length * width;
            }
        }*/
    }
}