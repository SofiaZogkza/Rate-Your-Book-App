using RateYourBook.Types;
using System.Data.Entity;

namespace Services
{
    public class BookDbContext : DbContext
    {
        public DbSet<Books> Book { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<Evaluations> Evaluation { get; set; }
    }


    // 1) PM> enable-migrations
    // 2) PM> add-migration Initial
    // 3) a) PM> update-database -script --> Creates a script in order you to run it and add the tables to DB
    //    b) PM> update-database -verbose
    // PM> add-migration --> in case i want to make a change in schema
    // PM> update-database -verbose
}
