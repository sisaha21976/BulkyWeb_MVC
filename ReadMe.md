# Project Steps and Guides

## Connecting to Database (creating it if not present)
1. Adding the dependencies via nuget packages
    . entity-core
    . entity-tool
    . sqlserver

2. Adding the connection string in `appsettings.json`
```
    "ConnectionStrings": {
        "DefaultConnection": "Server=HYL-067451\\SQL2K19;Database=Bulky;User Id=sa;Password=wstinol;Trusted_Connection=False;TrustServerCertificate=True"
    }
```
3. Creating a DBContext class, name does not matter, it should inherit from DbContext
```
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
```
4. Updating the ``` program.cs ``` file , to register the database.

```
//register everything here, this is similar to spring boot start class, where we can have all the configurations done
//adding the DB Context
/*
 * pass the which option we wanna select (UseSqlServer will signify that we wann use sql server
 * inside that we are basically retrieving the connectionString named DefaultConnection from connectionStrings
 */
builder.Services.AddDbContext<ApplicationDbContext>(options=>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

```
5. Run the ``` update-database ``` command in nuget console.

## Creating Tables using entity framework

1. Create a folder, inside that create the entity. (Be mindful of the annotation required)

```
public class Category
    {

        //key annotation similar to @Id
        [Key]
        public int Id { get; set; }
        
        //required is non-nullable data field
        [Required]
        public string Name { get; set; }
        public int Displayorder { get; set; }

        public Category()
        {

        }
        

        public Category(int id, string name, int displayorder)
        {
            Id = id;
            Name = name;
            Displayorder = displayorder;
        }
    }
```

2. Register it in your ```DbContext``` class.
```
//this will create the migration code for the given entity in the DbSet generic type
public DbSet<Category> Categories { get; set; }

```
3. Run the ``` add-migration AddCategoryTable ``` command in PM
4. This will create new code in a migration folder in a new class, this is handled by entity framework
5. Run ` update-database ` command to update all the migration in the Database 
Output will look like below :
```
PM> update-database
Build started...
Build succeeded.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (17ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (16ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT 1
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (0ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT OBJECT_ID(N'[__EFMigrationsHistory]');
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      SELECT [MigrationId], [ProductVersion]
      FROM [__EFMigrationsHistory]
      ORDER BY [MigrationId];
Microsoft.EntityFrameworkCore.Migrations[20402]
      Applying migration '20230701044821_AddCategoryTable'.
Applying migration '20230701044821_AddCategoryTable'.
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      CREATE TABLE [Categories] (
          [Id] int NOT NULL IDENTITY,
          [Name] nvarchar(max) NOT NULL,
          [Displayorder] int NOT NULL,
          CONSTRAINT [PK_Categories] PRIMARY KEY ([Id])
      );
Microsoft.EntityFrameworkCore.Database.Command[20101]
      Executed DbCommand (2ms) [Parameters=[], CommandType='Text', CommandTimeout='30']
      INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
      VALUES (N'20230701044821_AddCategoryTable', N'7.0.8');
Done.
```

