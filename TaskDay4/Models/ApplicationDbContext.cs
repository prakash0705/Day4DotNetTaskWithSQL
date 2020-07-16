using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace TaskDay4.Models
{
    class ApplicationDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer("Data Source=APINP-ELPT92443;user id=sa;password=Prakashkumaran7;database=UserDB");
        }
        public DbSet<User> Users { get; set; }
    }
}
