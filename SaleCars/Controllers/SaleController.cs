using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SaleCars.Data;
using SaleCars.Models;

namespace SaleCars.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly SaleCarsContext _context;

        public SaleController(SaleCarsContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<SaleModel>>> GetSales()
        {
            var cars = await _context.Sales
                                    .Include(sale => sale.Car)
                                    .Include(sale => sale.Client)
                                    .Include(sale => sale.User)
                                    .Include(sale => sale.SaleStatus)
                                    .ToListAsync();
            return cars;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SaleModel>> GetSaleModel(int id)
        {
            var saleModel = await _context.Sales
                                            .Include(sale => sale.Car)
                                            .Include(sale => sale.Client)
                                            .Include(sale => sale.User)
                                            .Include(sale => sale.SaleStatus)
                                            .FirstOrDefaultAsync(car => car.CarId == id);

            if (saleModel == null)
            {
                return NotFound();
            }

            return saleModel;
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutSaleModel(int id, SaleModel saleModel)
        {
            if (id != saleModel.SaleId)
            {
                return BadRequest();
            }

            _context.Entry(saleModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SaleModelExists(id))
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
        public async Task<ActionResult<SaleModel>> PostSaleModel(SaleModel saleModel)
        {
            _context.Sales.Add(saleModel);
            await _context.SaveChangesAsync();

            var car = await _context.Cars.FindAsync(saleModel.CarId);
            if (car != null)
            {
                car.CarIsSale = false;

                _context.Entry(car).Property(c => c.CarIsSale).IsModified = true;

                await _context.SaveChangesAsync();
            }
                return CreatedAtAction("GetSaleModel", new { id = saleModel.SaleId }, saleModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSaleModel(int id)
        {
            var saleModel = await _context.Sales.FindAsync(id);
            if (saleModel == null)
            {
                return NotFound();
            }

            _context.Sales.Remove(saleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SaleModelExists(int id)
        {
            return _context.Sales.Any(e => e.SaleId == id);
        }
    }
}
