using System.Data.SqlClient;
namespace P0_BankingAppDAL_LIB.Transactions.Withdraw
{
    public class WithdrawSub : WithdrawBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override string Withdraw(int p_accountId, double p_withdrawAmount, int p_customerId)
        {
            SqlCommand cmdWithdraw = new SqlCommand("update bankAccounts set accountBalance=accountBalance-@withAmt where accountId=@accId", connect);
            cmdWithdraw.Parameters.AddWithValue("@withAmt", p_withdrawAmount);
            cmdWithdraw.Parameters.AddWithValue("@accId", p_accountId);

            SqlCommand cmdAddTransaction = new SqlCommand("insert into Transactions (transactionType,amount,fromAccountId,fromCustomerId)" +
                    " values(@tranType,@tranAmt,@fromAcc,@cusIdSend)", connect);
            cmdAddTransaction.Parameters.AddWithValue("@tranType", "Withdraw");
            cmdAddTransaction.Parameters.AddWithValue("@tranAmt", p_withdrawAmount);
            cmdAddTransaction.Parameters.AddWithValue("@fromAcc", p_accountId);
            cmdAddTransaction.Parameters.AddWithValue("@cusIdSend", p_customerId);

            connect.Open();
            int accountsUpdated = cmdWithdraw.ExecuteNonQuery();
            cmdAddTransaction.ExecuteNonQuery();
            connect.Close();

            if (accountsUpdated > 0)
            {
                return "Withdraw Successful";
            }
            return "No accounts found with this Account ID";
        }
    }
}
