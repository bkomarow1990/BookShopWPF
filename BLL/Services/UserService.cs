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
    public interface IUserService
    {
        void Add(UserDTO user);
        IEnumerable<UserDTO> GetAll();
    }
    public class UserService : IUserService
    {
        IUnitOfWork unitOfWork;
        IRepository<User> users;
        IMapper mapper;
        public UserService()
        {
            unitOfWork = new UnitOfWork();
            users = unitOfWork.UserRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDTO>();
                cfg.CreateMap<UserDTO, User>();
            }
            );
            mapper = new Mapper(config);
        }

        public void Add(UserDTO user)
        {
            users.Insert(mapper.Map<User>(user));
            unitOfWork.Save();
        }

        public IEnumerable<UserDTO> GetAll()
        {
            return mapper.Map<IEnumerable<UserDTO>>(users.Get());
        }
    }
}
