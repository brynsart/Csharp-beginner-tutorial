using System;

namespace ConsoleApp1
{
    public class Program1
    {

        // -------- FUNCTIONS ---------

        static void PrintArray(int[] intArray, string mess)
        {
            foreach (int k in intArray)
            {
                Console.WriteLine("{0} : {1}", mess, k);
            }
        }

        // ________ END OF FUNCTIONS ________

        static void Main(string[] args)
        {
            //casting/conversion (Implicit/Explicit)
            bool boolFromStr = bool.Parse("true");
            int intFromStr = int.Parse("100");
            double dblFromStr = double.Parse("1.234");
            string strVal = dblFromStr.ToString();
            Console.WriteLine($"Data type : {strVal.GetType()}");
            double dblNum = 12.345;
            Console.WriteLine($"Integer : {(int)dblNum}");
            int intNum = 10;
            long longNum = intNum;

            //comparing data types
            Console.WriteLine("Biggest Integer: {0}", int.MaxValue);
            Console.WriteLine("Smallest Integer: {0}", int.MinValue);

            Console.WriteLine("Biggest Long: {0}", long.MaxValue);
            Console.WriteLine("Smallest Long: {0}", long.MinValue);

            decimal decPiVal = 3.141592658543897783945M;
            decimal decBigNum = 3.0000000000000000000000000000011M;
            Console.WriteLine("DEC : PI + bigNum = {0}", decPiVal + decBigNum);

            Console.WriteLine("Biggest Decimal : {0}", Decimal.MaxValue);
            Console.WriteLine("Biggest Double : {0}", Double.MaxValue);

            //formatting
            Console.WriteLine("Currency : {0:c}", 23.455);
            Console.WriteLine("Pad with 0s : {0:d4}", 23);
            Console.WriteLine("3 dp : {0:f3}", 23.45555);
            Console.WriteLine("Commas : {0:n4}", 2300);

            //string functions
            string randString = "This is a string";
            Console.WriteLine("String Length : {0}", randString.Length);
            Console.WriteLine("String Contains is : {0}", randString.Contains("is"));
            Console.WriteLine("String Index of is : {0}", randString.IndexOf("is"));
            Console.WriteLine("Remove String : {0}", randString.Remove(10, 6));
            Console.WriteLine("Insert String : {0}", randString.Insert(10, "Short "));
            Console.WriteLine("Replace String : {0}", randString.Replace("string", "sentence"));
            Console.WriteLine("Compare A to B : {0}", String.Compare("A", "B", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("----------------------");
            Console.WriteLine("A = a : {0}", String.Equals("A", "a", StringComparison.OrdinalIgnoreCase));
            Console.WriteLine("Pad Left : {0}", randString.PadLeft(20, '.'));
            Console.WriteLine("Pad Left : {0}", randString.PadRight(20, '.'));
            Console.WriteLine("Trim : {0}", randString.Trim());
            Console.WriteLine("Uppercase : {0}", randString.ToUpper());
            string newString = String.Format("{0} saw a {1} {2} in the {3}", "paul", "rabbit", "eating", "field");
            Console.Write(newString + "\n");
            //comment \' \" \\ \t \a \n
            Console.WriteLine(@"Exactly what I typed\n");

            //arrays + loops
            int[] arrNums = new int[3];
            arrNums[0] = 23;
            string[] customers = { "Bob", "Michael", "Sally" };
            var employees = new[] { "Mike", "Paul", "Rick" };
            object[] randomArray = { "Paul", 45, 1.234 };
            Console.WriteLine("randomArray 0 : {0}", randomArray[0].GetType());
            Console.WriteLine("Array Size : {0}", randomArray.Length);
            for (int i = 0; i < randomArray.Length; i++)
            {
                Console.WriteLine("randomArray : {0}: {1}", i, randomArray[i]);
            }

            Console.WriteLine("-------------");
            string[,] customerNames = new string[2, 2] { { "Bob", "Smith" }, { "Sally", "Smith" } };
            Console.WriteLine("MD Value : {0}", customerNames.GetValue(1, 0));
            for (int j = 0; j < customerNames.GetLength(0); j++)
            {
                for (int k = 0; k < customerNames.GetLength(1); k++)
                {
                    Console.WriteLine("{0} ", customerNames[j, k]);
                }
                Console.WriteLine();
            }
            int[] randNums = { 1, 4, 9, 2 };
            PrintArray(randNums, "ForEach");

            //Array functions
            Array.Sort(randNums);
            Array.Reverse(randNums);
            foreach (int i in randNums)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine("1 at index : {0}", Array.IndexOf(randNums, 1));
            randNums.SetValue(0, 1);
            int[] srcArray = { 1, 2, 3 };
            int[] destArray = new int[2];
            int startInd = 0;
            int length = 2;
            Array.Copy(srcArray, startInd, destArray, 0, length);
            PrintArray(destArray, "Copy");
            Array anotherArray = Array.CreateInstance(typeof(int), 10);
            srcArray.CopyTo(anotherArray, 5);
            foreach (int m in anotherArray)
            {
                Console.WriteLine("CopyTo : {0}", m);
            }


        }
    }
}