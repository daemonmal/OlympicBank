using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    public class CheckUserAccountType
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public int GetAccountType(string p_userName)
        {
            SqlCommand cmdGetAccountType = new SqlCommand("select userIsAdmin from userAccounts where userName=@uName", connect);
            cmdGetAccountType.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            int accountType = Convert.ToInt32(cmdGetAccountType.ExecuteScalar());
            connect.Close();

            return accountType;
        }
    }
}
