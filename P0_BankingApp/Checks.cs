using P0_BankingAppDAL_LIB.Login.Check;
using System;

namespace P0_BankingApp
{
    public class Checks
    {
        public bool CheckUserNameExists(string p_userName)
        {
            CheckCredentialsExists checkCredentialsExistObj = new CheckCredentialsExists();
            bool v_credentialsExist = checkCredentialsExistObj.CheckIfCredentialsExists(p_userName);

            if (!v_credentialsExist)
            {
                Console.WriteLine("The username you entererd does not exist. Please try agian.");
                return false;
            }
            return true;
        }
    }
}
