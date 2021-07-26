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
    public interface IDepartmentService
    {
        void Add(DepartmentDTO genre);
        IEnumerable<DepartmentDTO> GetAll();
    }
    public class DepartmentService : IDepartmentService
    {
        IUnitOfWork unitOfWork;
        IRepository<Department> departments;
        IMapper mapper;
        public DepartmentService()
        {
            unitOfWork = new UnitOfWork();
            departments = unitOfWork.DepartmentRepository;
            IConfigurationProvider config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Department, DepartmentDTO>();
                cfg.CreateMap<DepartmentDTO, Department>();
            }
            );
            mapper = new Mapper(config);
        }

        public void Add(DepartmentDTO department)
        {
            departments.Insert(mapper.Map<Department>(department));
        }

        public void Add(Department genre)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DepartmentDTO> GetAll()
        {
            return mapper.Map<IEnumerable<DepartmentDTO>>(departments.Get());
        }

    }
}
