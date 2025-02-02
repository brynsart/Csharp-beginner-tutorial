using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp10;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp10
{
    public class Program10
    {
        //Functions
        static int[] QueryIntArray() //has to return a int array
        {
            int[] nums = {5,10,15,20,25,30,35};

            var gt20 = from num in nums
                       where num > 20
                       orderby num
                       select num;
            foreach(int num in gt20)
            {
                Console.WriteLine(num);
            } 
            Console.WriteLine($"Get Type : {gt20.GetType()}");
            var listGT20 = gt20.ToList<int>();
            var arrayGT20 = gt20.ToArray();

            nums[0] = 40;
            foreach (int num in gt20)
            {
                Console.WriteLine(num);
            }
            return arrayGT20;
        }


        static void Main(string[] args)
        {

            // Language Integrated Query (LINQ)
            string[] dogs = { "K 9", "B Griff", "Scooby Doo", "Old Yeller", "Rin Tin Tin", "Benji", "Charlie B. Barkin", "Lassie", "Pluto" };
            var dogSpaces = from dog in dogs //similar to sql
                            where dog.Contains(" ") 
                            orderby dog descending
                            select dog;//all dogs with spaces in their name
            //each single dog == dog
            foreach (var i in dogSpaces)
            {
                Console.WriteLine(i);
            }

            int[] intArray = QueryIntArray();

            ArrayList famAnimals = new ArrayList()
            {
                new Animal10 {Name = "Heidi", Height = .8, Weight = 18},
                new Animal10 {Name = "Shrek", Height = 4, Weight = 130},
                new Animal10 {Name = "Congo", Height = 3.8, Weight = 90}
            };

            Animal10[] animals = new[]
            {
                new Animal10 {Name = "German Shepherd", Height = 25, Weight = 77, AnimalID = 1},
                new Animal10 {Name = "Chihuahua", Height = 7, Weight = 4.4, AnimalID = 2},
                new Animal10 {Name = "Saint Bernard", Height = 30, Weight = 200, AnimalID = 3},
                new Animal10 {Name = "Pug", Height = 12, Weight = 6, AnimalID = 1},
                new Animal10 {Name = "Beagle", Height = 15, Weight = 23, AnimalID = 2}
            };

            Owner10[] owners = new[]
            {
                new Owner10{Name = "Doug Parks", OwnerID = 1},
                new Owner10{Name = "Sally Smith", OwnerID = 2},
                new Owner10{Name = "Paul Brooks", OwnerID = 3},
            };
            var nameHeight = from a in animals
                             select new
                             {
                                 a.Name,
                                 a.Height
                             };
            Array arrNameHeight = nameHeight.ToArray();

            var innerjoin = from animal in animals
                            join owner in owners on animal.AnimalID
                            equals owner.OwnerID
                            select new { OwnerName = owner.Name, AnimalName = animal.Name };

            //all animals in a new owner group if id matches
            var groupJoin = from owner in owners
                            orderby owner.OwnerID
                            join animal in animals on owner.OwnerID equals animal.AnimalID into ownerGroup
                            select new
                            {
                                Owner = owner.Name,
                                Animals = from owner2 in ownerGroup
                                          orderby owner2.Name
                                          select owner2
                            };

            int totalAnimals = 0;

            Console.WriteLine();
            foreach (var ownerGroup in groupJoin)
            {
                Console.WriteLine(ownerGroup.Owner);
                foreach (var animal in ownerGroup.Animals)
                {
                    totalAnimals++;
                    Console.WriteLine("* {0}",animal.Name);
                }
            }

            foreach (var i in innerjoin)
            {
                Console.WriteLine("{0} owns {1}",i.OwnerName,i.AnimalName);
            }

            foreach (var i in arrNameHeight)
            {
                Console.WriteLine(i.ToString());
            }


            var animalListEnum = animals.OfType<Animal10>();

            var bigDogs = from dog in animalListEnum
                          where (dog.Weight > 70) && (dog.Height > 25)
                          orderby dog.Name
                          select dog;
            foreach (var animal in bigDogs)
            {
                Console.WriteLine("{0} weighs {1} kg and is {2} cm tall", animal.Name, animal.Weight, animal.Height);
            }

            var famAnimalEnum = famAnimals.OfType<Animal10>();
            //creates an enumerated array of the animals
            var smAnimals = from animal in famAnimalEnum
                            where animal.Weight <= 90
                            orderby animal.Name
                            select animal;
            foreach (var animal in smAnimals)
            {
                Console.WriteLine("{0} weighs {1} kg",animal.Name, animal.Weight);
            }
        }
    }
}