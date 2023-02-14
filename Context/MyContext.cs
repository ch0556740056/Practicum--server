using Microsoft.EntityFrameworkCore;
using Repositories;
using Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Context
{
    public class MyContext : DbContext, IContext
    {
        public DbSet<Child> Children { get; set; }
        public DbSet<PersonalDetail> PersonalDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=databasePracticum;Trusted_Connection=True");
           
        }
    }
}
