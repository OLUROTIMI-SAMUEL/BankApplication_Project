using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Interfaces
{
    public interface IValidation
    {
        bool ValidateName(string name);
        bool ValidatePassword(string password);
        bool ValidateEmail(string email);
        
    }
}
