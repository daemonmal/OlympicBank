namespace P0_BankingAppDAL_LIB.Transactions.Withdraw
{
    public abstract class WithdrawBase
    {
        // add transaction record
        public abstract string Withdraw(int p_accountId, double p_withdrawAmount, int p_customerIdSend);
    }
}
