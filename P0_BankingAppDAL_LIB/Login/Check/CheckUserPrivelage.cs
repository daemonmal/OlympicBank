using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Login.Check
{
    // used by the menu method to select the right menu
    public class CheckUserPrivelage
    {
        SqlConnection connect = new SqlConnection("server=;database=accountCredentialsDB; user id=;password=");
        public bool CheckPrivelage(int p_isAdmin)
        {
            SqlCommand cmdCheckPrivelage = new SqlCommand("select count(*) from table_name where isAdmin=@chkPriv", connect);
            cmdCheckPrivelage.Parameters.AddWithValue("chkPriv", p_isAdmin);
            connect.Open();
            int privCheckResult = (int)cmdCheckPrivelage.ExecuteScalar();
            if (privCheckResult == 1)
            {
                return true; // account is admin account
            }
            return false;
        }
    }
}
