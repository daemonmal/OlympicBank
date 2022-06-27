using System.Collections.Generic;

namespace P0_BankingAppDAL_LIB.Transactions.Get
{
    public abstract class GetTransactionsBase
    {
        public abstract List<Transaction> GetTransactionHistory(int p_customerId);
    }
}
