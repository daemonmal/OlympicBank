using System.Data.SqlClient;
namespace P0_BankingAppDAL_LIB.Login.Users.Status
{
    public class StatusDisableAccountSub : StatusDisableAccountBase
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public override string Disable(string p_userName)
        {
            SqlCommand cmdDisable = new SqlCommand("update userAccounts set accountIsActive=0 where userName=@uName", connect);
            cmdDisable.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            int accountsDisabled = cmdDisable.ExecuteNonQuery();
            connect.Close();

            return "Account has been Disabled";
        }
    }
}
