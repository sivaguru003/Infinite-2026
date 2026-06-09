using System.Collections.Generic;
using System.Data.Entity;

namespace WebApiDemo.Models
{
    public class CountryContext : DbContext
    {
         public CountryContext() : base("MyConnection")
        {
        }
         public DbSet<Country> Countries { get; set; }
    }
}