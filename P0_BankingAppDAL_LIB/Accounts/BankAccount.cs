using System;

namespace P0_BankingAppDAL_LIB.Accounts
{
    public enum AccountType
    {
        Checking,
        Savings,
        Loan
    }
    public class BankAccount
    {
        public int accountId { get; set; }
        public int customerId { get; set; }
        public string accountType { get; set; }
        public decimal accountBalance { get; set; }
        public DateTime accountCreationDate { get; set; }
        public int branchId { get; set; }

    }
}
