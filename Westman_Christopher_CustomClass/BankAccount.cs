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
        // Declared auto-implemented properties
        // Refactored from SDI 
        public string UserName { get; set; }
        public decimal SavingsAccount { get; set; }
        public decimal CheckingAccount { get; set; }
        // Creat a constructor that sets object values to member variables. This will create our BankAccount objects
        public BankAccount(string userName, decimal savingsAccount, decimal checkingAccount)
        {
            UserName = userName;
            SavingsAccount = savingsAccount;
            CheckingAccount = checkingAccount;
        }

        // Create a grand total method that will return a string formatted response to the user with their grand total
        public string GrandTotal(decimal savingsAccount, decimal checkingAccount)
        {
            decimal d_grandTotal = savingsAccount + checkingAccount;
            string grandTotal = d_grandTotal.ToString("C");
            return grandTotal;
        }

    }
}
