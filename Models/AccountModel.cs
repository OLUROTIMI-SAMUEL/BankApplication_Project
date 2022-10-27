using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Models
{
    public class AccountModel
    {
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public double Balance { get; set; }
        public int userId { get; set; }
        public List<TransactionModel> TransactionList { get; set; }
    }
}
