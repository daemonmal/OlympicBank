
using P0_BankingAppDAL_LIB.Accounts;
using P0_BankingAppDAL_LIB.Login;
using P0_BankingAppDAL_LIB.Login.Check;
using P0_BankingAppDAL_LIB.Login.Update;
using P0_BankingAppDAL_LIB.Login.Users;
using P0_BankingAppDAL_LIB.Login.Users.Get;
using P0_BankingAppDAL_LIB.Login.Users.Status;
using P0_BankingAppDAL_LIB.Login.Validate;
using P0_BankingAppDAL_LIB.Transactions;
using P0_BankingAppDAL_LIB.Transactions.Deposit;
using P0_BankingAppDAL_LIB.Transactions.Transfer;
using P0_BankingAppDAL_LIB.Transactions.Withdraw;
using P0_BankingAppLIB.Login.Get;
using System;
using System.Text;
using System.Threading;

namespace P0_BankingApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
Main:
            Console.Title = "Olympic Bank";
            Utility printBannerObj = new Utility();
            printBannerObj.Banner();

            //Console.WriteLine("$-------------------------> Olympic Bank <-------------------------$");
            Console.WriteLine("1. Login");
            Console.WriteLine("2. Exit");
            Console.Write("Selection: ");
            int choice = Convert.ToInt32(Console.ReadLine());


            #region Login
            // $------------>>> LOGIN <<<-----------$ 
            if (choice == 1)
            {
                bool goToMenu = true;
                while (goToMenu)
                {
Login:
                    Console.Clear();
                    printBannerObj.Banner();
                    Console.WriteLine("Enter Login Credentials");
                    Console.Write("Username: ");
                    string v_uname = Console.ReadLine();

                    //convert input to asteriks in console
                    Console.Write("Password: ");
                    string v_password = Console.ReadLine();

                    // loading bar
                    string loadingbar = " ";
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write("\nLOADING...");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkBlue;
                        Console.Write(loadingbar);
                        Thread.Sleep(1000);
                    }
                    Console.ResetColor();

                    // initialize objects used throughout
                    Credentials credentialsObj = new Credentials();
                    BankAccount bankAccountObj = new BankAccount();
                    Transaction transactionObj = new Transaction();
                    CheckBankAccountExists checkBankAccountExistsObj1 = new CheckBankAccountExists();
                    CheckBankAccountExists checkBankAccountExistsObj2 = new CheckBankAccountExists();
                    CheckCredentialsExists checkCredentialsExistObj = new CheckCredentialsExists();
                    CheckUserAccountStatusSub checkUserAccountStatusObj = new CheckUserAccountStatusSub();
                    CheckUserAccountType checkAccountTypeObj = new CheckUserAccountType();
                    CheckCustomerIdExists checkCustomerIdExistsObj = new CheckCustomerIdExists();
                    ValidateCredentials validatePasswordObj = new ValidateCredentials();
                    GetLoginAttempts loginAttmptsObj = new GetLoginAttempts();
                    GetCustomerIdSub getCustomerIdObj = new GetCustomerIdSub();
                    GetAccountBalanceSingle getAccountBalanceObj = new GetAccountBalanceSingle();
                    //GetAccount getBankAccountDetailsObj = new GetAccount();
                    DepositSub depositObj = new DepositSub();
                    WithdrawSub withdrawObj = new WithdrawSub();
                    TransferSub transferObj = new TransferSub();
                    Utility utilityObj = new Utility();

                    // variables used throughout
                    bool v_accountIdExists1;
                    bool v_accountIdExists2;
                    bool v_credentialsExist;
                    bool v_accountActive;
                    bool v_customerIdExists;
                    bool v_loginValidated;
                    double v_withdrawAmount;
                    double v_depositAmount;
                    double v_transferAmount;
                    decimal v_accountBalance1;
                    decimal v_accountBalance2;
                    int v_customerId;
                    int v_loginAttempts;
                    int v_accountType;
                    int v_accountId1;
                    int v_accountId2;

                    // check if the username exists
                    v_credentialsExist = checkCredentialsExistObj.CheckIfCredentialsExists(v_uname);

                    if (!v_credentialsExist)
                    {
                        Console.WriteLine("\nThe username you entererd does not exist. Please try agian.");
                        Console.ReadLine();
                        goto Login;
                    }

                    // check account status
                    v_accountActive = checkUserAccountStatusObj.CheckUserAccountStatus(v_uname);

                    if (!v_accountActive)
                    {
                        Console.WriteLine("Your account is disabled. Please contact your local branch to resolve this issue.");
                        goToMenu = false;
                        Console.Clear();
                        goto Main;
                    }

                    // validate user password
                    v_loginValidated = validatePasswordObj.ValidateUserCredentials(v_uname, v_password);

                    // get account type to direct to proper menu
                    v_accountType = checkAccountTypeObj.GetAccountType(v_uname);

                    //login validation --> more than 3 incorrect attempts disables account
                    v_loginAttempts = loginAttmptsObj.LoginAttempts(v_uname);

                    if (v_loginValidated == true)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGreen;
                        Console.WriteLine("\nLogin Successful!");
                        Console.ReadLine();
                        Console.ResetColor();
                        Console.Clear();

                        if (v_accountType == 1)
                        {

                            #region Admin Menu

                            // admin menu

                            bool loggedInAsAdmin = true;

                            while (loggedInAsAdmin)
                            {
                                printBannerObj.Banner();
                                Console.WriteLine("Weclome to your Employee Account. What would you like to do?");
                                Console.WriteLine("1. Create New User Account");
                                Console.WriteLine("2. View Account Details");
                                Console.WriteLine("3. Withdraw Customer Funds");
                                Console.WriteLine("4. Deposit Customer Funds");
                                Console.WriteLine("5. Transfer Customer Funds");
                                Console.WriteLine("6. Disable Customer Account");
                                Console.WriteLine("7. Enable Customer Account");
                                Console.WriteLine("8. Logout");
                                Console.Write("\nMenu Selection: ");

                                int selectionEmp = Convert.ToInt32(Console.ReadLine());

                                #region Menu Switches
                                switch (selectionEmp)
                                {

                                    #region Case 1: Create New Account
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("1. Create New User Account");
                                        Console.WriteLine("Enter the customer account information");
                                        Console.Write("Username: ");
                                        credentialsObj.userName = Console.ReadLine();
                                        Console.Write("Password: ");
                                        credentialsObj.userPassword = Console.ReadLine();

                                        // create user account
                                        v_credentialsExist = checkCredentialsExistObj.CheckIfCredentialsExists(credentialsObj.userName);

                                        if (v_credentialsExist)
                                        {
                                            Console.WriteLine("The username you entererd already exist. Please enter a unique User Name.");
                                            Console.ReadLine();
                                            goto case 1;
                                        }

                                        NewCredentials addUserAccountObj = new NewCredentials();
                                        addUserAccountObj.AddUserCredentials(credentialsObj);
                                        bankAccountObj.customerId = getCustomerIdObj.GetCustomerId(credentialsObj.userName);

                                        Console.WriteLine("New Customers are required to open a Checking Account with a minimum $150 balance.\n Please enter the initial deposit amount.");
                                        bankAccountObj.accountType = "Checking";

                                        Console.Write("Initial Account Balance: ");
                                        bankAccountObj.accountBalance = Convert.ToDecimal(Console.ReadLine());
                                        Console.Write("Branch ID: ");
                                        bankAccountObj.branchId = Convert.ToInt32(Console.ReadLine());
                                        Console.ReadLine();

                                        // create new bank account

                                        NewBankAccount addBankAccountObj = new NewBankAccount();
                                        addBankAccountObj.AddBankAccount(bankAccountObj);

                                        Console.WriteLine("User Account and Checking Account added successfully.");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 2: View Account Details
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("2. View Bank Account Details");
                                        Console.WriteLine("Enter the Customer ID to view the account details of all accounts held by this customer.");
                                        Console.Write("Customer ID: ");
                                        v_customerId = Convert.ToInt32(Console.ReadLine());
                                        v_customerIdExists = checkCustomerIdExistsObj.CheckIfCustomerIdExists(v_customerId);

                                        if (!v_customerIdExists)
                                        {
                                            Console.WriteLine("The Customer ID you entered does not exists. Please entere an existing Customer ID.");
                                            Console.ReadLine();
                                            goto case 2;
                                        }

                                        // output in table format                                        
                                        _ = new StringBuilder();
                                        StringBuilder sb1 = utilityObj.GenerateBankAccountTable(v_customerId);
                                        Console.WriteLine(sb1);
                                        Console.ReadLine();

                                        /* 
                                        List<BankAccount> listBankAccountDetailsObj = getBankAccountDetailsObj.GetAccountDetails(v_customerId);
                                        var sb = new StringBuilder();
                                        sb.Append(String.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10}\n\n",
                                            "Account ID", "Balance", "Account Type", "Creation Date", "Branch ID"));

                                        for (int index = 0; index < listBankAccountDetailsObj.Count; index++)
                                        {
                                            sb.Append(String.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10}\n", listBankAccountDetailsObj[index], listBankAccountDetailsObj[index], listBankAccountDetailsObj[index],
                                                listBankAccountDetailsObj[index], listBankAccountDetailsObj[index]));
                                        }
                                        */

                                        Console.Clear();
                                        break;

                                    #endregion

                                    #region Case 3: Withdraw Customer Funds 
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("3. Withdraw Customer Funds");
                                        Console.WriteLine("Enter the account ID to withdraw from");
                                        Console.Write("Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());

                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing Customer ID.");
                                            Console.ReadLine();
                                            goto case 3;
                                        }
                                        v_customerId = getCustomerIdObj.GetCustomerId2(v_accountId1);

                                        Console.Write("Amount: $");
                                        v_withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_withdrawAmount < 0)
                                        {
                                            Console.WriteLine("Cannot withdraw a negative amount.");
                                            Console.ReadLine();
                                            goto case 3;
                                        }
                                        if (v_withdrawAmount > 15000)
                                        {
                                            Console.WriteLine("Accounts cannot withdraw more than $15,000");
                                            Console.ReadLine();
                                            goto case 3;
                                        }

                                        withdrawObj.Withdraw(v_accountId1, v_withdrawAmount, v_customerId);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        Console.WriteLine($"New Account Balance: ${v_accountBalance1}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 4: Deposit Customer Funds
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("4. Deposit Customer Funds");
                                        Console.WriteLine("Enter the account ID to Deposit to");
                                        Console.Write("Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());

                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing Customer ID.");
                                            Console.ReadLine();
                                            goto case 4;
                                        }

                                        v_customerId = getCustomerIdObj.GetCustomerId2(v_accountId1);

                                        Console.Write("Amount: $");
                                        v_depositAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_depositAmount < 100)
                                        {
                                            Console.WriteLine("Cannot deposit less than $100.");
                                            Console.ReadLine();
                                            goto case 4;
                                        }
                                        if (v_depositAmount > 30000)
                                        {
                                            Console.WriteLine("Accounts cannot deposit more than $30,000");
                                            Console.ReadLine();
                                            goto case 4;
                                        }

                                        depositObj.Deposit(v_accountId1, v_depositAmount, v_customerId);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        Console.WriteLine($"New Account Balance: ${v_accountBalance1}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 5: Transfer Customer Funds
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("5. Transfer Customer Funds");
                                        Console.WriteLine("Enter the Account ID's to initiate the transfer.");
                                        Console.Write("Send Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());
                                        Console.Write("Recieve Account ID: ");
                                        v_accountId2 = Convert.ToInt32(Console.ReadLine());

                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Send Account ID you entered does not exists. Please entere an existing Customer ID.");
                                            Console.ReadLine();
                                            goto case 5;
                                        }
                                        int customerIdSend = getCustomerIdObj.GetCustomerId2(v_accountId1);
                                        int customerIdRec = getCustomerIdObj.GetCustomerId2(v_accountId2);
                                        v_accountIdExists2 = checkBankAccountExistsObj2.CheckIfAccountExists(v_accountId2);

                                        if (!v_accountIdExists2)
                                        {
                                            Console.WriteLine("The Send Account ID you entered does not exists. Please entere an existing Customer ID.");
                                            Console.ReadLine();
                                            goto case 5;
                                        }

                                        Console.Write("Amount: $");
                                        v_transferAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_transferAmount < 50)
                                        {
                                            Console.WriteLine("Cannot deposit less than $100.");
                                            Console.ReadLine();
                                            goto case 5;
                                        }
                                        if (v_transferAmount > 45000)
                                        {
                                            Console.WriteLine("Accounts cannot deposit more than $30,000");
                                            Console.ReadLine();
                                            goto case 5;
                                        }

                                        transferObj.Transfer(v_accountId2, customerIdRec, v_accountId1, customerIdSend, v_transferAmount);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        v_accountBalance2 = getAccountBalanceObj.GetAccountBalance(v_accountId2);
                                        Console.WriteLine($"Account ID: {v_accountId1} new Account Balance: ${v_accountBalance1}");
                                        Console.WriteLine($"Account ID: {v_accountId2} new Account Balance: ${v_accountBalance2}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 6: Disable Customer Account
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("6. Disable Customer Account");
                                        Console.Write("Enter the Username of the account to be disabled: ");
                                        v_uname = Convert.ToString(Console.ReadLine());

                                        // check if the username exists
                                        v_credentialsExist = checkCredentialsExistObj.CheckIfCredentialsExists(v_uname);

                                        if (!v_credentialsExist)
                                        {
                                            Console.WriteLine("The username you entererd does not exist. Please try agian.");
                                            Console.ReadLine();
                                            goto case 6;
                                        }

                                        StatusDisableAccountSub disableAccountObj = new StatusDisableAccountSub();
                                        disableAccountObj.Disable(v_uname);
                                        Console.WriteLine($"The user {v_uname}'s account has been disabled.");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 7: Enable Customer Account
                                    case 7:
                                        Console.Clear();
                                        Console.WriteLine("7. Enable Customer Account");
                                        Console.Write("Enter the Username of the account to be enable: ");
                                        v_uname = Convert.ToString(Console.ReadLine());

                                        // check if the username exists
                                        v_credentialsExist = checkCredentialsExistObj.CheckIfCredentialsExists(v_uname);

                                        if (!v_credentialsExist)
                                        {
                                            Console.WriteLine("The username you entererd does not exist. Please try agian.");
                                            Console.ReadLine();
                                            goto case 7;
                                        }

                                        StatusEnableAccountBase enableObj = new StatusEnableAccountSub();
                                        enableObj.Enable(v_uname);
                                        Console.WriteLine($"The user {v_uname}'s account has been enabled.");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 8: Logout
                                    case 8:
                                        Console.Clear();
                                        Console.WriteLine("8. Logout");
                                        Console.WriteLine("Logout Succesful");
                                        loggedInAsAdmin = false;
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    default:
                                        Console.WriteLine("Incorrect Selection. Please Select an option from the Menu");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                }

                                #endregion
                            }

                            #endregion
                        }
                        else
                        {
                            Console.Clear();
                            v_customerId = getCustomerIdObj.GetCustomerId(v_uname);

                            #region Customer Menu
                            //customer menu

                            bool loggedInAsCustomer = true;

                            while (loggedInAsCustomer)
                            {
                                printBannerObj.Banner();
                                Console.WriteLine("Weclome to your Customer Account. What would you like to do today?");
                                Console.WriteLine("1. Check Account Balances");
                                Console.WriteLine("2. Withdraw Funds");
                                Console.WriteLine("3. Deposit Funds");
                                Console.WriteLine("4. Transfer Funds");
                                Console.WriteLine("5. View Last 10 Transactions");
                                Console.WriteLine("6. Change Account Password");
                                Console.WriteLine("7. Logout");
                                Console.Write("Menu Selection: ");
                                int selectionCus = Convert.ToInt32(Console.ReadLine());

                                #region Menu Switches
                                switch (selectionCus)
                                {

                                    #region Case 1: Check Account Balances
                                    case 1:
                                        Console.Clear();
                                        Console.WriteLine("1. Check All Account Balances");
                                        Console.WriteLine("Your open accounts:");

                                        // list available bank accounts in table format                                       
                                        _ = new StringBuilder();
                                        StringBuilder sb2 = utilityObj.GenerateBankAccountTable(v_customerId);
                                        Console.WriteLine(sb2);

                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 2: Withdraw Funds
                                    case 2:
                                        Console.Clear();
                                        Console.WriteLine("2. Withdraw Funds");
                                        Console.WriteLine("Your Accounts Available for Withdrawal:");

                                        // list available bank accounts in table format                                       
                                        _ = new StringBuilder();
                                        StringBuilder sb3 = utilityObj.GenerateBankAccountTable(v_customerId);
                                        Console.WriteLine(sb3);

                                        Console.WriteLine("Enter the Account ID from above of the account you would like to Withdraw from.");
                                        Console.Write("Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());
                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing Account ID.");
                                            Console.ReadLine();
                                            goto case 2;
                                        }

                                        Console.Write("Amount: $");
                                        v_withdrawAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_withdrawAmount < 0)
                                        {
                                            Console.WriteLine("Cannot withdraw a negative amount.");
                                            Console.ReadLine();
                                            goto case 2;
                                        }
                                        if (v_withdrawAmount > 15000)
                                        {
                                            Console.WriteLine("Accounts cannot withdraw more than $15,000");
                                            Console.ReadLine();
                                            goto case 2;
                                        }

                                        withdrawObj.Withdraw(v_accountId1, v_withdrawAmount, v_customerId);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        Console.WriteLine($"New Account Balance: ${v_accountBalance1}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 3: Deposit Funds
                                    case 3:
                                        Console.Clear();
                                        Console.WriteLine("3. Deposit Funds");
                                        Console.WriteLine("Your Accounts Available for Deposit:");

                                        // list available bank accounts in table format                                       
                                        _ = new StringBuilder();
                                        StringBuilder sb4 = utilityObj.GenerateBankAccountTable(v_customerId);
                                        Console.WriteLine(sb4);

                                        Console.WriteLine("Enter the Account ID from above of the account you would like to Deposit to.");
                                        Console.Write("Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());
                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing account ID.");
                                            Console.ReadLine();
                                            goto case 3;
                                        }

                                        Console.Write("Amount: $");
                                        v_depositAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_depositAmount < 100)
                                        {
                                            Console.WriteLine("Cannot deposit less than $100.");
                                            Console.ReadLine();
                                            goto case 3;
                                        }
                                        if (v_depositAmount > 30000)
                                        {
                                            Console.WriteLine("Accounts cannot deposit more than $30,000");
                                            Console.ReadLine();
                                            goto case 3;
                                        }

                                        depositObj.Deposit(v_accountId1, v_depositAmount, v_customerId);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        Console.WriteLine($"New Account Balance: ${v_accountBalance1}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 4: Transfer Funds
                                    case 4:
                                        Console.Clear();
                                        Console.WriteLine("4. Transfer Funds");
                                        Console.WriteLine("Your Accounts Available for Transfer:");

                                        // list available bank accounts in table format                                       
                                        _ = new StringBuilder();
                                        StringBuilder sb5 = utilityObj.GenerateBankAccountTable(v_customerId);
                                        Console.WriteLine(sb5);

                                        Console.WriteLine("Enter the Account ID from above of the account you would like to Transfer from.");
                                        Console.Write("Account ID: ");
                                        v_accountId1 = Convert.ToInt32(Console.ReadLine());

                                        v_accountIdExists1 = checkBankAccountExistsObj1.CheckIfAccountExists(v_accountId1);

                                        if (!v_accountIdExists1)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing Account ID.");
                                            Console.ReadLine();
                                            goto case 4;
                                        }

                                        v_customerId = getCustomerIdObj.GetCustomerId2(v_accountId1);

                                        Console.WriteLine("What is the account ID of the account your are transferring to?");
                                        Console.Write("Account ID: ");
                                        v_accountId2 = Convert.ToInt32(Console.ReadLine());

                                        v_accountIdExists2 = checkBankAccountExistsObj2.CheckIfAccountExists(v_accountId2);

                                        if (!v_accountIdExists2)
                                        {
                                            Console.WriteLine("The Account ID you entered does not exists. Please entere an existing Account ID.");
                                            Console.ReadLine();
                                            goto case 4;
                                        }

                                        int customerIdRec = getCustomerIdObj.GetCustomerId2(v_accountId2);

                                        Console.Write("Amount: $");
                                        v_transferAmount = Convert.ToDouble(Console.ReadLine());

                                        if (v_transferAmount < 50)
                                        {
                                            Console.WriteLine("Cannot deposit less than $100.");
                                            Console.ReadLine();
                                            goto case 4;
                                        }
                                        if (v_transferAmount > 45000)
                                        {
                                            Console.WriteLine("Accounts cannot deposit more than $30,000");
                                            Console.ReadLine();
                                            goto case 4;
                                        }

                                        transferObj.Transfer(v_accountId2, customerIdRec, v_accountId1, v_customerId, v_transferAmount);
                                        v_accountBalance1 = getAccountBalanceObj.GetAccountBalance(v_accountId1);
                                        v_accountBalance2 = getAccountBalanceObj.GetAccountBalance(v_accountId2);
                                        Console.WriteLine($"Account ID: {v_accountId1} new Account Balance: ${v_accountBalance1}");
                                        Console.WriteLine($"Account ID: {v_accountId2} new Account Balance: ${v_accountBalance2}");
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 5: View Last 10 Transactions
                                    case 5:
                                        Console.Clear();
                                        Console.WriteLine("5. View Last 10 Transactions");
                                        _ = new StringBuilder();
                                        StringBuilder sb6 = utilityObj.TransactionTableLast10(v_customerId);
                                        Console.WriteLine(sb6);
                                        Console.ReadLine();
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 6: Change Account Password
                                    case 6:
                                        Console.Clear();
                                        Console.WriteLine("6. Change Account Password");
                                        Console.Write("Current Password: ");
                                        string v_oldPassword = Console.ReadLine(); // use objects to protect the values
                                        string v_newPassword; // use objects to protect the values
                                        int v_resetAttempts = 1;
                                        v_loginValidated = validatePasswordObj.ValidateUserCredentials(v_uname, v_oldPassword);
                                        while (v_resetAttempts < 3)
                                        {
                                            if (!v_loginValidated)
                                            {
                                                Console.WriteLine($"The current password you entered is incorrect.\nYou have {v_resetAttempts} more password reset attempts before your account is disabled.");
                                                v_resetAttempts++;
                                                Console.ReadLine();
                                                Console.Clear();
                                                goto case 6;
                                            }
                                            Console.Write("New Password: ");
                                            v_newPassword = Console.ReadLine();
                                            ChangeUserAccountPass changePasswordObj = new ChangeUserAccountPass();
                                            changePasswordObj.ChangePassword(v_newPassword, v_uname); // use objects to protect the values
                                        }
                                        Console.Clear();
                                        break;
                                    #endregion

                                    #region Case 7: Logout
                                    case 7:
                                        Console.Clear();
                                        Console.WriteLine("7. Logout");
                                        Console.WriteLine("Logout Succesful");
                                        loggedInAsCustomer = false;
                                        Console.Clear();
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
                    else
                    {
                        if (v_loginAttempts < 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"\nIncorrect Password. You have {3 - v_loginAttempts} more attempts before your account is disabled.");
                            Console.WriteLine("Please Try Again.");
                            Console.ReadLine();
                            Console.ResetColor();
                            Console.Clear();
                        }
                        if (v_loginAttempts == 3)
                        {
                            StatusDisableAccountSub disableAccountObj2 = new StatusDisableAccountSub();
                            disableAccountObj2.Disable(v_uname);
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("\nIncorrect Password. Your Account is DISABLED. Please contact your branch for support.");
                            Console.ReadLine();
                            Console.ResetColor();
                            goToMenu = false;
                            Console.Clear();
                            goto Main;
                        }
                    }
                }
            }

            #endregion

            #region Exit

            else
            {
                Console.Clear();
                printBannerObj.Banner();
                Console.ForegroundColor = ConsoleColor.DarkGreen;
                Console.WriteLine("\t\t\tThank you for choosing Olympic Bank!");
                Console.ReadLine();
            }

            #endregion 
        }
    }
}
