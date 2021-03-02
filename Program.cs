using System;
using System.Data;
using Microsoft.Extensions.Configuration;

using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using BankApplication.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Hosting.Builder;
using Org.BouncyCastle.Crypto.Tls;


using System.Collections.Generic;
using System.Linq;
using System.Web;
using BankApplication.Controllers;
using Microsoft.CodeAnalysis;
using Microsoft.EntityFrameworkCore;

namespace BankApplication
{
    public class BankApplication
    {
        public static void Main()
        {
            using (var ctx = new jrtestdataContext())
            {
                var user = ctx.Users
                         .AsNoTracking()
                         .Where(u => u.UsersPkid == 1)
                         .FirstOrDefault();
                Console.WriteLine($"User with id 1 First Name: {user.FistName}");
            }
            
        }
    } 
}