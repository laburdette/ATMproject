using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week7projectATM
{
    public class SavingsAccount : BaseATM
    {
        
       
            //fields
            public static double savingsAcctBalance;
            public static double depositSavingsAmount;
            public static double withdrawSavingsAmount;
            public static string line = string.Empty;

            static List<double> savingsDepositList = new List<double>();
            static List<double> savingsWithdrawList = new List<double>();

        //constructors
        public SavingsAccount(string accountNumber) : base(accountNumber)
        {

        }



        //methods

        //update balance
        public static void UpdateSavingsBalance()
            {
                savingsAcctBalance = depositSavingsAmount - withdrawSavingsAmount;
                Console.WriteLine("Your savings account balance is " + savingsAcctBalance);

            }

            //read transactions from txt file for printing receipt in Main Class
            public static void PrintSavingsDeposits()
            {
                List<string> savingsDepositList = new List<string>();
                StreamReader savingsDepositReader = new StreamReader("..\\..\\SavingsAccountDepositList.txt");
                using (savingsDepositReader)

                    try
                    {
                        
                        foreach (string line in File.ReadAllLines(@"..\\..\\SavingsAccountDepositList.txt"))
                        {
                            Console.WriteLine("Savings deposits: " + line);
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
            static public void DepositSavingsMoney()
            {
                Console.WriteLine("How much would you like to deposit?");
                depositSavingsAmount = double.Parse(Console.ReadLine());
                List<double> checkingSavingsList = new List<double>();

                checkingSavingsList.Add(depositSavingsAmount);
                SavingsDeposittoList(); //write deposit amounts to txt file (called from method below)
            }

            //create stream and write savings deposits to file
            static public void SavingsDeposittoList()
            {

                //Create an instance of StreamWriter and write to the file:
                StreamWriter savingsAccountDeposits = new StreamWriter("..\\..\\SavingsAccountDepositList.txt", true);
                using (savingsAccountDeposits)
                {
                    foreach (double depositSavingsAmount in savingsDepositList) ;
                    savingsAccountDeposits.WriteLine(" + " + depositSavingsAmount);
                }

            }





            public static void WithdrawSavingsMoney()
            {
                Console.WriteLine("How much would you like to withdraw?");
                withdrawSavingsAmount = double.Parse(Console.ReadLine());
                List<double> savingsWithdrawList = new List<double>();

                if (savingsAcctBalance <= 0)
                {
                    Console.WriteLine("Please make a deposit to savings first!  You have insuffcient funds.");
                }
                else
                {
                    savingsWithdrawList.Add(withdrawSavingsAmount);
                    SavingsWithdrawtoList(); //write withdraw amounts to txt file (called from method below)
                }

            }

            public static void SavingsWithdrawtoList() //create stream and write checking withdraws to file
            {

                //Create an instance of StreamWriter and write to the file:
                StreamWriter savingsAccountWithdraws = new StreamWriter("..\\..\\SavingsAccountWithdrawList.txt", true);
                using (savingsAccountWithdraws)
                {
                    foreach (double withdrawSavingsAmount in savingsWithdrawList) ;
                    savingsAccountWithdraws.WriteLine(" - " + withdrawSavingsAmount);
                }

            }
            
        

        

    }//end of SavingsAccount
}
