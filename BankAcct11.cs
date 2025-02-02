using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp11
{
    class BankAcct11
    {
        private Object acctLock = new object();
        double Balance { get; set; }
        string Name { get; set; }
        public BankAcct11 (double bal)
        {
            Balance = bal;
        }

        public double Withdraw(double amt)
        {
            if ((Balance - amt) < 0)
            {
                Console.WriteLine($"Sorry ${Balance} in Account in Account");
                return Balance;
            }

            lock (acctLock)
            {
                if (Balance >= amt)
                {
                    Console.WriteLine ("Removed {0} and {1} left in account",amt,(Balance - amt));
                    Balance -= amt;
                }
                return Balance;
            }
        }
        public void IssueWithdraw()
        {
            Withdraw(1);
        }
    }
}