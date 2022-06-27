namespace P0_BankingAppDAL_LIB.Accounts
{
    public abstract class GetBankAccountBase
    {

        public abstract BankAccount GetAccountDetails(int p_customerId);
    }
}