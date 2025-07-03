using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryProductController : ControllerBase
    {
        private readonly ContextDb _context;

        public DeliveryProductController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/DeliveryProduct
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DeliveryProduct>>> GetDeliveryProducts()
        {
            return await _context.DeliveryProduct
                .Include(dp => dp.product)
                .Include(dp => dp.delivery)
                .ToListAsync();
        }

        // GET: api/DeliveryProduct/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DeliveryProduct>> GetDeliveryProduct(int id)
        {
            var deliveryProduct = await _context.DeliveryProduct
                .Include(dp => dp.product)
                .Include(dp => dp.delivery)
                .FirstOrDefaultAsync(dp => dp.id == id);

            if (deliveryProduct == null)
            {
                return NotFound();
            }

            return deliveryProduct;
        }

        // PUT: api/DeliveryProduct/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDeliveryProduct(int id, DeliveryProductRequest deliveryProductRequest)
        {
            var deliveryProduct = await _context.DeliveryProduct.FindAsync(id);
            if (deliveryProduct == null)
            {
                return NotFound();
            }

            deliveryProduct.productId = deliveryProductRequest.productId;
            deliveryProduct.deliveryId = deliveryProductRequest.deliveryId;
            deliveryProduct.count = deliveryProductRequest.count;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryProductExists(id))
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

        // POST: api/DeliveryProduct
        [HttpPost]
        public async Task<ActionResult<DeliveryProduct>> PostDeliveryProduct(DeliveryProductRequest deliveryProductRequest)
        {
            var deliveryProduct = new DeliveryProduct
            {
                productId = deliveryProductRequest.productId,
                deliveryId = deliveryProductRequest.deliveryId,
                count = deliveryProductRequest.count
            };

            _context.DeliveryProduct.Add(deliveryProduct);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryProduct", new { id = deliveryProduct.id }, deliveryProduct);
        }

        // DELETE: api/DeliveryProduct/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDeliveryProduct(int id)
        {
            var deliveryProduct = await _context.DeliveryProduct.FindAsync(id);
            if (deliveryProduct == null)
            {
                return NotFound();
            }

            _context.DeliveryProduct.Remove(deliveryProduct);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryProductExists(int id)
        {
            return _context.DeliveryProduct.Any(e => e.id == id);
        }
    }
} 