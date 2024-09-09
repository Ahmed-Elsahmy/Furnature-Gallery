using AutoMapper; // Ensure AutoMapper is being used
using ITI_Project.BLL.ModelVM;
using ITI_Project.BLL.Services.Interface;
using ITI_Project.DAL.Entites;
using ITI_Project.DAL.Repo.Interface;
using System;
using System.Collections.Generic;

namespace ITI_Project.BLL.Services.Implementation
{
    public class VendorService : IVendorService
    {
        private readonly IVendorRepo _vendorRepo;
        private readonly IMapper _mapper;

        public VendorService(IVendorRepo vendorRepo, IMapper mapper) // Inject IMapper
        {
            _vendorRepo = vendorRepo;
            _mapper = mapper; // Initialize IMapper
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return _vendorRepo.GetAllVendors();
        }

        public Vendor GetVendorById(int id)
        {
            return _vendorRepo.GetVendorById(id);
        }

        public bool AddVendor(CreateVendorVM vendorVM)
        {
            try
            {
               
                var vendorEntity = _mapper.Map<Vendor>(vendorVM);

                
                return _vendorRepo.AddVendor(vendorEntity);
            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool DeleteVendor(int id)
        {
            try
            {
                
                _vendorRepo.DeleteVendor(id);
                return true;
            }
            catch (Exception ex)
            {
                
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public bool UpdateVendor(Vendor vendor)
        {
            // This method is not yet implemented, but it should call the repo to update the vendor
            throw new NotImplementedException();
        }
    }
}
