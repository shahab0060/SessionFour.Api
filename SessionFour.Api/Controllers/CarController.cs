using Microsoft.AspNetCore.Mvc;
using SessionFour.Api.Context;
using SessionFour.Api.Entities;

namespace SessionFour.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarController : ControllerBase
    {
        private readonly InsuranceDbContext _context;
        public CarController()
        {
            _context = new InsuranceDbContext();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateCarViewModel createCar)
        {
            if(!ModelState.IsValid)
                return BadRequest("please enter all the required information");
            Car car = new Car()
            {
                Brand = createCar.Brand,
                CreateDate = DateTime.Now,
                CreateYear = createCar.CreateYear,
                FuelType = createCar.FuelType,
                Model = createCar.Model,
                OwnerNatinoalCode = createCar.OwnerNatinoalCode,
                Plate = createCar.Plate,
                Type = createCar.Type,
                UserId = createCar.UserId
            };
            await _context.Car.AddAsync(car);
            await _context.SaveChangesAsync();
            return Ok("car added successfully");
        }
    }
}
