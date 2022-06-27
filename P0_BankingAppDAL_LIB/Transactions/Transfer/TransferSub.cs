using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Transactions.Transfer
{
    public class TransferSub : TransferBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override string Transfer(int p_accountIdRecieve, int p_customerIdRec, int p_accountIdSend, int p_customerIdSend, double p_transferAmount)
        {
            SqlCommand cmdTransferSend = new SqlCommand("update bankAccounts set accountBalance=accountBalance-@transAmt where accountId=@sendAccId", connect);
            cmdTransferSend.Parameters.AddWithValue("@transAmt", p_transferAmount);
            cmdTransferSend.Parameters.AddWithValue("@sendAccId", p_accountIdSend);

            SqlCommand cmdTransferRecieve = new SqlCommand("update bankAccounts set accountBalance=accountBalance+@transAmt where accountId=@recAccId", connect);
            cmdTransferRecieve.Parameters.AddWithValue("@transAmt", p_transferAmount);
            cmdTransferRecieve.Parameters.AddWithValue("@recAccId", p_accountIdRecieve);

            SqlCommand cmdAddTransaction = new SqlCommand("insert into Transactions (transactionType,amount,toAccountId,toCustomerId,fromAccountId,fromCustomerId)" +
                " values(@tranType,@tranAmt,@fromAcc,@cusIdSend,@toAcc,@cusIdRec)", connect);
            cmdAddTransaction.Parameters.AddWithValue("@tranType", "Transfer");
            cmdAddTransaction.Parameters.AddWithValue("@tranAmt", p_transferAmount);
            cmdAddTransaction.Parameters.AddWithValue("@fromAcc", p_accountIdSend);
            cmdAddTransaction.Parameters.AddWithValue("@cusIdSend", p_customerIdSend);
            cmdAddTransaction.Parameters.AddWithValue("@toAcc", p_accountIdRecieve);
            cmdAddTransaction.Parameters.AddWithValue("@cusIdRec", p_customerIdRec);

            connect.Open();
            int accountsSent = cmdTransferSend.ExecuteNonQuery();
            int accountsRecieved = cmdTransferRecieve.ExecuteNonQuery();
            cmdAddTransaction.ExecuteNonQuery();
            connect.Close();

            if (accountsSent > 0 && accountsRecieved > 0)
            {
                return "Funds Transfered Succesfully";
            }
            else if (accountsRecieved == 0)
            {
                return "Transfer failed. No accounts found for the recieving account ID";
            }
            else if (accountsSent == 0)
            {
                return "Transfer failed. No accounts found for the sending account Id";
            }
            return "Transfer Failed";
        }
    }
}
