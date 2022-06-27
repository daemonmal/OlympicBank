using System.Data.SqlClient;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public class NewBankAccount
    {
        SqlConnection connect = new SqlConnection("server=localhost\\TRAINING;database=userAccountDB; Integrated Security=True");

        public string AddBankAccount(BankAccount p_newUserAccountObj)
        {
            SqlCommand cmdAddAccount = new SqlCommand("insert into bankAccounts (customerId,accountType,accountBalance,branchId) values(@cusId," +
                "@accType,@accBal,@branchId)", connect);
            cmdAddAccount.Parameters.AddWithValue("@cusId", p_newUserAccountObj.customerId);
            cmdAddAccount.Parameters.AddWithValue("@accType", p_newUserAccountObj.accountType);
            cmdAddAccount.Parameters.AddWithValue("@accBal", p_newUserAccountObj.accountBalance);
            cmdAddAccount.Parameters.AddWithValue("@branchId", p_newUserAccountObj.branchId);
            connect.Open();
            int accountsAdded = cmdAddAccount.ExecuteNonQuery();
            connect.Close();
            return "Account Added Succesfully";
        }
    }
}
