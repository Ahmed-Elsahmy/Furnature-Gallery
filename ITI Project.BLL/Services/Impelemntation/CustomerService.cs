using AutoMapper;
using ITI_Project.BLL.Helper;
using ITI_Project.BLL.ModelVM;
using ITI_Project.BLL.Services.Interface;
using ITI_Project.DAL.Entites;
using ITI_Project.DAL.Repo.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ITI_Project.BLL.Services.Impelemntation
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepo customerRepo;
        private readonly IMapper mapper;

        public CustomerService(ICustomerRepo customerRepo, IMapper mapper)
        {
            this.customerRepo = customerRepo;
            this.mapper = mapper;
        }

        public bool Create(CreateCustomerVM customer)
        {
            try
            {
                Customer new_customer = mapper.Map<Customer>(customer);
                customerRepo.Create(new_customer);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                customerRepo.Delete(id);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IEnumerable<GetCustomerVM> GetAll()
        {
            var result = customerRepo.GetAll().Where(a => a.IsDeleted == false).ToList();
            List<GetCustomerVM> newResult = mapper.Map<List<GetCustomerVM>>(result);
            return newResult;
        }

        public GetCustomerVM GetByCustomerId(int id)
        {
            Customer customer = customerRepo.GetByCustomerId(id);
            return mapper.Map<GetCustomerVM>(customer);
        }

        public bool Update(UpdateCustomerVM customer)
        {
            try
            {
                Customer new_customer = mapper.Map<Customer>(customer);     
                customerRepo.Update(new_customer);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }
    }
}
