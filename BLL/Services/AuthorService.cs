using AutoMapper;
using BLL.DTOs;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IAuthorService
    {
        void Add(AuthorDTO author);
        IEnumerable<AuthorDTO> GetAll();
    }
    public class AuthorService : IAuthorService
    {
        IUnitOfWork unitOfWork;
        IRepository<Author> authors;
        IMapper mapper;
        public AuthorService()
        {
            unitOfWork = new UnitOfWork();
            authors = unitOfWork.AuthorRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Author, AuthorDTO>();
                cfg.CreateMap<AuthorDTO, Author>();
            }
            );
            mapper = new Mapper(config);
        }

        public void Add(AuthorDTO author)
        {
            authors.Insert(mapper.Map<Author>(author));
        }

        public IEnumerable<AuthorDTO> GetAll()
        {
            return mapper.Map<IEnumerable<AuthorDTO>>(authors.Get());
        }
    }
}
