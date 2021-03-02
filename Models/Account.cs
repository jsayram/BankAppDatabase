using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication.Models
{
    public partial class Account
    {
        public int UsersId { get; set; }
        public string CheckingNumber { get; set; }
        public decimal Balance { get; set; }

        public virtual User Users { get; set; }
    }
}
