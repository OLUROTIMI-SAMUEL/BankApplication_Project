using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Interfaces
{
    public interface IAccount
    {
        string GenerateAcctNo();
        bool CreateAccount(int userId, string accountType, double amount);
        double Balance(int userId, string accountNo);
        bool Deposit(int userId, string accountNo, double amount);
        bool Withdrawal(int userId, string accountNo, double amount);
        bool Transfer(int userId, double amount, string senderAcct, string destinationAcct);
        List<TransactionModel> GetAllTransactions(int userId, string accountNo);
    }
}
