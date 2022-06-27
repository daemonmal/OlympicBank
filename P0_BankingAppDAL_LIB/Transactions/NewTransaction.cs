using System;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Transactions
{
    public class NewTransaction
    {
        SqlConnection connect = new SqlConnection("server=DESKTOP-D6VGEU1\\TRAINING;database=userAccountDB; user id=bank;password=bank1234");

        // add transaction record
        public string AddTransaction(Transaction p_newTransaction)
        {
            SqlCommand cmdAddTransaction = new SqlCommand("insert into table_name values(@tranId,@tranType," +
                "@tranAmount,@fromAccId,@toAccId,getdate())", connect);
            // use sql to auto-increment tran ID
            cmdAddTransaction.Parameters.AddWithValue("@tranType", p_newTransaction.transactionType);
            cmdAddTransaction.Parameters.AddWithValue("@tranAmount", p_newTransaction.transactionAmount);
            cmdAddTransaction.Parameters.AddWithValue("@fromAccId", p_newTransaction.fromAccountId);
            cmdAddTransaction.Parameters.AddWithValue("@toAccId", p_newTransaction.toAccountId);
            //cmdAddTransaction.Parameters.AddWithValue("", p_newTransaction.transactionDate);  ---> use GETDATE() in SQL command
            //cmdAddTransaction.Parameters.AddWithValue("@sendcusId", p_newTransaction.customerId); ---> not needed
            connect.Open();
            int recordsAdded = (int)cmdAddTransaction.ExecuteScalar();
            connect.Close();
            if (recordsAdded > 0)
            {
                return "Transaction Successful";
            }
            throw new Exception("Transaction Failed");
            //return p_newTransaction.transactionAmount.ToString();
        }
    }
}
