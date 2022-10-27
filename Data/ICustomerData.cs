using BankApp.Models;

namespace BankApp.Data
{
    public interface ICustomerData
    {
        bool AddCustomer(CustomerModel customerModel);
        List<CustomerModel> GetAllCustomer();
        CustomerModel GetCustomerByEmail(string email);
        int LastId();
    }
}
