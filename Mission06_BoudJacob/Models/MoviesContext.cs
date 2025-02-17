using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Mission06_BoudJacob.Models
{
    public class MoviesContext : DbContext
    {
        public MoviesContext(DbContextOptions<MoviesContext> options) : base(options) //Constructor
        {
        }

        public DbSet<Movie> Movies { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}
