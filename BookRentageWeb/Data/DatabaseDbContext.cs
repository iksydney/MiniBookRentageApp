using BookRentageWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BookRentageWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Categories> Categories { get; set; }
    }
}
