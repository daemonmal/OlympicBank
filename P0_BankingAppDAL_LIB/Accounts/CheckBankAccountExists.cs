using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class CheckBankAccountExists
    {

        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public bool CheckIfAccountExists(int p_accountId)
        {
            SqlCommand cmdCheckAccountExists = new SqlCommand("select count(*) from bankAccounts where accountId=@accId", connect);
            cmdCheckAccountExists.Parameters.AddWithValue("accId", p_accountId);
            connect.Open();
            int queryResult = (int)cmdCheckAccountExists.ExecuteScalar();
            connect.Close();
            if (queryResult == 1)
            {
                return true; // account with this account ID exists
            }
            return false;
        }
    }
}
