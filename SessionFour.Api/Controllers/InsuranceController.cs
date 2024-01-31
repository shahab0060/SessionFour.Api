using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionFour.Api.Context;
using SessionFour.Api.Entities;

namespace SessionFour.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InsuranceController : ControllerBase
    {
        private readonly InsuranceDbContext _context;
        public InsuranceController()
        {
            _context = new InsuranceDbContext();    
        }
        [HttpGet("index/{userId}")]
        public async Task<IActionResult>Index(long userId)
        {
            Brand brand = await _context
                .Car
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.CreateDate)
                .Select(a => a.Brand)
                .FirstOrDefaultAsync();
            return Ok(await _context
                .Insurances.Where(a => a.CarBrand == brand)
                .ToListAsync());
        }

        [HttpGet("car/isactive/{plate}")]
        public async Task<IActionResult>ActiveInsuranceExistsForPlate(string plate)
        {
            return Ok(await _context
                .CarInsurances
                .Include(a=>a.Car)
                .AnyAsync(a => a.ExpireDate >= DateTime.Now && a.Car.Plate == plate));
        }

        [HttpPost]
        public async Task<IActionResult> CreateCarInsurance([FromBody]CreateCarInsuranceViewModel createCarInsurance)
        {
            long carId = await _context
                .Car
                .Where(a=>a.UserId==createCarInsurance.UserId)
                .OrderByDescending(a=>a.CreateDate)
                .Select(a=>a.Id) .FirstOrDefaultAsync();
            CarInsurance carInsurance = new CarInsurance()
            {
                CarId = carId,
                CreateDate = DateTime.Now,
                ExpireDate = DateTime.Now.AddYears(1),
                InsuranceId = createCarInsurance.InsuranceId,
                PayedPrice = createCarInsurance.Price
            };
            await _context.CarInsurances.AddAsync(carInsurance);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
