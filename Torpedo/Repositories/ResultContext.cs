using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Torpedo.Model;

namespace Torpedo.Repositories
{
    public class ResultContext : DbContext
    {
        public DbSet<Result> Results { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ServerDb;Integrated Security=True;");
        }
    }
}
