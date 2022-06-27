using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class GetAccount
    {
        // used by admin to list all accounts associated with customer ID
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public List<BankAccount> GetAccountDetails(int p_customerId)
        {
            List<BankAccount> getAccountDetailsList = new List<BankAccount>();
            SqlCommand cmdGetAccountDetails = new SqlCommand("select * from bankAccounts where customerId=@cusId", connect);
            cmdGetAccountDetails.Parameters.AddWithValue("@cusId", p_customerId);
            connect.Open();
            SqlDataReader reader = cmdGetAccountDetails.ExecuteReader();

            // use foreach loop to grab all results
            // check reader[] column positions
            if (reader.Read())
            {
                getAccountDetailsList.Add(new BankAccount()
                {
                    accountId = (int)reader[0],
                    customerId = (int)reader[1],
                    accountType = reader[2].ToString(),
                    accountBalance = (decimal)reader[3],
                    accountCreationDate = (DateTime)reader[4],
                    branchId = (int)reader[5]
                });
            }
            else
            {
                reader.Close();
                connect.Close();
                throw new Exception("The Customer ID you entered is not associated with any Accounts.");
            }
            reader.Close();
            connect.Close();
            return getAccountDetailsList;
        }
    }
}
