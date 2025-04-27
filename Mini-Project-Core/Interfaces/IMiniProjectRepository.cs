using Mini_Project_Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project_Core.Interfaces
{
    public interface IMiniProjectRepository
    {
        Task<IEnumerable<Supplier>> GetAllSuppliersAsync();
        Task<IEnumerable<Supplier>> GetSupplierByNameAsync(string companyName);
        Task AddSupplierAsync(SupplierDTO supplierDTO);
    }
}
