using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Transactions.Get
{
    // used to get last 10 transactions associated with a customer ID given customer ID
    public class GetTransactionSubLastTen : GetTransactionsBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override List<Transaction> GetTransactionHistory(int p_customerId)
        {
            List<Transaction> lastTenTransactionsObj = new List<Transaction>();
            Transaction transactionListItemObj = new Transaction();
            SqlCommand cmdGetTransaction = new SqlCommand("select top 10 * from Transactions where customerId=@cusId order by transactionId desc", connect);
            cmdGetTransaction.Parameters.AddWithValue("@cusId", p_customerId);
            connect.Open();
            SqlDataReader reader = cmdGetTransaction.ExecuteReader();


            if (reader.Read())
            {
                lastTenTransactionsObj.Add(new Transaction()
                {
                    transactionId = (int)reader[0], // check reader[] column positions
                    transactionType = reader[1].ToString(), // check reader[] column positions
                    transactionAmount = (double)reader[2], // check reader[] column positions
                    fromAccountId = (int)reader[3], // check reader[] column positions
                    toAccountId = (int)reader[5], // check reader[] column positions                    
                    transactionDate = (DateTime)reader[7] // check reader[] column positions
                });
            }
            else
            {
                reader.Close();
                connect.Close();
                throw new Exception("No Transactions were found for your Accounts");
            }
            reader.Close();
            connect.Close();
            return lastTenTransactionsObj;
        }
    }
}
