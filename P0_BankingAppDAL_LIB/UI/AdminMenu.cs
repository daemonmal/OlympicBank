using System;

namespace P0_BankingAppLIB.UI
{
    public class AdminMenu
    {
        public static void GetEmployeeMenu(string[] args)
        {
            #region Employee Menu
            // call login menu method
            // create employee and credentials object to store for session
            // Employee Menu
            Console.WriteLine("Weclome to your Employee Account. What would you like to do?");

            Console.WriteLine("1. Create New User Account");
            Console.WriteLine("2. View Account Details");
            Console.WriteLine("3. Withdraw Customer Funds");
            Console.WriteLine("4. Deposit Customer Funds");
            Console.WriteLine("5. Transfer Customer Funds");
            Console.WriteLine("6. Disable Customer Account");
            Console.WriteLine("7. Enable Customer Account");
            Console.WriteLine("8. Logout");

            int selectionEmp = Convert.ToInt32(Console.ReadLine());

            // create customer, account, and transaction objects to be used 


            bool loggedInAsAdmin = true;

            while (loggedInAsAdmin)
            {

                #region Menu Switches
                switch (selectionEmp)
                {

                    #region Case 1: Create New Account
                    case 1:
                        // check if customer ID exists -- break if account ID exists
                        Console.WriteLine("1. Create New User Account");
                        // some code
                        break;
                    #endregion

                    #region Case 2: View Account Details
                    case 2:
                        Console.WriteLine("2. View Account Details");
                        // get and store customer ID to get associated accounts -- break if account ID doesnt exist
                        // some code
                        break;
                    #endregion

                    #region Case 3: Withdraw Customer Funds 
                    case 3:
                        Console.WriteLine("3. Withdraw Customer Funds");
                        // get and store account ID to withdraw from that account -- break if account ID doesnt exist
                        // grab withdarw amount and pass through max/min check
                        // return new account balance with CheckBalance()
                        // some code
                        break;
                    #endregion

                    #region Case 4: Deposit Customer Funds
                    case 4:
                        Console.WriteLine("4. Deposit Customer Funds");
                        // get and store account ID to deposit to that account -- break if account ID doesnt exist
                        // grab deposit amount and pass through max/min check
                        // return new account balance with CheckBalance()
                        // some code
                        break;
                    #endregion

                    #region Case 5: Transfer Customer Funds
                    case 5:
                        Console.WriteLine("5. Transfer Customer Funds");
                        // get and store send/rec account IDs to transfer -- break if send/rec account ID doesnt exist
                        // grab transfer amount and pass through max/min check
                        // return new account balances with CheckBalance()
                        // some code
                        break;
                    #endregion

                    #region Case 6: Disable Customer Account
                    case 6:
                        Console.WriteLine("6. Disable Customer Account");
                        // get and store user name to disable that account -- break if user name doesnt exist
                        // some code
                        break;
                    #endregion

                    #region Case 7: Enable Customer Account
                    case 7:
                        Console.WriteLine("7. Enable Customer Account");
                        // get and store user name to enable that account -- break if user name doesnt exist
                        // some code
                        break;
                    #endregion

                    #region Case 8: Logout
                    case 8:
                        Console.WriteLine("8. Logout");
                        loggedInAsAdmin = false;
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
