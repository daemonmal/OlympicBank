using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    public class CheckUserExists
    {
        // used when viewing account details by admin and adding new customer account

        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public bool CheckIfUserExists(int p_customerId)
        {
            SqlCommand cmdCheckUserExists = new SqlCommand("select count(*) from userAccounts where customerId=@cusId", connect);
            cmdCheckUserExists.Parameters.AddWithValue("@cusId", p_customerId);
            connect.Open();
            int queryResult = (int)cmdCheckUserExists.ExecuteScalar();
            connect.Close();
            if (queryResult == 1)
            {
                return true; // user with this customerId exists
            }
            return false;
        }
    }
}
