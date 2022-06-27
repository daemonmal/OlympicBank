using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    public class CheckUserAccountStatusSub : CheckUserAccountStatusBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");
        public override bool CheckUserAccountStatus(string p_userName)
        {
            SqlCommand cmdCheckUserAccountStatus = new SqlCommand("select accountIsActive from userAccounts where userName=@uName", connect);
            cmdCheckUserAccountStatus.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            int queryResult = Convert.ToInt32(cmdCheckUserAccountStatus.ExecuteScalar());
            connect.Close();
            if (queryResult == 1)
            {
                return true; // user account is active
            }
            return false;

        }
    }
}
