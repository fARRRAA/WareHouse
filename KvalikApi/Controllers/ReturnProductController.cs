using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReturnProductController : ControllerBase
    {
        private readonly ContextDb _context;

        public ReturnProductController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/ReturnProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReturnProduct>>> GetReturnProducts()
        {
            return await _context.ReturnProduct.Include(rp => rp.product).ToListAsync();
        }

        // GET: api/ReturnProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReturnProduct>> GetReturnProduct(int id)
        {
            var returnProduct = await _context.ReturnProduct
                .Include(rp => rp.product)
                .FirstOrDefaultAsync(rp => rp.id == id);

            if (returnProduct == null)
            {
                return NotFound();
            }

            return returnProduct;
        }

        // PUT: api/ReturnProduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReturnProduct(int id, ReturnProductRequest returnProductRequest)
        {
            var returnProduct = await _context.ReturnProduct.FindAsync(id);
            if (returnProduct == null)
            {
                return NotFound();
            }

            returnProduct.productId = returnProductRequest.productId;
            returnProduct.returnType = returnProductRequest.returnType;
            returnProduct.reason = returnProductRequest.reason;
            returnProduct.date = returnProductRequest.date;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReturnProductExists(id))
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

        // POST: api/ReturnProduct
        [HttpPost]
        public async Task<ActionResult<ReturnProduct>> PostReturnProduct(ReturnProductRequest returnProductRequest)
        {
            var returnProduct = new ReturnProduct
            {
                productId = returnProductRequest.productId,
                returnType = returnProductRequest.returnType,
                reason = returnProductRequest.reason,
                date = returnProductRequest.date
            };

            _context.ReturnProduct.Add(returnProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReturnProduct", new { id = returnProduct.id }, returnProduct);
        }

        // DELETE: api/ReturnProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReturnProduct(int id)
        {
            var returnProduct = await _context.ReturnProduct.FindAsync(id);
            if (returnProduct == null)
            {
                return NotFound();
            }

            _context.ReturnProduct.Remove(returnProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReturnProductExists(int id)
        {
            return _context.ReturnProduct.Any(e => e.id == id);
        }
    }
}