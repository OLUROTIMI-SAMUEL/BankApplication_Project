using BankApp.Data;
using BankApp.Interfaces;
using BankApp.Models;
using BankAppWinForm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Implementations
{
    public class Customer: ICustomer
    {
        private readonly IAccountData _accountData;
        private readonly IAccount _account;
        //private static int count = 1;

        public Customer(IAccount account,IAccountData accountData)
        {
            _account = account;
            _accountData = accountData;
            
        }
        
        
        public List<AccountModel> GetAllCustomerAccounts(int id, string name)
        {
            var accounts = _accountData.GetAccountsByUserId(id);
            

            var list = new List<AccountDetailsFormatModel>();
            var allAcount = _accountData.GetAccountsByUserId(id);

            if (allAcount.Count > 0)
            {
                foreach (var account in allAcount)
                {
                    list.Add(new AccountDetailsFormatModel() { Name = name, AccountNo = account.AccountNo, AccountType = account.AccountType, Balance = account.Balance });
                }
                
            }

            return (accounts != null) ? accounts:null;
            
            
        }
    }
}
