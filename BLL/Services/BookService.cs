using AutoMapper;
using BLL.DTOs;
using DAL;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IBookService
    {
        void Add(BookDTO book);
        void Update(BookDTO book);
        void Save();
        IEnumerable<BookDTO> GetAll();
    }
    public class BookService : IBookService
    {
        IUnitOfWork unitOfWork;
        IRepository<Book> books;
        IMapper mapper;
        public BookService( )
        {
            unitOfWork = new UnitOfWork();
            books = unitOfWork.BookRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>().ForMember(b=> b.Genre, opt => opt.MapFrom(src=> src.Genre))
                .ForMember( b=> b.Author, opt => opt.MapFrom(src=> src.Author))
                .ForMember(b => b.Parent_Book, opt => opt.MapFrom(src => src.Parent_Book))
                .ForMember(b => b.Department, opt => opt.MapFrom(src => src.Department))
                ; 
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<Department, DepartmentDTO>();

                cfg.CreateMap<BookDTO, Book>();
                cfg.CreateMap<GenreDTO, Genre>();
                cfg.CreateMap<AuthorDTO, Author>();
                cfg.CreateMap<DepartmentDTO, Department>();
            }
            );
            mapper = new Mapper(config);
        }

        public void Add(BookDTO book)
        {
            books.Insert(mapper.Map<Book>(book));
            unitOfWork.Save();
        }

        public IEnumerable<BookDTO> GetAll()
        {
            return mapper.Map<IEnumerable<BookDTO>>(books.Get());
        }

        public void Save()
        {
            unitOfWork.Save();
        }

        public void Update(BookDTO book)
        {
            unitOfWork.BookRepository.Update(mapper.Map<Book>(book));
        }
    }
}
