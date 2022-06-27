using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Update
{
    public class ChangeUserAccountPass
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");
        public string ChangePassword(string p_newPassword, string p_userName)
        {
            SqlCommand cmdNewPassword = new SqlCommand("update userAccounts set userPassword=@newPass where userName=@uName", connect);
            cmdNewPassword.Parameters.AddWithValue("@newPass", p_newPassword);
            cmdNewPassword.Parameters.AddWithValue("@uName", p_userName);
            connect.Open();
            int userAccountsUpdated = (int)cmdNewPassword.ExecuteScalar();
            connect.Close();

            if (userAccountsUpdated > 0)
            {
                return "Password changed succesfully";
            }
            return "No user accounts found with the username entered";
        }
    }
}
