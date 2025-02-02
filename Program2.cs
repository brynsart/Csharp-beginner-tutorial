using System;
using System.Globalization;
using System.Text;

namespace ConsoleApp1
{
    public class Program2
    {

        // -------- FUNCTIONS ---------
        //<Access Specifier> <Return Type> <Method Name> (Parameters)
        //{ <Body> }
        //Access Specifier determines whether the function can be called from another class

        private static void SayHello()
        {
            string inputname = "";
            Console.Write("What is your name : ");
            inputname = Console.ReadLine();
            Console.WriteLine("Hello {0}", inputname);
        }

        static double DoDivision(double x, double y)
        {
            if (y == 0)
            {
                throw new System.DivideByZeroException();
            }
            return x / y;
        }

        static double GetSum(double x = 1, double y = 1)
        {
            return x + y;
        }
        static void DoubleIt(int x, out int solution)
        {
            solution = x * 2;
        }
        public static void Swap(ref int num45, ref int num46)
        {
            int temp = num45;
            num45 = num46;
            num46 = temp;
        }
        static double GetSumMore(params double[] nums)
        {
            double sum = 0;
            foreach (int i in nums)
            {
                sum += i;
            }
            return sum;
        }
        static void PrintInfo(string name, int zipCode)
        {
            Console.WriteLine("{0} lives in the zip code {1}", name, zipCode);
        }

        static double GetSum2(double x = 1, double y = 1)
        {
            return x + y;
        }
        static double GetSum2(string x = "1", string y = "1")
        {
            double dblX = Convert.ToDouble(x);
            double dblY = Convert.ToDouble(y);
            return dblX + dblY;
        }
        static void PaintCar(CarColor cc) //abreviated
        {
            Console.WriteLine("The car was painted {0} with the code {1}",
                cc, (int)cc);
        }
        enum CarColor : byte //enumerated type
        {
            Orange = 1,
            Blue,
            Green,
            Red,
            Yellow,
        }
        // ________ END OF FUNCTIONS ________

        static void Main(string[] args)
        {
            //ifs else ifs elses switches
            // relational operators > < >= <= == !=
            // logical operators && || !
            int age = 17;
            if ((age >= 5) && (age <= 7))
            {
                Console.WriteLine("elementary school");
            }
            else if ((age > 7) && (age < 13))
            {
                Console.WriteLine("middle school");
            }
            else if ((age > 13) && (age < 19))
            {
                Console.WriteLine("high school");
            }
            else { Console.WriteLine("college"); }

            if ((age < 14) || (age > 67))
            {
                Console.WriteLine("no work");
            }
            Console.WriteLine("! true = " + (!true));

            bool canDrive = age >= 16 ? true : false; // when age >= 16 assign true , else false

            switch (age)
            {
                case 1: //in case age == 1 or 2

                case 2:
                    Console.WriteLine("go to day care");
                    break;
                case 3:
                case 4:
                    Console.WriteLine("go to preschool");
                    break;
                case 5:
                    Console.WriteLine("go to elementary school");
                    break;
                default:
                    Console.WriteLine("go to another school");
                    goto OtherSchool;
            }

        OtherSchool:
            Console.WriteLine("Elementary,Middle,High School");

            string name2 = "Dave";
            string name3 = "Dave";
            if (name2.Equals(name3, StringComparison.Ordinal)) //name2 == name3
            {
                Console.WriteLine("hello daves");
            }
            else { Console.WriteLine("no dave"); }

            //whiles

            int i = 1;
            while (i <= 10)
            {
                if (i % 2 == 0)
                {
                    i++;
                    continue;
                }
                if (i == 9) break;
                Console.WriteLine(i);
                i++;
            }

            Random rnd = new Random();
            int secretNum = rnd.Next(1, 11); //not including 11
            int numGuessed = 0;
            //Console.WriteLine("Random Num : {0}", secretNum);

            do
            {
                Console.WriteLine("Enter a number between 1 & 10");
                numGuessed = Convert.ToInt32(Console.ReadLine());

            } while (secretNum != numGuessed);

            Console.WriteLine("Good guess it was {0}", secretNum);

            double num1 = 5;
            double num2 = 0;
            //error checks
            try
            {
                Console.WriteLine("5/0 = {0}",
                    DoDivision(num1, num2)); //DoDivision is a function
            }

            catch (DivideByZeroException ex)
            {
                Console.WriteLine("You cant divide by zero");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            catch (Exception ex)
            {
                Console.WriteLine("An error occured");
                Console.WriteLine(ex.GetType().Name);
                Console.WriteLine(ex.Message);
            }

            finally
            {
                Console.WriteLine("Cleaning Up");
            }

            //string builders stores a string then changes it in memory rather than creating a copy
            //same/similar processes can be used to alter / extract data from the string (builder)
            StringBuilder sb = new StringBuilder("Random Text");
            StringBuilder sb2 = new StringBuilder("More other things that are to be considered as important", 256);
            Console.WriteLine("Capacity : {0}", sb2.Capacity);
            Console.WriteLine("Length : {0}", sb2.Length);
            sb2.AppendLine("\nMore important text");
            CultureInfo enUS = CultureInfo.CreateSpecificCulture("en-US");
            string bestCust = "Jerry Smith";
            sb2.AppendFormat(enUS, "Best Customer : {0}", bestCust);
            Console.WriteLine(sb2.ToString());
            sb2.Replace("text", "characters");
            Console.WriteLine(sb2.ToString());
            sb2.Clear();
            sb2.Append("Random Text");
            Console.WriteLine(sb.Equals(sb2));
            sb2.Insert(11, " that's great");
            Console.WriteLine(sb2.ToString());
            sb2.Remove(11, 7);
            Console.WriteLine(sb2.ToString());

            //functions properly
            SayHello();

            double x = 5;
            double y = 4;
            Console.WriteLine("5 + 4 = {0}", GetSum(x, y));

            int solution;
            DoubleIt(15, out solution);
            Console.WriteLine("15 * 2 = {0}", solution);

            int num45 = 10;
            int num46 = 20;
            Console.WriteLine("Before Swap num 1 : {0} num 2 : {1}", num45, num46);
            Swap(ref num45, ref num46);
            Console.WriteLine("After Swap num 1 : {0} num 2 : {1}", num45, num46);

            Console.WriteLine("1+2+3 = {0}", GetSumMore(1, 2, 3));
            PrintInfo(zipCode: 15147, name: "Dave Smith");

            Console.WriteLine("5.0 + 4.5 = {0}", GetSum2(5.0, 4.5));
            Console.WriteLine("5.0 + 4.5 = {0}", GetSum2("5.0", "4.5")); //both work as method overloaded

            DateTime nowDate = new DateTime(1945, 12, 21);
            Console.WriteLine("Day of the week : {0}", nowDate.DayOfWeek);
            Console.WriteLine("Date : {0}", nowDate.ToString());
            nowDate = nowDate.AddDays(4);
            nowDate = nowDate.AddMonths(2);
            nowDate = nowDate.AddYears(3);
            Console.WriteLine("new date : {0}", nowDate.ToString());
            TimeSpan lunchTime = new TimeSpan(12, 30, 0);
            lunchTime = lunchTime.Subtract(new TimeSpan(0, 15, 0));
            Console.WriteLine("new time : {0}", lunchTime.ToString());

            CarColor car1 = CarColor.Blue;
            PaintCar(car1);
        }
    }
}