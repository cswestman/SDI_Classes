using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westman_Christopher_CustomClass
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Christopher Westman
             * 12/13/2017
             * Week 4, Bank Account Class
             */ 
            // Declare variables for storing input for both validation and to place in BankAccount object
            string userName;
            double dou_userName;
            string s_bankingAccount;
            string s_checkingAccount;
            decimal bankingAccount;
            decimal checkingAccount;
            
            // Prompt user for name, store input, then validate 
            Console.WriteLine("Welcome to Future Bank! Please let us know your full name so can put it on your account.\r\nLetters only please.");
            // Store input
            userName = Console.ReadLine();
            // Validate
            while (string.IsNullOrWhiteSpace(userName) || double.TryParse(userName, out dou_userName))
            {
                Console.WriteLine("\r\nPlease type in a valid entry or do not leave blank.");

                userName = Console.ReadLine();
            }
            // Prompt user for initial amount to place in banking account
            Console.WriteLine("How much would you like to start with in your banking account?");
            // Store input
            s_bankingAccount = Console.ReadLine();
            // Validate
            while (string.IsNullOrWhiteSpace(s_bankingAccount) || !(decimal.TryParse(s_bankingAccount, out bankingAccount)) || 
                bankingAccount < 0)
            {
                Console.WriteLine("Please type in a valid entry.");

                s_bankingAccount = Console.ReadLine();
            }
            // Prompt user for initial amount in checking account
            Console.WriteLine("How much would you like to start with in your checking account?");
            // Store input
            s_checkingAccount = Console.ReadLine();
            // Validate
            while (string.IsNullOrWhiteSpace(s_checkingAccount) || !(decimal.TryParse(s_checkingAccount, out checkingAccount)) ||
                checkingAccount < 0)
            {
                Console.WriteLine("Please type in a valid entry.");

                s_checkingAccount = Console.ReadLine();
            }

            // After recieving inital information from user, build BankAccount object and use input data as object values
            BankAccount userAccount = new BankAccount(userName, bankingAccount, checkingAccount);
            // Brief user of account set up summary
            Console.WriteLine("\r\nThank you for your entries. Here are your details.\r\n" +
                "Account Holder: {0}\r\n" +
                "Banking Account Total: {1:C}\r\n" +
                "Checking Account Total: {2:C}\r\n" +
                "Tatol Assets: {3}",
                userAccount.GetUserName(),
                userAccount.GetBankingAccount(),
                userAccount.GetCheckingAccount(),
                userAccount.GrandTotal(userAccount.GetBankingAccount(), userAccount.GetCheckingAccount()));
            // Begin transaction loops 
            for (int i = 0; i < 3; i++)
            {
                // Prompt user to decide for withdrawal or deposit
                Console.WriteLine("\r\nWould you like to withdrawal or deposit?\r\n" +
                    "Enter (1) for withdrawal.\r\n" +
                    "Enter (2) for diposit.");
                // Store input
                string s_input = Console.ReadLine();
                int input;
                // Validate
                while (string.IsNullOrWhiteSpace(s_input) || !(int.TryParse(s_input, out input)) || input < 1 || input > 2)
                {
                    Console.WriteLine("\r\nPlease type in a valid entry.");
                    s_input = Console.ReadLine();
                }
                // Declare variables for validation for second user transaction prompt
                string s_input2;
                int input2;
                // Declare variables for validation and amount to modify accounts
                string s_amount;
                decimal amount;

                // Withdrawal
                if (input == 1)
                {
                    // Promt user, store input, validate
                    Console.WriteLine("\r\nWhich account would you like to withdrawal from?\r\n" +
                        "Enter (1) for banking.\r\n" +
                        "Enter (2) for checking.");

                    s_input2 = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(s_input2) || !(int.TryParse(s_input2, out input2)) || input2 < 1 || input2 > 2)
                    {
                        Console.WriteLine("\r\nPlease type in a valid entry.");
                        s_input2 = Console.ReadLine();
                    }
                    // Amount to withdrawal 
                    // From Banking Account
                    if (input2 == 1)
                    {

                        // Promt user, store input, validate
                        Console.WriteLine("\r\nHow much would you like to withdrawal?");

                        s_amount = Console.ReadLine();

                        // Validate to check if account has enough to withdrawal
                        while(decimal.TryParse(s_amount, out amount) && amount > userAccount.GetBankingAccount())
                        {
                            Console.WriteLine("You do not have enough funds to withrawal from that account." +
                                "\r\nPlease enter another amount.");
                            s_amount = Console.ReadLine();
                        }
                        // Validate for blank or cannot prase
                        while (string.IsNullOrWhiteSpace(s_amount) || !(decimal.TryParse(s_amount, out amount)) || amount < 0m)
                        {
                            Console.WriteLine("\r\nPlease type in a valid entry.");
                            s_amount = Console.ReadLine();

                        }
                        
                        
                        // Set new banking amount
                        userAccount.SetBanking(userAccount.GetBankingAccount() - amount);
                        // Call InfoCard method to display transaction brief
                        InfoCard();
                    }
                    // For Checking Account
                    else if (input2 == 2)
                    {
                        // Promt use, store input, validate
                        Console.WriteLine("\r\nHow much would you like to withdrawal?");

                        s_amount = Console.ReadLine();

                        // Validate to check if account has enough to withdrawal
                        while (decimal.TryParse(s_amount, out amount) && amount > userAccount.GetCheckingAccount())
                        {
                            Console.WriteLine("You do not have enough funds to withrawal from that account." +
                                "\r\nPlease enter another amount.");
                            s_amount = Console.ReadLine();
                        }

                        while (string.IsNullOrWhiteSpace(s_amount) || !(decimal.TryParse(s_amount, out amount)) || amount < 0m)
                        {
                            Console.WriteLine("\r\nPlease type in a valid entry.");
                            s_amount = Console.ReadLine();
                        }
                        // Set new value for BankAccount object
                        userAccount.SetChecking(userAccount.GetCheckingAccount() - amount);
                        // Call InfoCard method to display transaction brief
                        InfoCard();
                    }


                }
                // Deposit
                else if (input == 2)
                {
                    Console.WriteLine("\r\nWhich account would you like to deposit to?\r\n" +
                        "Enter (1) for banking.\r\n" +
                        "Enter (2) for checking.");

                    s_input2 = Console.ReadLine();

                    while (string.IsNullOrWhiteSpace(s_input2) || !(int.TryParse(s_input2, out input2)) || input2 < 1 || input2 > 2)
                    {
                        Console.WriteLine("\r\nPlease type in a valid entry.");
                        s_input2 = Console.ReadLine();
                    }
                    // Pick what account to make the transaction with, then prompt the user for an amount
                    // Amount to deposit 
                    if (input2 == 1)
                    {
                        // For Banking Account
                        Console.WriteLine("\r\nHow much would you like to deposit?");

                        s_amount = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(s_amount) || !(decimal.TryParse(s_amount, out amount)) || amount < 0m)
                        {
                            Console.WriteLine("\r\nPlease type in a valid entry.");
                            s_amount = Console.ReadLine();
                        }
                        // Set new banking amount
                        userAccount.SetBanking(userAccount.GetBankingAccount() + amount);
                        // Call InfoCard method to display transaction brief
                        InfoCard();
                    }
                    // For Checking Account
                    else if (input2 == 2)
                    {
                        // Prompt user, store input, test for validation
                        Console.WriteLine("\r\nHow much would you like to deposit?");

                        s_amount = Console.ReadLine();

                        while (string.IsNullOrWhiteSpace(s_amount) || !(decimal.TryParse(s_amount, out amount)) || amount < 0m)
                        {
                            Console.WriteLine("\r\nPlease type in a valid entry.");
                            s_amount = Console.ReadLine();
                        }
                        // Set new value to BankAccount object
                        userAccount.SetChecking(userAccount.GetCheckingAccount() + amount);
                        // Call InfoCard method to display transaction brief
                        InfoCard();
                    }
                }
               
            }
            // Give user final account summary
            Console.WriteLine("\r\nThank you for your transactions. Here are your final details.\r\n" +
                "Account Holder: {0}\r\n" +
                "Banking Account Total: {1:C}\r\n" +
                "Checking Account Total: {2:C}\r\n" +
                "Tatol Assets: {3}\r\n" +
                "\r\n--------------------------------------" +
                "\r\nThank you for banking with Future Bank" +
                "\r\n--------------------------------------" +
                "\r\n",
                userAccount.GetUserName(),
                userAccount.GetBankingAccount(),
                userAccount.GetCheckingAccount(),
                userAccount.GrandTotal(userAccount.GetBankingAccount(), userAccount.GetCheckingAccount()));
            Console.ReadLine();
            // Declare InfoCard Method to keep down coding and give transaction briefs after each transaction
            void InfoCard()
            {
                Console.WriteLine("\r\nTransaction summary:" +
                    "\r\nBanking total: {0:C}" +
                    "\r\nChecking total: {1:C}",
                    userAccount.GetBankingAccount(),
                    userAccount.GetCheckingAccount());
            }


        }



    }
}
