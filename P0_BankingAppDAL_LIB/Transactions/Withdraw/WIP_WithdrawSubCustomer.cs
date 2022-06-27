using System.Data.SqlClient;
namespace P0_BankingAppDAL_LIB.Transactions.Withdraw
{
    public class WIP_WithdrawSubCustomer : WithdrawBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");

        public override string Withdraw(int p_accountId, double p_withdrawAmount)
        {
            throw new System.NotImplementedException();
        }
    }
}
