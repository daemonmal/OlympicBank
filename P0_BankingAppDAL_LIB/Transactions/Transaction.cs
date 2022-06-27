using System;

namespace P0_BankingAppDAL_LIB.Transactions
{
    public class Transaction
    {
        public enum TransactionType
        {
            Withdraw,
            Depost,
            Transfer
        }
        public int transactionId { get; set; } // sql server to add incrementer
        public string transactionType { get; set; }
        public double transactionAmount { get; set; }
        public int fromAccountId { get; set; }
        public int fromCustomerId { get; set; }
        public int toAccountId { get; set; }
        public int toCustomerId { get; set; }
        public DateTime transactionDate { get; set; }

    }
}
