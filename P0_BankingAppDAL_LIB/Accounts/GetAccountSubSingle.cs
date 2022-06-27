using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class GetAccountSubSingle : GetBankAccountBase
    {
        // fix later
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");

        public override BankAccount GetAccountDetails(int p_accountId)
        {
            BankAccount getAccountDetailsObj = new BankAccount();
            SqlCommand cmdGetAccountDetails = new SqlCommand("select * from table_name where customerId=@cusId AND accountId=@accId", connect);
            cmdGetAccountDetails.Parameters.AddWithValue("@cusId", p_customerId);
            cmdGetAccountDetails.Parameters.AddWithValue("@accId", p_accountId);
            SqlDataReader reader = cmdGetAccountDetails.ExecuteReader();

            if (reader.Read())
            {
                getAccountDetailsObj.accountId = (int)reader[0];
                getAccountDetailsObj.customerId = (int)reader[2];
                getAccountDetailsObj.accountType = (AccountType)reader[3];
                getAccountDetailsObj.accountBalance = (double)reader[4];
                getAccountDetailsObj.accountCreationDate = (DateTime)reader[5];
                getAccountDetailsObj.branchId = (int)reader[6];
            }
            else
            {
                connect.Close();
                reader.Close();
                throw new Exception("The Account ID and Customer ID you entered returned no Accounts. Please try again.");
            }
            connect.Close();
            reader.Close();
            return getAccountDetailsObj;

            throw new NotImplementedException();
        }
    }
}
