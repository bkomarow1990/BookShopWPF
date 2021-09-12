using AutoMapper;
using BLL.DTOs;
using BLL.Exceptions;
using DAL.Entities;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public interface IGenreService
    {
        void Add(GenreDTO genre);
        IEnumerable<GenreDTO> GetAll();
    }
    public class GenreService : IGenreService
    {
        IUnitOfWork unitOfWork;
        IRepository<Genre> genres;
        IMapper mapper;
        public GenreService()
        {
            unitOfWork = new UnitOfWork();
            genres = unitOfWork.GenreRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Genre, GenreDTO>();
                cfg.CreateMap<GenreDTO, Genre>();
            }
            );
            mapper = new Mapper(config);
        }

        public void Add(GenreDTO genre)
        {
            if (this.GetAll().Any(el => el.Name == genre.Name))
            {
                throw new GenreException("Genre is alredy exists");
            }
            genres.Insert(mapper.Map<Genre>(genre));
            unitOfWork.Save();
        }

        public IEnumerable<GenreDTO> GetAll()
        {
            return mapper.Map<IEnumerable<GenreDTO>>(genres.Get());
        }
    }
}
