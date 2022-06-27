namespace P0_BankingAppDAL_LIB.Accounts
{
    public abstract class GetBalanceBase
    {
        // get account balance from DB
        public abstract BankAccount GetAccountBalance(int p_accountId);
    }
}