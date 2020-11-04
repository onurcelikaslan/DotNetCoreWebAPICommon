using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework.Contexts
{
    public class DatabaseContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString: @"Server=(localdb)\ProjectsV13; initial catalog=northwind; integrated security=true; Column Encryption Setting = enabled;");
        }

        //public DbSet<Product> Products { get; set; }
    }
}
