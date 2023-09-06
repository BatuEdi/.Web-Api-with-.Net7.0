using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        { 
            optionsBuilder.UseSqlServer("server=EDISAN\\SQLEXPRESS;database=IndataCaseDb; integrated security=true; ;Trust Server Certificate=true");
        }
        public DbSet<Product> Products { get; set;}
        public DbSet<ApıUser> ApıUsers { get; set;}
        
    }
}
