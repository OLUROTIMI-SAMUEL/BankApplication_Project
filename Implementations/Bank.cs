using BankApp.Data;
using BankApp.Interfaces;
using BankApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BankApp.Implementations
{
    public class Bank : IBank
    {
    
        private readonly ICustomerData _customerData;
        private readonly ICustomer _customer;
        private readonly CustomerModel customerModel;

        public Bank(ICustomerData customerData, ICustomer customer)
        {
            _customerData = customerData;
            _customer = customer;   
        }
        public CustomerModel? Login(string email, string password)
        {
            var customer = _customerData.GetCustomerByEmail(email);

            return customer.Password == password ? customer : null;
        }

        public bool NewCustomer(int id, string firstname, string lastname, string email, string password)
        {
            var cust = new CustomerModel();
            cust.UserId = id;
            cust.Name = firstname + " "+ lastname;
            cust.Email = email;
            cust.Password = password;
            var added = _customerData.AddCustomer(cust);
            
            return added? added : false;
            
        }
    }
}
