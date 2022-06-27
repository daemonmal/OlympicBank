using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class GetBalanceSubCustomer : GetBalanceBase
    {
        // used to get all acount balances associated with customer ID
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");
        public override BankAccount GetAccountBalance(int p_customerId)
        {
            BankAccount getAccountBalanceObj = new BankAccount();
            SqlCommand cmdGetBalance = new SqlCommand("select * from table_name where customerId=@customerId", connect);
            connect.Open();
            SqlDataReader reader = cmdGetBalance.ExecuteReader();
            if (reader.Read())
            {
                getAccountBalanceObj.accountBalance = (double)reader[4]; // check reader[] column positions
            }
            else
            {
                connect.Close();
                reader.Close();
                throw new Exception("Incorrect customer ID. Please Try Again");
            }
            connect.Close();
            reader.Close();
            return getAccountBalanceObj;

            throw new NotImplementedException();
        }
    }
}
