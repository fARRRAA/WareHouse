using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryController : ControllerBase
    {
        private readonly ContextDb _context;

        public DeliveryController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Delivery
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Delivery>>> GetDeliveries()
        {
            return await _context.Delivery.ToListAsync();
        }

        // GET: api/Delivery/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Delivery>> GetDelivery(int id)
        {
            var delivery = await _context.Delivery.FindAsync(id);

            if (delivery == null)
            {
                return NotFound();
            }

            return delivery;
        }

        // PUT: api/Delivery/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDelivery(int id, DeliveryRequest deliveryRequest)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            delivery.startPoint = deliveryRequest.startPoint;
            delivery.endPoint = deliveryRequest.endPoint;
            delivery.dateStart = deliveryRequest.dateStart;
            delivery.dateEnd = deliveryRequest.dateEnd;
            delivery.prioritet = deliveryRequest.prioritet;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryExists(id))
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

        // POST: api/Delivery
        [HttpPost]
        public async Task<ActionResult<Delivery>> PostDelivery(DeliveryRequest deliveryRequest)
        {
            var delivery = new Delivery
            {
                startPoint = deliveryRequest.startPoint,
                endPoint = deliveryRequest.endPoint,
                dateStart = deliveryRequest.dateStart,
                dateEnd = deliveryRequest.dateEnd,
                prioritet = deliveryRequest.prioritet
            };

            _context.Delivery.Add(delivery);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDelivery", new { id = delivery.id }, delivery);
        }

        // DELETE: api/Delivery/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDelivery(int id)
        {
            var delivery = await _context.Delivery.FindAsync(id);
            if (delivery == null)
            {
                return NotFound();
            }

            _context.Delivery.Remove(delivery);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DeliveryExists(int id)
        {
            return _context.Delivery.Any(e => e.id == id);
        }
    }
} 