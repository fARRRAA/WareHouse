using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarServiceController : ControllerBase
    {
        private readonly ContextDb _context;

        public CarServiceController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/CarService
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarService>>> GetCarServices()
        {
            return await _context.CarService.Include(cs => cs.car).ToListAsync();
        }

        // GET: api/CarService/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CarService>> GetCarService(int id)
        {
            var carService = await _context.CarService.Include(cs => cs.car)
                .FirstOrDefaultAsync(cs => cs.id == id);

            if (carService == null)
            {
                return NotFound();
            }

            return carService;
        }

        // PUT: api/CarService/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCarService(int id, CarServiceRequest carServiceRequest)
        {
            var carService = await _context.CarService.FindAsync(id);
            if (carService == null)
            {
                return NotFound();
            }

            carService.carId = carServiceRequest.carId;
            carService.type = carServiceRequest.type;
            carService.date = carServiceRequest.date;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarServiceExists(id))
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

        // POST: api/CarService
        [HttpPost]
        public async Task<ActionResult<CarService>> PostCarService(CarServiceRequest carServiceRequest)
        {
            var carService = new CarService
            {
                carId = carServiceRequest.carId,
                type = carServiceRequest.type,
                date = carServiceRequest.date
            };

            _context.CarService.Add(carService);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCarService", new { id = carService.id }, carService);
        }

        // DELETE: api/CarService/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCarService(int id)
        {
            var carService = await _context.CarService.FindAsync(id);
            if (carService == null)
            {
                return NotFound();
            }

            _context.CarService.Remove(carService);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarServiceExists(int id)
        {
            return _context.CarService.Any(e => e.id == id);
        }
    }
} 