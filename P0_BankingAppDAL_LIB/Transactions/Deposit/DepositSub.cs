using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Transactions.Deposit
{
    public class DepositSub : DepositBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");
        public override string Deposit(int p_accountId, double p_depositAmount, int p_customerId)
        {

            SqlCommand cmdDeposit = new SqlCommand("update bankAccounts set accountBalance=accountBalance+@depAmt where accountId=@accId", connect);
            cmdDeposit.Parameters.AddWithValue("@depAmt", p_depositAmount);
            cmdDeposit.Parameters.AddWithValue("@accId", p_accountId);

            SqlCommand cmdAddTransaction = new SqlCommand("insert into Transactions (transactionType,amount,fromAccountId,fromCustomerId)" +
                    " values(@tranType,@tranAmt,@fromAcc,@cusIdSend)", connect);
            cmdAddTransaction.Parameters.AddWithValue("@tranType", "Deposit");
            cmdAddTransaction.Parameters.AddWithValue("@tranAmt", p_depositAmount);
            cmdAddTransaction.Parameters.AddWithValue("@fromAcc", p_accountId);
            cmdAddTransaction.Parameters.AddWithValue("@cusIdSend", p_customerId);

            connect.Open();
            int accountUpdated = cmdDeposit.ExecuteNonQuery();
            cmdAddTransaction.ExecuteNonQuery();
            connect.Close();

            if (accountUpdated > 0)
            {
                return "Deposit Succesfull";
            }
            return "No accounts found with this Account ID";
        }
    }
}
