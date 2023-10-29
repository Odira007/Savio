using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SavioApi.Models;
using SavioApi.Models.Data;

namespace SavioApi.Data
{
    public class SavioDbContext : DbContext
    {
        public SavioDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<UserAccount> Accounts { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
    }
}