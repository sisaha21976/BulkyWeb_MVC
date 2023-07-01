using Bulky_Web.Models;
using Microsoft.EntityFrameworkCore;

namespace Bulky_Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        /*
         here we will pass the DbcontextOption while creating the object of applicationDbContext, and : base(option) will
         pass the same parameters to the parent as well  .i.e. DbContext
         */
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //this will create the migration code for the given entity in the DbSet generic type
        public DbSet<Category> Categories { get; set; }
    }
}
