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
    }
}
