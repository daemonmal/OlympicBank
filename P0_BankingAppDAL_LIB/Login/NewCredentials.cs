using P0_BankingAppDAL_LIB.Login.Users;
using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login
{
    public class NewCredentials
    {
        // assign new credentials to a new customer
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public string AddUserCredentials(Credentials p_newCredentials)
        {
            SqlCommand cmdNewCredentials = new SqlCommand("insert into userAccounts (userName, userPassword) values(@uName,@uPass)", connect);
            cmdNewCredentials.Parameters.AddWithValue("@uName", p_newCredentials.userName);
            cmdNewCredentials.Parameters.AddWithValue("@uPass", p_newCredentials.userPassword);
            connect.Open();
            int recordsAdded = cmdNewCredentials.ExecuteNonQuery();
            connect.Close();

            if (recordsAdded > 0)
            {
                return "User Account Added Succesfully";
            }
            return "User was not added. Please try again.";
        }
    }
}
