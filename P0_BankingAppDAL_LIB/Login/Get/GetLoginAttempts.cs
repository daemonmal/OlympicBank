using P0_BankingAppDAL_LIB.Login.Users;
using System;
using System.Data.SqlClient;


namespace P0_BankingAppLIB.Login.Get
{
    public class GetLoginAttempts
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public int LoginAttempts(string p_userName)
        {
            Credentials getLoginAttemptsCredentialsObj = new Credentials();
            SqlCommand cmdGetLoginAttempts = new SqlCommand("select loginAttempts from userAccounts where userName=@uName", connect);
            cmdGetLoginAttempts.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();

            getLoginAttemptsCredentialsObj.loginAttempts = Convert.ToInt32(cmdGetLoginAttempts.ExecuteScalar()); // check reader[] column position

            connect.Close();
            return getLoginAttemptsCredentialsObj.loginAttempts;
        }

    }
}
