using DAL.EF;
using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public interface IUnitOfWork
    {
        void Save();
        GenericRepository<Author> AuthorRepository { get; }
        GenericRepository<Book> BookRepository { get; }
        GenericRepository<Department> DepartmentRepository { get; }
        GenericRepository<Genre> GenreRepository { get; }
        GenericRepository<User> UserRepository { get; }
    }
    public class UnitOfWork : IUnitOfWork, IDisposable {
        private static BookShopDBContext context = new BookShopDBContext();

        private GenericRepository<Author> authorRepository;
        private GenericRepository<Book> bookRepository;
        private GenericRepository<Department> departmentRepository;
        private GenericRepository<Genre> genreRepository;
        private GenericRepository<User> userRepository;

        public GenericRepository<Author> AuthorRepository
        {
            get {
                // Lazy loading
                if (this.authorRepository == null)
                {
                    this.authorRepository = new GenericRepository<Author>(context);
                }
                return authorRepository;
            }
        }
        public GenericRepository<Book> BookRepository
        {
            get
            {
                // Lazy loading
                if (this.bookRepository == null)
                {
                    this.bookRepository = new GenericRepository<Book>(context);
                }
                return bookRepository;
            }
        }
        public GenericRepository<Department> DepartmentRepository
        {
            get
            {
                // Lazy loading
                if (this.departmentRepository == null)
                {
                    this.departmentRepository = new GenericRepository<Department>(context);
                }
                return departmentRepository;
            }
        }
        public GenericRepository<Genre> GenreRepository
        {
            get
            {
                // Lazy loading
                if (this.genreRepository == null)
                {
                    this.genreRepository = new GenericRepository<Genre>(context);
                }
                return genreRepository;
            }
        }
        public GenericRepository<User> UserRepository
        {
            get
            {
                // Lazy loading
                if (this.userRepository == null)
                {
                    this.userRepository = new GenericRepository<User>(context);
                }
                return userRepository;
            }
        }
        public void Save() {
            context.SaveChanges();
        }
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
