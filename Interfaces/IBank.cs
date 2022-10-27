using BankApp.Implementations;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Interfaces
{
    public interface IBank
    {
        bool NewCustomer(int id, string firstname, string lastname, string email, string password);
        //CustomerModel Login(string email, string password);
        CustomerModel? Login(string email, string password);
    }
}
