using System.Data.SqlClient;
namespace P0_BankingAppDAL_LIB.Transactions.Deposit
{
    public class WIP_DepositSubCustomer : DepositBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");
        public override string Deposit(int p_accountId)
        {

            throw new System.NotImplementedException();
        }
    }
}
