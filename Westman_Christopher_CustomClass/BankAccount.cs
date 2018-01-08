using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Westman_Christopher_CustomClass
{
    // Declare BankAccount Class 
    class BankAccount
    {
        // Declare member variables to be used for constructor and other methods
        string mUserName;
        decimal mBankingAccount = 0m;
        decimal mCheckingAccount = 0m;
        // Creat a constructor that sets object values to member variables. This will create our BankAccount objects
        public BankAccount(string _userName, decimal _bankingAccount, decimal _checkingAccount)
        {
            mUserName = _userName;
            mBankingAccount = _bankingAccount;
            mCheckingAccount = _checkingAccount;
        }
        // Create a getter method for each of our object values
        public string GetUserName()
        {
            return mUserName;
        }

        public decimal GetBankingAccount()
        {
            return mBankingAccount;
        }

        public decimal GetCheckingAccount()
        {
            return mCheckingAccount;
        }
        // Create a setter method for each of our object variables in order to modifyt them
        public void SetUserName(string _userName)
        {
            mUserName = _userName;
        }

        public void SetBanking(decimal _bankingAccount)
        {
            mBankingAccount = _bankingAccount;
        }

        public void SetChecking(decimal _checkingAccount)
        {
            mCheckingAccount = _checkingAccount;
        }
        // Create a grand total method that will return a string formatted response to the user with their grand total
        public string GrandTotal(decimal _bankingAccount, decimal _checkingAccount)
        {
            decimal d_grandTotal = _bankingAccount + _checkingAccount;
            string grandTotal = d_grandTotal.ToString("C");
            return grandTotal;
        }

    }
}
