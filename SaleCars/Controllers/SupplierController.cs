using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleCars.Data;
using SaleCars.Models;

namespace SaleCars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private readonly SaleCarsContext _context;

        public SupplierController(SaleCarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SupplierModel>>> GetSuppliers()
        {
            return await _context.Suppliers.ToListAsync();
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<SupplierModel>> GetSupplierModel(int id)
        {
            var supplierModel = await _context.Suppliers.FindAsync(id);

            if (supplierModel == null)
            {
                return NotFound();
            }

            return supplierModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSupplierModel(int id, SupplierModel supplierModel)
        {
            if (id != supplierModel.SupplierId)
            {
                return BadRequest();
            }

            _context.Entry(supplierModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SupplierModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        [HttpPost]
        public async Task<ActionResult<SupplierModel>> PostSupplierModel(SupplierModel supplierModel)
        {
            _context.Suppliers.Add(supplierModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSupplierModel", new { id = supplierModel.SupplierId }, supplierModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSupplierModel(int id)
        {
            var supplierModel = await _context.Suppliers.FindAsync(id);
            if (supplierModel == null)
            {
                return NotFound();
            }

            _context.Suppliers.Remove(supplierModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SupplierModelExists(int id)
        {
            return _context.Suppliers.Any(e => e.SupplierId == id);
        }
    }
}
