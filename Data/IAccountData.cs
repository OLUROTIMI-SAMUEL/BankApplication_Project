using BankApp.Models;

namespace BankApp.Data
{
    public interface IAccountData
    {
        bool InsertAccount(AccountModel accountModel);
        List<AccountModel> GetAllAccounts();
        List<AccountModel> GetAccountsByUserId(int id);
        AccountModel GetAccountByAccountNo(string accountNo);
        AccountModel GetAccountByUserIdAndAccountNo(int id, string accountNo);
        List<string> GetAllAccountNo();
        bool UpdateAccount(string accountNo, AccountModel accountModel);

    }
}
