using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Users.Get
{
    public class GetCustomerIdSub : GetCustomerIdBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override int GetCustomerId(string p_userName)
        {
            int customerId;
            SqlCommand cmdGetId = new SqlCommand("select customerId from userAccounts where userName=@uName", connect);
            cmdGetId.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            customerId = Convert.ToInt32(cmdGetId.ExecuteScalar());

            connect.Close();
            return customerId;
        }
        public override int GetCustomerId2(int p_accountId)
        {
            int customerId;
            SqlCommand cmdGetId = new SqlCommand("select customerId from bankAccounts where accountId=@accId", connect);
            cmdGetId.Parameters.AddWithValue("@accId", p_accountId);

            connect.Open();
            customerId = Convert.ToInt32(cmdGetId.ExecuteScalar());
            connect.Close();
            return customerId;
        }
    }
}
