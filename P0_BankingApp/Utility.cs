using P0_BankingAppDAL_LIB.Accounts;
using P0_BankingAppDAL_LIB.Transactions;
using P0_BankingAppDAL_LIB.Transactions.Get;
using System;
using System.Collections.Generic;
using System.Text;

namespace P0_BankingApp
{
    public class Utility
    {
        GetAccount getBankAccountDetailsObj = new GetAccount();
        GetTransactionSubLastTen getLastTenTransactions = new GetTransactionSubLastTen();

        public StringBuilder GenerateBankAccountTable(int p_customerId)
        {

            // output in table format
            List<BankAccount> listBankAccountBalancesObj = getBankAccountDetailsObj.GetAccountDetails(p_customerId);

            var sb = new StringBuilder();
            sb.Append(string.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10}\n\n",
                "Account ID", "Customer ID", "Balance", "Account Type", "Creation Date", "Branch ID"));

            for (int index = 0; index <= listBankAccountBalancesObj.Count; index++)
            {
                sb.Append(string.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10}\n", listBankAccountBalancesObj[index], listBankAccountBalancesObj[index], listBankAccountBalancesObj[index],
                    listBankAccountBalancesObj[index], listBankAccountBalancesObj[index], listBankAccountBalancesObj[index]));
            }

            return sb;
        }

        public StringBuilder TransactionTableLast10(int p_customerId)
        {
            // output in table format
            List<Transaction> listLastTenTransactionsObj = getLastTenTransactions.GetTransactionHistory(p_customerId);

            var sb = new StringBuilder();
            sb.Append(string.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10} {6,25}\n\n",
                "Transaction ID", "Type", "Amount", "From Account ID", "To Account ID", "Date"));

            for (int index = 0; index <= listLastTenTransactionsObj.Count; index++)
            {
                sb.Append(string.Format("{0,15} {1,15} {2,15} {3,15} {4,15} {5,10},{6,25}\n", listLastTenTransactionsObj[index], listLastTenTransactionsObj[index], listLastTenTransactionsObj[index],
                    listLastTenTransactionsObj[index], listLastTenTransactionsObj[index], listLastTenTransactionsObj[index]));
            }

            return sb;
        }

        public void Banner()
        {
            Console.ForegroundColor = System.ConsoleColor.DarkGreen;
            Console.WriteLine(@" ▄▄▄▄▄▄▄ ▄▄▄     ▄▄   ▄▄ ▄▄   ▄▄ ▄▄▄▄▄▄▄ ▄▄▄ ▄▄▄▄▄▄▄    ▄▄▄▄▄▄▄ ▄▄▄▄▄▄ ▄▄    ▄ ▄▄▄   ▄ 
█       █   █   █  █ █  █  █▄█  █       █   █       █  █  ▄    █      █  █  █ █   █ █ █
█   ▄   █   █   █  █▄█  █       █    ▄  █   █       █  █ █▄█   █  ▄   █   █▄█ █   █▄█ █
█  █ █  █   █   █       █       █   █▄█ █   █     ▄▄█  █       █ █▄█  █       █      ▄█
█  █▄█  █   █▄▄▄█▄     ▄█       █    ▄▄▄█   █    █     █  ▄   ██      █  ▄    █     █▄ 
█       █       █ █   █ █ ██▄██ █   █   █   █    █▄▄   █ █▄█   █  ▄   █ █ █   █    ▄  █
█▄▄▄▄▄▄▄█▄▄▄▄▄▄▄█ █▄▄▄█ █▄█   █▄█▄▄▄█   █▄▄▄█▄▄▄▄▄▄▄█  █▄▄▄▄▄▄▄█▄█ █▄▄█▄█  █▄▄█▄▄▄█ █▄█
");
            Console.ResetColor();
        }
    }
}
