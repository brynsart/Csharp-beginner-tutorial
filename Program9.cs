using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp9;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Diagnostics;
using System.Xml.Linq;

namespace ConsoleApp9
{
    public class Program9
    {
        //Functions

        delegate double doubleIt(double val);

        static void Main(string[] args)
        {
            //lambdas and delegates
            //lambda expression assigned to delegate
            doubleIt dblIt = x => x * 2;
            Console.WriteLine($"5 * 2 = {dblIt(5)}");

            List<int> numList = new List<int> { 1, 9, 2, 6, 3 };
            var evenList = numList.Where(a => a % 2 == 0).ToList();
            foreach (var v in evenList) Console.WriteLine(v);

            var rangeList = numList.Where(x => (x > 2) || (x < 9)).ToList();
            foreach (var v in rangeList) Console.WriteLine(v);

            List<int> flipList = new List<int>();
            int i = 0;
            Random rnd = new Random();
            while (i < 100)
            {
                flipList.Add(rnd.Next(1, 3));
                i++;
            }
            Console.WriteLine("Heads : {0}", flipList.Where(a => a == 1).ToList().Count());
            Console.WriteLine("Tails : {0}", flipList.Where(a => a == 2).ToList().Count());

            var nameList = new List<string> {"Doug", "Sally", "Sue"};
            var sNameList = nameList.Where(x => x.StartsWith("S"));
            foreach (var l in sNameList) Console.WriteLine(l);

            //range
            var oneTo10 = new List<int>();
            oneTo10.AddRange(Enumerable.Range(1, 10));
            var squares = oneTo10.Select(x => x * x); // select like a lambda function where but changes something
            foreach (var g in squares) Console.WriteLine(g);

            //zip adds both lists (combines) together each index
            var listOne = new List<int>(new int[] { 1, 3, 4 });
            var listTwo = new List<int>(new int[] { 4, 6, 8 });
            var sumList = listOne.Zip(listTwo, (x, y) => x + y).ToList();
            foreach (var h in sumList) Console.WriteLine(h);

            var numList2 = new List<int>() { 1, 2, 3, 4, 5 };
            Console.WriteLine("Avg {0}", numList2.AsQueryable().Average());
            Console.WriteLine("Sum {0}", numList2.Aggregate((a, b) => a + b)); //an aggregate performs the operation on each item in the list and carry it forward
            Console.WriteLine("All > 3 {0}", numList2.All(x => x > 3));
            Console.WriteLine("Any > 3 {0}", numList2.Any(x => x > 3));
            var numList3 = new List<int>() { 1, 2, 3, 2, 3 };
            Console.WriteLine("Distinct : {0}", string.Join(",", numList3.Distinct())); // only shows distinct values once
            var numList4 = new List<int>() { 3 };
            Console.WriteLine("Except : {0}", string.Join(",", numList3.Except(numList4)));
            Console.WriteLine("Intersect : {0}", string.Join(",", numList3.Intersect(numList4)));

            AnimalFarm9 myAnimals = new AnimalFarm9();
            myAnimals[0] = new Animal9("Wilbur");
            myAnimals[1] = new Animal9("Templeton");
            myAnimals[2] = new Animal9("Gander");
            myAnimals[3] = new Animal9("Charlotte");
            foreach (Animal9 p in myAnimals)
            {
                Console.WriteLine(p.Name);
            }

            Box9 box1 = new Box9(2, 3, 4);

            Box9 box2 = new Box9(5, 6, 7);

            Box9 box3 = box1 + box2;
            Console.WriteLine($"Box 3 : {box3}");
            Console.WriteLine($"Box Int : {(int)box3}");
            Box9 box4 = (Box9)4;
            Console.WriteLine($"Box 4 : {box4}");

            var shopkins = new { Name = "Shopkins", Price = 4.99 }; //anonymous type
            Console.WriteLine("{0} costs ${1}", shopkins.Name, shopkins.Price);

            var toyArray = new[] { new { //creating an array using same method as previous
                Name = "Yo-Kai pack", Price = 3.99 },
                new {Name = "Lego", Price = 9.99 } };
            foreach (var item in toyArray)
            {
                Console.WriteLine("{0} costs ${1}", item.Name, item.Price);
            }
        }
    }
}