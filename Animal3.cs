using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Animal
    {
        private string name;
        protected string sound;

        protected AnimalIDInfo animalIDInfo = new AnimalIDInfo();

        public void SetAnimalIDInfo(int idNum, string owner)
        {
            animalIDInfo.IDNum = idNum;
            animalIDInfo.Owner = owner;
        }

        public void GetAnimalIDInfo()
        {
            Console.WriteLine($"{Name} has the ID of {animalIDInfo.IDNum} and is owned by {animalIDInfo.Owner}");
        }

        public virtual void MakeSound()
        {
            Console.WriteLine($"{Name} says {Sound}");
        }

        public Animal() : this("No Name", "No Sound") { }
        // default animal if nothing is set
        //constructor uses same name as the class and the object

        public Animal(string name) : this(name, "No Sound") { }

        public Animal(string name, string sound)
        {
            Name = name;
            Sound = sound;
        }



        /*public static int GetNumAnimals()
        {
            return numOfAnimals;
        }*/

        /*public void SetName(string name) 
        {
            if(!name.Any(char.IsDigit))
            {
                this.name = name;
            } else
            {
                this.name = "No Name";
                Console.WriteLine("Name can't contain numbers");
            }
        }
        public string GetName()
        {
            return name;
        }*/
        public string Sound
        {

            get { return sound; }
            set
            {
                if (value.Length > 10)
                {
                    sound = "No Sound";
                    Console.WriteLine("Sound too long");
                }
                else
                {
                    sound = value;
                }
            }
        }

        public string Name
        {

            get { return name; }
            set
            {
                if (value.Any(char.IsDigit))
                {
                    sound = "No Name";
                    Console.WriteLine("Can't use numbers in name");
                }
                name = value;
            }
        }

        public class AnimalHealth
        {
            public bool HealthyWeight(double height, double weight)
            {
                double calc = height / weight;
                if ((calc >= .18) && (calc <= .27))
                {
                    return true;
                }
                else return false;
            }
        }

        //public string Owner { get; set; } = "No Owner";

        /*public static int NumOfAnimals
        {
            get { return numOfAnimals;}
            set { numOfAnimals += value; }
        }*/
    }
}
