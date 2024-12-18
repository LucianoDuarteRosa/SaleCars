using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleCars.Data;
using SaleCars.Models;

namespace SaleCars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleStatusController : ControllerBase
    {
        private readonly SaleCarsContext _context;

        public SaleStatusController(SaleCarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleStatusModel>>> GetSaleStatus()
        {
            return await _context.SaleStatus.ToListAsync();
        }

 
        [HttpGet("{id}")]
        public async Task<ActionResult<SaleStatusModel>> GetSaleStatusModel(int id)
        {
            var saleStatusModel = await _context.SaleStatus.FindAsync(id);

            if (saleStatusModel == null)
            {
                return NotFound();
            }

            return saleStatusModel;
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleStatusModel(int id, SaleStatusModel saleStatusModel)
        {
            if (id != saleStatusModel.SaleStatusId)
            {
                return BadRequest();
            }

            _context.Entry(saleStatusModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleStatusModelExists(id))
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
        public async Task<ActionResult<SaleStatusModel>> PostSaleStatusModel(SaleStatusModel saleStatusModel)
        {
            _context.SaleStatus.Add(saleStatusModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSaleStatusModel", new { id = saleStatusModel.SaleStatusId }, saleStatusModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleStatusModel(int id)
        {
            var saleStatusModel = await _context.SaleStatus.FindAsync(id);
            if (saleStatusModel == null)
            {
                return NotFound();
            }

            _context.SaleStatus.Remove(saleStatusModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleStatusModelExists(int id)
        {
            return _context.SaleStatus.Any(e => e.SaleStatusId == id);
        }
    }
}
