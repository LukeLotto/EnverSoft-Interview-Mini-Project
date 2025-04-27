using Microsoft.AspNetCore.Mvc;
using Mini_Project_Core;
using Mini_Project_Core.DTOs;
using Mini_Project_Core.Interfaces;
using Mini_Project_Repository.Repositories;

namespace Mini_Project_API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SupplierController : ControllerBase
    {


        private readonly IMiniProjectRepository _miniProjectRepository;

        public SupplierController(IMiniProjectRepository miniProjectRepository)
        {
            _miniProjectRepository = miniProjectRepository;
        }

        [HttpGet("GetSuppliers")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSuppliers()
        {
            try
            {
                return Ok(await _miniProjectRepository.GetAllSuppliersAsync());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while getting Suppliers");
            }
        }

        [HttpGet("GetSupplierByName")]
        public async Task<ActionResult<IEnumerable<Supplier>>> GetSupplierByName(string companyName)
        {
            try
            {
                var suppliers = await _miniProjectRepository.GetSupplierByNameAsync(companyName);
                if (suppliers == null) return NotFound();

                return Ok(suppliers);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while searching for Suppliers");
            }
        }

        [HttpPost("AddSupplier")]
        public async Task<ActionResult> AddSupplier([FromBody] SupplierDTO supplier)
        {
            try
            {
                await _miniProjectRepository.AddSupplierAsync(supplier);
                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while adding the Supplier");
            }
        }
    }
}
