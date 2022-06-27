namespace P0_BankingAppDAL_LIB.Login.Users.Get
{
    public abstract class GetCustomerIdBase
    {
        public abstract int GetCustomerId(string p_userName);
        public abstract int GetCustomerId2(int p_accountId);
    }
}
