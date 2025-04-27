using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Mini_Project_Core;
using Mini_Project_Core.Interfaces;
using Mini_Project_Repository.Data;
using Microsoft.EntityFrameworkCore;
using Mini_Project_Core.DTOs;

namespace Mini_Project_Repository.Repositories
{
    public class SupplierRepository: IMiniProjectRepository
    {
        private readonly MiniProjectDbContext _context;

        public SupplierRepository(MiniProjectDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Supplier>> GetAllSuppliersAsync()
        {
            try
            {
                return await _context.Suppliers.ToListAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while getting Suppliers", ex);
            }
        }

        public async Task<IEnumerable<Supplier>> GetSupplierByNameAsync(string companyName)
        {
            try
            {
                return await _context.Suppliers.Where(s => s.CompanyName.Contains(companyName))
                .ToListAsync();
            }
            catch (Exception ex) {
                throw new Exception("An error occurred while searching for Suppliers", ex);
            }
        }

        public async Task AddSupplierAsync(SupplierDTO supplierDTO)
        {
            try
            {
                Supplier supplier = new Supplier();
                supplier.TelephoneNumber = supplierDTO.TelephoneNumber;
                supplier.CompanyName = supplierDTO.CompanyName;
                supplier.CompanyCode = supplierDTO.CompanyCode;
                await _context.Suppliers.AddAsync(supplier);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex) {
                throw new Exception("An error occurred while adding the supplier", ex);
            }
        }
    }
}
