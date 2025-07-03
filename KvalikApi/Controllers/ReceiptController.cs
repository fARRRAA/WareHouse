using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReceiptController : ControllerBase
    {
        private readonly ContextDb _context;

        public ReceiptController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Receipt
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Receipt>>> GetReceipts()
        {
            return await _context.Receipt.Include(r => r.product).ToListAsync();
        }

        // GET: api/Receipt/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Receipt>> GetReceipt(int id)
        {
            var receipt = await _context.Receipt
                .Include(r => r.product)
                .FirstOrDefaultAsync(r => r.id == id);

            if (receipt == null)
            {
                return NotFound();
            }

            return receipt;
        }

        // PUT: api/Receipt/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceipt(int id, ReceiptRequest receiptRequest)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }

            receipt.productId = receiptRequest.productId;
            receipt.count = receiptRequest.count;
            receipt.date = receiptRequest.date;
            receipt.batchNumber = receiptRequest.batchNumber;
            receipt.conditions = receiptRequest.conditions;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceiptExists(id))
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

        // POST: api/Receipt
        [HttpPost]
        public async Task<ActionResult<Receipt>> PostReceipt(ReceiptRequest receiptRequest)
        {
            var receipt = new Receipt
            {
                productId = receiptRequest.productId,
                count = receiptRequest.count,
                date = receiptRequest.date,
                batchNumber = receiptRequest.batchNumber,
                conditions = receiptRequest.conditions
            };

            _context.Receipt.Add(receipt);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceipt", new { id = receipt.id }, receipt);
        }

        // DELETE: api/Receipt/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceipt(int id)
        {
            var receipt = await _context.Receipt.FindAsync(id);
            if (receipt == null)
            {
                return NotFound();
            }

            _context.Receipt.Remove(receipt);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceiptExists(int id)
        {
            return _context.Receipt.Any(e => e.id == id);
        }
    }
} 