using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace week7projectATM
{
    class Program
    {
        static void Main(string[] args)
        {
            ChCheckingAccount checkingaccountnumber = new ChCheckingAccount("29384729897");
            SavingsAccount savingsaccountnumber = new SavingsAccount("293987497");
            ReserveAccount reserveaccountnumber = new ReserveAccount("2992873497");

            bool exit = false;
            while (!exit) //sets up 'quit' option in menu
            {

                Console.WriteLine("Welcome to the ATM. \nType 1 for your checking account \nType 2 for your savings account \nType 3 for your reserve account \nType 4 to get balances and user info \nType 5 to exit");
                int userSelectionMain = int.Parse(Console.ReadLine());

                if (userSelectionMain == 1) //checking account method calls
                {
                    Console.WriteLine("CHECKING ACCOUNT \nPress 1 to deposit , press 2 for withdraw");
                    int userSelectionChecking = int.Parse(Console.ReadLine());

                    if (userSelectionChecking == 1)
                    {
                        ChCheckingAccount.DepositCheckingMoney();
                        ChCheckingAccount.UpdateCheckingBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (userSelectionChecking == 2)
                    {
                        ChCheckingAccount.WithdrawCheckingMoney();
                        ChCheckingAccount.UpdateCheckingBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }//end of checking

                else if (userSelectionMain == 2)//savings account method calls
                {
                    Console.WriteLine("SAVINGS ACCOUNT \nPress 1 to deposit , press 2 for withdraw");
                    int userSelectionSavings = int.Parse(Console.ReadLine());

                    if (userSelectionSavings == 1)
                    {
                        SavingsAccount.DepositSavingsMoney();
                        SavingsAccount.UpdateSavingsBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (userSelectionSavings == 2)
                    {
                        SavingsAccount.WithdrawSavingsMoney();
                        SavingsAccount.UpdateSavingsBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();
                    }
                }//end of savings

                else if (userSelectionMain == 3)//reserve method calls
                {
                    Console.WriteLine("RESERVE ACCOUNT \nPress 1 to deposit , press 2 for withdraw");
                    int userSelectionReserve = int.Parse(Console.ReadLine());

                    if (userSelectionReserve == 1)
                    {
                        ReserveAccount.DepositReserveMoney();
                        ReserveAccount.UpdateReserveBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();

                    }
                    else if (userSelectionReserve == 2)
                    {
                        ReserveAccount.WithdrawReserveMoney();
                        ReserveAccount.UpdateReserveBalance();
                        Console.WriteLine("Press enter to complete another transaction");
                        Console.ReadKey();
                        Console.Clear();
                    }
                } //end of reserve

                else if (userSelectionMain == 4) //print balances and user info
                {
                    ChCheckingAccount.UpdateCheckingBalance();
                    SavingsAccount.UpdateSavingsBalance();
                    ReserveAccount.UpdateReserveBalance();

                    DateTime timestamp = DateTime.Now;
                    Console.WriteLine(timestamp);
                }//end of print balances

                else if (userSelectionMain == 5) //exit ATM , print transactions
                {
                    DateTime timestamp = DateTime.Now;
                    Console.WriteLine(timestamp + " Today's transactions: \n");
                    Console.WriteLine(checkingaccountnumber);
                    ChCheckingAccount.PrintCheckingDeposits();

                    Console.WriteLine(savingsaccountnumber);
                    SavingsAccount.PrintSavingsDeposits();

                    Console.WriteLine(reserveaccountnumber);
                    ReserveAccount.PrintReserveDeposits();
                    

                    //exit
                    Console.WriteLine("$$$$$$$$$$$$$$$$$$");
                    Console.WriteLine("Press enter to print receipt");
                    Console.ReadKey();
                    break;
                }//end of exit and receipt




                }//end of menu while loop
                

            
        }//end of main
    }
}




