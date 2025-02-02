using System;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Text;
using ConsoleApp11;
using static System.Net.Mime.MediaTypeNames;
using System.Collections;
using System.Collections.Generic;

namespace ConsoleApp11
{
    public class Program11
    {
        //Functions

        static void CountTo(int maxNum)
        {
            for (int i = 0; i <= maxNum; i++)
            {
                Console.WriteLine(i);
            }
        }

        static void Print1()
        {
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(1);
            }
        }

        static void Main(string[] args) // shows the threads share resources as not all 1s and 0s printed in order
        {
            Thread t = new Thread(Print1);
            t.Start();
            for (int i = 0; i < 1000; i++)
            {
                Console.Write(0);
            }

            int num = 1;
            for (int i = 0; i < 10; i++)
            {
                Console.Write(num);
                //Thread.Sleep(1000);
                num++;
            }
            Console.WriteLine("Thread Ends");

            //bank fiddling
            BankAcct11 acct = new BankAcct11(10);
            Thread[] threads = new Thread[15];

            Thread.CurrentThread.Name = "main"; //current executing thread

            for (int i = 0; i < 15; i ++)
            {
                Thread p = new Thread(new ThreadStart(acct.IssueWithdraw));
                p.Name = i.ToString();
                threads[i] = p;
            }

            for (int i = 0; i < 15; i++)
            {
                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);
                threads[i].Start();
                Console.WriteLine("Thread {0} Alive : {1}", threads[i].Name, threads[i].IsAlive);
            }
            Console.WriteLine("Current Priority : {0}",Thread.CurrentThread.Priority);
            Console.WriteLine("Thread {0} Ending : {1}", Thread.CurrentThread.Name);

            //number max fiddling
            Thread o = new Thread(() => CountTo(10));
            o.Start();

            new Thread(() =>
            {
                CountTo(5);
                CountTo(6);
            }).Start();
        }
    }
}