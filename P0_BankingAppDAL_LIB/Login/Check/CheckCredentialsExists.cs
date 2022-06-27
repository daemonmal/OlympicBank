using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    public class CheckCredentialsExists
    {
        // used at login to check if username exists before validating credentials
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public bool CheckIfCredentialsExists(string p_userName)
        {
            SqlCommand cmdCheckCredentialsExist = new SqlCommand("select count(*) from userAccounts where userName=@uName", connect);
            cmdCheckCredentialsExist.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            int queryResult = (int)cmdCheckCredentialsExist.ExecuteScalar();
            connect.Close();
            if (queryResult == 1)
            {
                return true; // user name exist in database
            }
            return false;
        }
    }
}
