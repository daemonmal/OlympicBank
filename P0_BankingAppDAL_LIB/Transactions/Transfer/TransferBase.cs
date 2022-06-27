namespace P0_BankingAppDAL_LIB.Transactions.Transfer
{
    public abstract class TransferBase
    {
        // add transaction record
        public abstract string Transfer(int p_accountIdRecieve, int p_customerIdRec, int p_accountIdSend, int p_customerIdSend, double p_transferAmount);

    }
}
