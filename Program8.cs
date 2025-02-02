using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp8;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp8
{
    public class Program8
    {
        //Functions
        

        static void Main(string[] args)
        {
            #region ArrayList Code
            //array lists
            ArrayList aList = new ArrayList();

            aList.Add("Bob");
            aList.Add(40);

            Console.WriteLine("Count : {0}", aList.Count);
            Console.WriteLine("Capacity : {0}", aList.Capacity);

            ArrayList aList2 = new ArrayList();
            aList2.AddRange(new object[] { "Mike", "Sally", "Egg" });

            aList.AddRange(aList2);
            aList2.Sort();
            //arrayprinter(aList2);
            aList2.Reverse();
            Console.WriteLine(aList2);

            aList.Insert(1, "Turkey");
            aList2.RemoveAt(0);
            aList2.RemoveRange(0, 2);
            Console.WriteLine("Turkey Index : {0}", aList.IndexOf("Turkey", 0));

            foreach(object o in aList) 
            {
                Console.WriteLine(o);
            }

            /*string[] myArray = (string[])aList.ToArray(typeof(string));

            string[] customers = { "Bob", "Sally", "Mike", "Sue" };
            ArrayList custArrayList = new ArrayList();
            custArrayList.AddRange(customers);
*/
            #endregion

            #region Dictionaries
            Console.WriteLine("----------");
            //dictionaries
            Dictionary<string, string> superheroes = new Dictionary<string, string>();
            superheroes.Add("Clark Kent", "Superman");
            superheroes.Add("Bruce Wayne", "Property Reviewer");
            superheroes.Add("Barry Allen", "The Flash");

            superheroes.Remove("Barry Allen");

            Console.WriteLine("Count : {0}", superheroes.Count);
            Console.WriteLine("Clark Kent : {0}", superheroes.ContainsKey("Clark Kent"));

            superheroes.TryGetValue("Clark Kent", out string test);
            Console.WriteLine($"Clark Kent : {test}");

            foreach (KeyValuePair<string,string> pair in superheroes)
            {
                Console.WriteLine("{0} : {1}",pair.Key,pair.Value);
            }
            superheroes.Clear();

            #endregion

            #region Queues
            Console.WriteLine("------------");
            Queue queue = new Queue();
            queue.Enqueue(1);
            queue.Enqueue(2);
            queue.Enqueue(3);
            Console.WriteLine("1 in Queue : {0}", queue.Contains(1));
            Console.WriteLine("Remove : {0}", queue.Dequeue());
            Console.WriteLine("Peek 1 : {0}", queue.Peek());

            object[] numArray = queue.ToArray();
            Console.WriteLine(String.Join(",", numArray));
            foreach (object o in queue)
            {
                Console.WriteLine($"Queue : {o}");
            }
            queue.Clear();
            #endregion
            //queue is first in first out, stack is last in first out
            #region Stacks
            Console.WriteLine("----------");
            Stack stack = new Stack();
            stack.Push(1);
            stack.Push(2);
            stack.Push(3);

            Console.WriteLine("Peek 1 : {0}", stack.Peek());
            Console.WriteLine("Pop 1 : {0}", stack.Pop());
            Console.WriteLine("Contain 1 : {0}", stack.Contains(1));
            object[] numArray2 = stack.ToArray();
            Console.WriteLine(String.Join(",",numArray2));

            foreach (object o in stack)
            {
                Console.WriteLine($"Stack : {o}");
            }

            #endregion

            #region Generics
            Console.WriteLine("----------");

            List<Animal8> animalList = new List<Animal8>(); //creation of list using animal class, generic list type <animal>

            List<int> numList = new List<int>();
            numList.Add(24); // standard type <int>

            animalList.Add(new Animal8() { Name = "Doug" });
            animalList.Add(new Animal8() { Name = "Paul" });
            animalList.Add(new Animal8() { Name = "Sally" });

            animalList.Insert(1, new Animal8() { Name = "Steve" }); //insert at a specific index (1)

            animalList.RemoveAt(1);
            Console.WriteLine("Num of Animals : {0}", animalList.Count());
            foreach (Animal8 a in animalList)
            {
                Console.WriteLine(a.Name);
            }

            int x = 5, y = 4;
            Animal8.GetSum<int>(ref x, ref y);
            string strx = "5", stry = "4";
            Animal8.GetSum<string>(ref strx, ref stry); //both will work due to use of generic
            //define type of <T>
            Rectangle<int> rec1 = new Rectangle<int>(20,50);
            Console.WriteLine(rec1.GetArea());

            Rectangle<string> rec2 = new Rectangle<string>("20", "50");
            Console.WriteLine(rec2.GetArea());
            #endregion

            #region Delegates
            Console.WriteLine("----------");

            Arithmetic add, sub, addSub;
            add = new Arithmetic(Add);
            sub = new Arithmetic(Subtract);
            addSub = add + sub;

            Console.WriteLine($"Add {6} & {10}");
            add(6, 10);
            Console.WriteLine($"Add & Subtract {10} & {4}");
            addSub(10, 4);
            #endregion
        }

        //defining struct , generic struct
        public struct Rectangle<T>
        {
            private T width;
            private T length;
            public T Width
            {
                get { return width; }
                set { width = value; }
            }
            public T Length
            {
                get { return length; }
                set { length = value; }
            }
            public Rectangle(T w, T l) // generic constructor
            {
                width = w;
                length = l;
            }
            public string GetArea()
            {
                double dblWidth = Convert.ToDouble(Width);
                double dblLength = Convert.ToDouble(Length);
                return string.Format($"{Width} * {Length} = {dblWidth * dblLength}");
            }
        }

        public delegate void Arithmetic(double num1, double num2);

        public static void Add(double num1, double num2)
        {
            Console.WriteLine($"{num1} + {num2} = {num1 + num2}");
        }
        public static void Subtract(double num1, double num2)
        {
            Console.WriteLine($"{num1} - {num2} = {num1 - num2}");
        }
    }
}