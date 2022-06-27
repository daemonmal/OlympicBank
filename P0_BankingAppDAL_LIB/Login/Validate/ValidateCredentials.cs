using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Validate
{
    public class ValidateCredentials
    {
        // used to validate login
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public bool ValidateUserCredentials(string p_userName, string p_userPassword)
        {
            SqlCommand cmdValidatetUserCredentials = new SqlCommand("select count(*) from userAccounts where userName=@uName and userPassword=@uPass", connect);
            cmdValidatetUserCredentials.Parameters.AddWithValue("uName", p_userName);
            cmdValidatetUserCredentials.Parameters.AddWithValue("uPass", p_userPassword);
            connect.Open();
            int v_queryResults = Convert.ToInt32(cmdValidatetUserCredentials.ExecuteScalar());
            connect.Close();
            if (v_queryResults == 0)
            {
                // incorrect password --> loginAttempts++
                SqlCommand cmdIncrementAttempts = new SqlCommand("update userAccounts set loginAttempts=loginAttempts+1 where userName=@uName", connect);
                cmdIncrementAttempts.Parameters.AddWithValue("@uName", p_userName);
                connect.Open();
                cmdIncrementAttempts.ExecuteNonQuery();
                connect.Close();
                return false;
            }
            return true;
        }
    }
}
