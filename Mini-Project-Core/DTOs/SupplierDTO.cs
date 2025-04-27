using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mini_Project_Core.DTOs
{
    public class SupplierDTO
    {
        public string? CompanyCode { get; set; }
        [Required(ErrorMessage = "Supplier Name is required.")]
        public string CompanyName { get; set; } = null!;
        [Required(ErrorMessage = "Telephone Number is required.")]
        public string TelephoneNumber { get; set; } = null!;
        
    }
}
