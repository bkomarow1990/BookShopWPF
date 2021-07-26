using DAL.Entities;
using System;
using System.Data.Entity;
using System.Linq;

namespace DAL.EF
{
    public class BookShopDBContext : DbContext
    {
        // Your context has been configured to use a 'Model1' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'DAL.EF.Model1' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'Model1' 
        // connection string in the application configuration file.
        public BookShopDBContext()
            : base("name=BookShopDB")
        {
            Database.SetInitializer(new BookShopDBInitializer());
        }

         public virtual DbSet<Author> Authors { get; set; }
         public virtual DbSet<Book> Books { get; set; }
         public virtual DbSet<Department> Departments { get; set; }
         public virtual DbSet<Genre> Genres { get; set; }
         public virtual DbSet<User> Users { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<User>()
            //.HasIndex(u => u.Login)
            //.IsUnique();
            base.OnModelCreating(modelBuilder);
        }
    }

    //public class MyEntity
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //}
}