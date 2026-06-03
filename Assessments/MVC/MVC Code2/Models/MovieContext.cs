using System.Collections.Generic;
using System.Data.Entity;

namespace MoviesMVC.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("MoviesDB")
        {
        }

        public DbSet<Movie> Movies { get; set; }
    }
}