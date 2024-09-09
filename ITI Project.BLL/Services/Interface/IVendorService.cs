using ITI_Project.DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ITI_Project.BLL.ModelVM;

namespace ITI_Project.BLL.Services.Interface
{
    public interface IVendorService
    {
        IEnumerable<Vendor> GetAllVendors();
        Vendor GetVendorById(int id);
        bool AddVendor(CreateVendorVM vendor);
        bool UpdateVendor(Vendor vendor);
        bool DeleteVendor(int id);
    }
}
