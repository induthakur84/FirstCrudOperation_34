using FirstCrudOperation.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstCrudOperation
{

    //DbContext or ef core act as a bridge between our C# Application and the database.

    public class ApplicationDbContext:DbContext
    {


        // here inside  DbContextOptions<ApplicationDbContext> contains

        // all the configuration that is required by ef core to work with the databse.
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }


        //get ==> it allows us to read/access the dbset value

        //set==> it allows to ef core to set value the dbset


        public DbSet<User> Userabcsd { get; set; }

       public DbSet<Product> Products { get; set; }

    }
}
