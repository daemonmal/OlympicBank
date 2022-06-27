using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class GetAccountBalanceSingle
    {

        // used by admin to get account balance given account ID only
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");
        public decimal GetAccountBalance(int p_accountId)
        {
            SqlCommand cmdGetAccountBalance = new SqlCommand("select accountBalance from bankAccounts where accountId=@accId", connect);
            cmdGetAccountBalance.Parameters.AddWithValue("@accId", p_accountId);
            connect.Open();
            decimal balance = (decimal)cmdGetAccountBalance.ExecuteScalar();
            connect.Close();
            return balance;
        }
    }
}
