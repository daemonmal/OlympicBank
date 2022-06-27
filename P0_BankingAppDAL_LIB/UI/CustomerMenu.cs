using System;

namespace P0_BankingAppLIB.UI
{
    public class CustomerMenu
    {
        public static void GetCustomerMenu(string[] args)
        {
            #region Customer Menu
            // call login method
            // {WIP} Customer Menu -- Use userPin to perform account operations; lockout and logout after 3 failed pin attempts 
            Console.WriteLine("Weclome to your Customer Account. What would you like to do?");

            Console.WriteLine("1. Check Account Balances");
            Console.WriteLine("2. Withdraw Funds");
            Console.WriteLine("3. Deposit Funds");
            Console.WriteLine("4. Transfer Funds");
            Console.WriteLine("5. View Last 10 Transactions");
            Console.WriteLine("6. Change Account Password");
            Console.WriteLine("7. Logout");
            int selectionCus = Convert.ToInt32(Console.ReadLine());

            // create credentials, customer, account, and transaction objects to store all user info in for session
            // get and store customer ID and account ID's to check account balances and transaction history -- [WIP] and user PIN to validate before account operations

            bool loggedInAsCustomer = true;

            while (loggedInAsCustomer)
            {

                #region Menu Switches
                switch (selectionCus)
                {

                    #region Case 1: Check Account Balances
                    case 1:
                        Console.WriteLine("1. Check Account Balances");
                        // list all account balances associated with customer ID -- break if none exist
                        // some code
                        break;
                    #endregion

                    #region Case 2: Withdraw Funds
                    case 2:
                        Console.WriteLine("2. Withdraw Funds");
                        Console.WriteLine("Which account would you like to withdraw from?");
                        // list accounts given account customer ID and send to switch -- break if no account exists
                        // grab and store selected account ID and send to withdraw()
                        // grab withdraw amount and pass through max/min check
                        // return new account balance with CheckBalance()
                        // some code
                        break;
                    #endregion

                    #region Case 3: Deposit Funds
                    case 3:
                        Console.WriteLine("3. Deposit Funds");
                        Console.WriteLine("Which account would you like to deposit to?");
                        // list accounts given customer ID and send to switch -- break if no account exists
                        // grab and store selected account ID and send to deposit()
                        // grab deposit amount and pass through max/min check
                        // return new account balance with CheckBalance()
                        // some code
                        break;
                    #endregion

                    #region Case 4: Transfer Funds
                    case 4:
                        Console.WriteLine("4. Transfer Funds");
                        Console.WriteLine("Which account would you like to transfer from?");
                        // list accounts given customer ID and send to switch -- break if no account exists
                        // grab and store selected account ID and send to transfer()
                        // grab transfer amount and pass through max/min check
                        // return new account balance with CheckBalance()
                        Console.WriteLine("What is the account ID of the account your are transferring to?");
                        // break if no account exists
                        // some code
                        break;
                    #endregion

                    #region Case 5: View Last 10 Transactions
                    case 5:
                        // if none exists return
                        Console.WriteLine("5. View Last 10 Transactions");
                        // some code
                        break;
                    #endregion

                    #region Case 6: Change Account Password
                    case 6:
                        Console.WriteLine("6. Change Account Password");
                        // [WIP] ask for existing and disable account if 3 failed attempts
                        // some code
                        break;
                    #endregion

                    #region Case 7: Logout
                    case 7:
                        Console.WriteLine("7. Logout");
                        loggedInAsCustomer = false;
                        // back to login
                        break;
                    #endregion

                    default:
                        Console.WriteLine("Incorrect Selection. Please Select an option from the Menu");
                        break;
                }
                #endregion
            }

            #endregion
        }
    }
}
