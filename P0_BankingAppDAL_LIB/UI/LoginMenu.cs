using P0_BankingAppLIB.Login.Check;
using P0_BankingAppLIB.Login.Validate;
using System;

namespace P0_BankingAppLIB.UI
{
    public class LoginMenu
    {
        public static void Login(string[] args)
        {
Start:
            Console.WriteLine("$-------------------------> Olympic Bank <-------------------------$");
            Console.WriteLine("\t\tEnter Login Credentials");
            Console.Write("\t\tUsername: ");
            string v_uname = Console.ReadLine();
            Console.Write("\t\tPassword: ");
            string v_password = Console.ReadLine();

            CheckCredentialsExists loginObj1 = new CheckCredentialsExists();
            bool credentialsExist = loginObj1.CheckIfCredentialsExists(v_uname);

            if (!credentialsExist)
            {
                Console.WriteLine("The username you entererd does not exist. Please try agian."); ;
                goto Start;
            }

            ValidateCredentials loginObj2 = new ValidateCredentials();
            bool loginVerifier = loginObj2.ValidateUserCredentials(v_uname, v_password);
            // create credentials object to store account type to direct to proper menu


            //login validation --> more than 3 incorrect attempts locks account
            bool goToMenu = false;
            int loginAttempts = 3;

            if (loginVerifier == true)
            {
                goToMenu = true;

                // if loop to call proper menu method
            }

            else
            {
                loginAttempts--;
                goToMenu = false;

                while (loginAttempts > 0 && goToMenu == false)
                {
                    Console.WriteLine($"Incorrect Password. You have {loginAttempts} more attempts before account lockout.");
                    Console.WriteLine("Please Try Again.");
                    loginAttempts--;
                    // call Run.Login.Menu() method --> lines 14-19
                    // pass to login verifier method

                    if (loginVerifier == true)
                    {
                        goToMenu = true;
                        // call menu method
                        break;
                    }
                    if (loginAttempts == 0)
                    {
                        Console.WriteLine("Incorrect Password. Your Account is DISABLED. Please contact your branch for support.");
                        // go back to Login.Run() start menu
                    }
                }
            }
        }
    }
}
