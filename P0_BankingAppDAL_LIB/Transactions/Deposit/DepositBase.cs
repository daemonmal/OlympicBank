namespace P0_BankingAppDAL_LIB.Transactions.Deposit
{
    public abstract class DepositBase
    {
        // add transaction record
        public abstract string Deposit(int p_accountId, double p_depositAmount, int p_customerId);
    }
}
