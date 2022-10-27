using BankApp.Data;
using BankApp.Interfaces;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Implementations
{
    public class Account : IAccount
    {
        public static int Count = 0;
        private readonly IAccountData _accountData;
        private readonly AccountModel _accountModel;
        private readonly TransactionModel _transactions;
        
        public  Account(IAccountData accountData)
        {
            _accountData = accountData;
            _accountModel = new AccountModel();
            _transactions = new TransactionModel();

        }

        public bool CreateAccount(int userId, string accountType, double amount)
        {
            try
            {


                var listTrans = new List<TransactionModel>();
                _accountModel.AccountNo = GenerateAcctNo();
                _accountModel.AccountType = accountType;
                _accountModel.Balance = amount;
                _accountModel.userId = userId;
                var trans = AddTransactions(amount, amount, "First deposit");
                listTrans.Add(trans);
                _accountModel.TransactionList = listTrans;
                //_accountModel.TransactionList.Add(trans);

                _accountData.InsertAccount(_accountModel);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }

        private TransactionModel AddTransactions(double balance, double amount, string description)
        {
            string date = DateTime.Now.Day + "/" + DateTime.Now.Month + "/" + DateTime.Now.Year;
            try
            {




                _transactions.Date = date;
                _transactions.Balance = balance;
                _transactions.Amount = amount;
                _transactions.Description = description;
            }
            catch(ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return _transactions;
        }
        public double Balance(int userId, string accountNo)
        {
            var acct = _accountData.GetAccountByUserIdAndAccountNo(userId, accountNo);
            if(acct != null) return acct.Balance;
            return 0;
        }

        public bool Deposit(int userId, string accountNo, double amount)
        {
            var acct = _accountData.GetAccountByUserIdAndAccountNo(userId, accountNo);
            if(acct != null)
            {
                try
                {


                    if (acct.Balance <= 0) return false;
                    acct.Balance += amount;
                    var trans = AddTransactions(acct.Balance, amount, "Credit Alert!");
                    acct.TransactionList.Add(trans);
                    _accountData.UpdateAccount(acct.AccountNo, acct);
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return true;
            }

            return false;
        }

        public string GenerateAcctNo()
        {
            var acctNo = "0";
            var str = "1234567890";
            var lsAcct = _accountData.GetAllAccountNo();
            Random rd = new Random();
            for (int i = 0; i < 9; i++)
            {
                int rand_num = rd.Next(0, str.Length - 1);
                acctNo += str[rand_num];
            }
            if(lsAcct != null)
            {
                while (lsAcct.Contains(acctNo))
                {
                    for (int i = 0; i < 9; i++)
                    {
                        int rand_num = rd.Next(0, str.Length - 1);
                        acctNo += str[rand_num];
                    }
                }
            }
            
            return acctNo;
        }


        public List<TransactionModel> GetAllTransactions(int userId, string accountNo)
        {
            var acct = _accountData.GetAccountByUserIdAndAccountNo(userId, accountNo);
            if( acct != null)
            {
                return acct.TransactionList;
            }
            return null;
        }
        public bool Transfer(int userId, double amount, string senderAcct, string destinationAcct)
        {
            try
            {


                var senderAcc = _accountData.GetAccountByUserIdAndAccountNo(userId, senderAcct);
                var destAcc = _accountData.GetAccountByAccountNo(destinationAcct);
                if (senderAcc == null || destAcc == null) return false;
                if (senderAcc.Balance < amount || (senderAcc.Balance - amount < 1000 && senderAcc.AccountType == "Savings")) return false;
                senderAcc.Balance -= amount;
                destAcc.Balance += amount;

                var trans = AddTransactions(senderAcc.Balance, amount, "Transfer of " + amount + " to " + destinationAcct);
                senderAcc.TransactionList.Add(trans);
                _accountData.UpdateAccount(senderAcc.AccountNo, senderAcc);

                var trans2 = AddTransactions(destAcc.Balance, amount, "Transfer from " + senderAcct);
                destAcc.TransactionList.Add(trans2);
                _accountData.UpdateAccount(destAcc.AccountNo, destAcc);
            }
            catch(NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return true;
        }
        public bool Withdrawal(int userId, string accountNo, double amount)
        {
            var acct = _accountData.GetAccountByUserIdAndAccountNo(userId, accountNo);
            if(acct != null)
            {
                if ((acct.Balance - amount < 1000 && acct.AccountType == "Savings") || acct.Balance - amount < 0)
                {
                    return false;
                }
                try
                {


                    acct.Balance -= amount;
                    var trans = AddTransactions(acct.Balance, amount, "Debit Alert!");
                    acct.TransactionList.Add(trans);
                    _accountData.UpdateAccount(acct.AccountNo, acct);
                }
                catch(NullReferenceException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return true;
            }
            return false;
        }
    }
}
