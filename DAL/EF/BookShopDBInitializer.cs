using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.EF
{
    public class BookShopDBInitializer : CreateDatabaseIfNotExists<BookShopDBContext>
    {
        protected override void Seed(BookShopDBContext context)
        {

            base.Seed(context);

            User admin = context.Users.Add(new User { Login = "Admin", Password = "2281337"});
            context.SaveChanges();

            Author Baobab = context.Authors.Add(new Author { Name = "Baobab", Surname="Vasilenko", Fathername="Olegovich"});
            context.SaveChanges();

            Genre horror = context.Genres.Add(new Genre { Name = "Horror" });
            context.SaveChanges();

            Book book = context.Books.Add(new Book { Name = "50 kabaniv", Genre = horror, Author = Baobab, Count_Pages = 228, Public_Price = 1337, Price = 777, PublishYear = 2019 });
            context.SaveChanges();


        }
    }
}
