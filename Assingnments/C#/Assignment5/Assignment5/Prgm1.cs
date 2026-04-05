using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class Prgm1
{
    class InsufficientBalanceException : ApplicationException
    {
        public InsufficientBalanceException(string message) : base(message) { }
    }

    public static void bank()
    {
        try
        {
            double bal;

            Console.Write("Enter Initial Balance: ");
            bal = Convert.ToDouble(Console.ReadLine());

            Console.Write("Enter Amount to Deposit : ");
            double dep = Convert.ToDouble(Console.ReadLine());

            bal = bal + dep;

            Console.WriteLine("Balance after the deposit: " + bal);

            Console.Write("Enter Amount to Withdrawal: ");
            double withdraw = Convert.ToDouble(Console.ReadLine());

            if (withdraw <= bal)
            {
                bal = bal - withdraw;
                Console.WriteLine("Final Balance: " + bal);
            }
            else
            {
                throw new InsufficientBalanceException("Not enough balance");
            }
        }
        catch (InsufficientBalanceException e)
        {
            Console.WriteLine(e.Message);
        }
        catch
        {
            Console.WriteLine("Invalid input");
        }
        Console.WriteLine("-------------");
    }
}

