using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week7projectATM
{
    public class ChCheckingAccount : BaseATM
    {
        //fields
        

        public static double checkingAcctBalance;
        public static double depositCheckingAmount;
        public static double withdrawCheckingAmount;
        public static string line = string.Empty;

        static List<double> checkingDepositList = new List<double>();
        static List<double> checkingWithdrawList = new List<double>();

        //constructors
         public ChCheckingAccount (string accountNumber) : base(accountNumber)
        {
           
        }
        



        //methods

        //update balance
        public static void UpdateCheckingBalance()
        {
            checkingAcctBalance = depositCheckingAmount - withdrawCheckingAmount;
            Console.WriteLine("Your checking account balance is " + checkingAcctBalance);

        }

        //read transactions from txt file for printing receipt
        public static void PrintCheckingDeposits()
        {
            List<string> checkingDepositList = new List<string>();
            StreamReader checkingDepositReader = new StreamReader("..\\..\\CheckingAccountDepositList.txt");
            using (checkingDepositReader)

                try
                {
                    // string []  = File.ReadAllLines(@"..\\..\\CheckingAccountDepositList.txt");
                    foreach (string line in File.ReadAllLines(@"..\\..\\CheckingAccountDepositList.txt"))
                    {
                        Console.WriteLine("Checking deposits: " + line);
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
        static public void DepositCheckingMoney()
        {
            Console.WriteLine("How much would you like to deposit?");
            depositCheckingAmount = double.Parse(Console.ReadLine());
            List<double> checkingDepositList = new List<double>();

            checkingDepositList.Add(depositCheckingAmount);
            CheckingDeposittoList(); //write deposit amounts to txt file (called from method below)
        }

        //create stream and write checking deposits to file
        static public void CheckingDeposittoList() 
        {

            //Create an instance of StreamWriter and write to the file:
            StreamWriter checkingAccountDeposits = new StreamWriter("..\\..\\CheckingAccountDepositList.txt", true);
            using (checkingAccountDeposits)
            {
                foreach (double depositCheckingAmount in checkingDepositList) ;
                checkingAccountDeposits.WriteLine(" + " + depositCheckingAmount);
            }

        }

       
        


        public static void WithdrawCheckingMoney()
        {
            Console.WriteLine("How much would you like to withdraw?");
            withdrawCheckingAmount = double.Parse(Console.ReadLine());
            List<double> checkingWithdrawList = new List<double>();

            if (checkingAcctBalance <= 0)
            {
                Console.WriteLine("Please make a deposit to checking first!  You have insuffcient funds.");
            }
            else
            {
                checkingWithdrawList.Add(withdrawCheckingAmount);
                CheckingWithdrawtoList(); //write withdraw amounts to txt file (called from method below)
            }
           
        }

        public static void CheckingWithdrawtoList() //create stream and write checking withdraws to file
        {

            //Create an instance of StreamWriter and write to the file:
            StreamWriter checkingAccountWithdraws = new StreamWriter("..\\..\\CheckingAccountWithdrawList.txt", true);
            using (checkingAccountWithdraws)
            {
                foreach (double withdrawCheckingAmount in checkingWithdrawList) ;
                checkingAccountWithdraws.WriteLine(" - " + withdrawCheckingAmount);
            }

        }





    }//end of Checking Account
}

