using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Interfaces
{
    public interface ICustomer
    {
        List<AccountModel> GetAllCustomerAccounts(int id, string name);
    }
}
