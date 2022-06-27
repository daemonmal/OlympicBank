using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class GetBankAccountIdSub : GetBankAccountIdBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override BankAccount GetBankAccountId(int p_customerId)
        {
            BankAccount getBankAccountIdObj = new BankAccount();
            SqlCommand cmdGetBankAccountId = new SqlCommand("select accountId from bankAccounts where customerId=@cusId", connect);
            cmdGetBankAccountId.Parameters.AddWithValue("@cusId", p_customerId);
            connect.Open();
            SqlDataReader reader = cmdGetBankAccountId.ExecuteReader();
            if (reader.Read())
            {
                getBankAccountIdObj.accountId = (int)reader[0]; // check reader[] column positions
            }
            else
            {
                reader.Close();
                connect.Close();
                throw new Exception("No accounts found with this Customer ID");
            }
            reader.Close();
            connect.Close();
            return getBankAccountIdObj;
        }
    }
}
