using System.Data.SqlClient;
namespace P0_BankingAppDAL_LIB.Login.Users.Status
{
    public class StatusEnableAccountSub : StatusEnableAccountBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override string Enable(string p_userName)
        {
            SqlCommand cmdEnable = new SqlCommand("update userAccounts set accountIsActive=1 where userName=@uName", connect);
            cmdEnable.Parameters.AddWithValue("@uName", p_userName);

            SqlCommand cmdResetLoginAttempts = new SqlCommand("update userAccounts set loginAttempts=0 where userName=@uName", connect);
            cmdResetLoginAttempts.Parameters.AddWithValue("@uName", p_userName);

            connect.Open();
            int accountsDisabled = cmdEnable.ExecuteNonQuery();
            cmdResetLoginAttempts.ExecuteNonQuery();
            connect.Close();

            if (accountsDisabled == 0)
            {
                return "Account has been Disabled";
            }
            return "Incorrect Account Username";

        }
    }
}
