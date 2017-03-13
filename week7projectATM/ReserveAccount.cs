using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week7projectATM
{
  public class ReserveAccount : BaseATM
    {

        //fields
        public static double reserveAcctBalance;
        public static double depositReserveAmount;
        public static double withdrawReserveAmount;
        public static string line = string.Empty;

        static List<double> reserveDepositList = new List<double>();
        static List<double> reserveWithdrawList = new List<double>();

        //constructors
        public ReserveAccount(string accountNumber) : base(accountNumber)
        {

        }



        //methods

        //update balance
        public static void UpdateReserveBalance()
        {
            reserveAcctBalance = depositReserveAmount - withdrawReserveAmount;
            Console.WriteLine("Your savings account balance is " + reserveAcctBalance);

        }

        //read transactions from txt file for printing receipt in Main Class
        public static void PrintReserveDeposits()
        {
            List<string> reserveDepositList = new List<string>();
            StreamReader reserveDepositReader = new StreamReader("..\\..\\ReserveAccountDepositList.txt");
            using (reserveDepositReader)

                try
                {
                   
                    foreach (string line in File.ReadAllLines(@"..\\..\\ReserveAccountDepositList.txt"))
                    {
                        Console.WriteLine("Reserve deposits: " + line);
                    }
                }
                catch (FileNotFoundException ex)
                {
                    throw ex;
                }
                catch (Exception e)
                {
                    throw e;
                }

        }

        //DEPOSITS:

        //take in deposit info
        static public void DepositReserveMoney()
        {
            Console.WriteLine("How much would you like to deposit?");
            depositReserveAmount = double.Parse(Console.ReadLine());
            List<double> reserveDepositList = new List<double>();

            reserveDepositList.Add(depositReserveAmount);
            ReserveDeposittoList(); //write deposit amounts to txt file (called from method below)
        }

        //create stream and write reserve deposits to file
        static public void ReserveDeposittoList()
        {

            //Create an instance of StreamWriter and write to the file:
            StreamWriter reserveAccountDeposits = new StreamWriter("..\\..\\ReserveAccountDepositList.txt", true);
            using (reserveAccountDeposits)
            {
                foreach (double depositReserveAmount in reserveDepositList) ;
                reserveAccountDeposits.WriteLine(" + " + depositReserveAmount);
            }

        }





        public static void WithdrawReserveMoney()
        {
            Console.WriteLine("How much would you like to withdraw?");
            withdrawReserveAmount = double.Parse(Console.ReadLine());
            List<double> reserveWithdrawList = new List<double>();

            if (reserveAcctBalance <= 0)
            {
                Console.WriteLine("Please make a deposit to reserve account first!  You have insuffcient funds.");
            }
            else
            {
                reserveWithdrawList.Add(withdrawReserveAmount);
                ReserveWithdrawtoList(); //write withdraw amounts to txt file (called from method below)
            }

        }

        public static void ReserveWithdrawtoList() //create stream and write checking withdraws to file
        {

            //Create an instance of StreamWriter and write to the file:
            StreamWriter reserveAccountWithdraws = new StreamWriter("..\\..\\ReserveAccountWithdrawList.txt", true);
            using (reserveAccountWithdraws)
            {
                foreach (double withdrawReserveAmount in reserveWithdrawList) ;
                reserveAccountWithdraws.WriteLine(" - " + withdrawReserveAmount);
            }

        }

    
}//end of Reserve Account
}
