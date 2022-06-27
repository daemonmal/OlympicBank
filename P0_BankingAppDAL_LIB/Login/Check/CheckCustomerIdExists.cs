using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    public class CheckCustomerIdExists
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public bool CheckIfCustomerIdExists(int p_customerId)
        {
            SqlCommand cmdCheckAccountExists = new SqlCommand("select count(*) from userAccounts where customerId=@cusId", connect);
            cmdCheckAccountExists.Parameters.AddWithValue("cusId", p_customerId);
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
