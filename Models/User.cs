using System;
using System.Collections.Generic;

#nullable disable

namespace BankApplication.Models
{
    public partial class User
    {
        public int UsersPkid { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string FistName { get; set; }
        public string LastName { get; set; }
    }
}
