using KvalikApi.Context;
using KvalikApi.Model;
using KvalikApi.Request;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KvalikApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarController : ControllerBase
    {
        private readonly ContextDb _context;

        public CarController(ContextDb context)
        {
            _context = context;
        }

        // GET: api/Car
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Car>>> GetCars()
        {
            return await _context.Car.Include(c => c.user).ToListAsync();
        }

        // GET: api/Car/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCar(int id)
        {
            var car = await _context.Car.Include(c => c.user).FirstOrDefaultAsync(c => c.id == id);

            if (car == null)
            {
                return NotFound();
            }

            return car;
        }

        // PUT: api/Car/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCar(int id, CarRequest carRequest)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            car.model = carRequest.model;
            car.plate = carRequest.plate;
            car.lastTO = carRequest.lastTO;
            car.nextTO = carRequest.nextTO;
            car.driverId = carRequest.driverId;
            
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarExists(id))
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

        // POST: api/Car
        [HttpPost]
        public async Task<ActionResult<Car>> PostCar(CarRequest carRequest)
        {
            var car = new Car
            {
                model = carRequest.model,
                plate = carRequest.plate,
                lastTO = carRequest.lastTO,
                nextTO = carRequest.nextTO,
                driverId = carRequest.driverId
            };

            _context.Car.Add(car);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCar", new { id = car.id }, car);
        }

        // DELETE: api/Car/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCar(int id)
        {
            var car = await _context.Car.FindAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            _context.Car.Remove(car);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CarExists(int id)
        {
            return _context.Car.Any(e => e.id == id);
        }
    }
} 