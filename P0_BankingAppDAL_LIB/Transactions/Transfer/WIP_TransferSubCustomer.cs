using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Transactions.Transfer
{
    public class WIP_TransferSubCustomer : TransferBase
    {
        // add transaction record
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");

        public override string Transfer()
        {
            throw new System.NotImplementedException();
        }
    }
}
