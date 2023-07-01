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
        //the name of the getter setter will be name of the table
        public DbSet<Category> Categories { get; set; }

        /*
         * this method will load the data for the given type of entity while loading the entities in the table
         */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Category[] categoryArr = new Category[] { new Category { Id = 1,Name="Horror",Displayorder=1 },
            new Category { Id = 2,Name="Thriller",Displayorder=2 },
            new Category { Id = 3,Name="Action",Displayorder=3 },
            new Category { Id = 4,Name="Crime/Drama",Displayorder=4 }};
            modelBuilder.Entity<Category>().HasData(categoryArr);
        }
    }
}
