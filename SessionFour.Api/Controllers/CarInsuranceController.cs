using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SessionFour.Api.Context;
using SessionFour.Api.Entities;

namespace SessionFour.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CarInsuranceController : ControllerBase
    {
        private readonly InsuranceDbContext _context;
        public CarInsuranceController()
        {
            _context = new InsuranceDbContext();
        }
        [HttpGet("index/{userId}")]
        public async Task<IActionResult>GetCarInsurances(long userId)
        {
            long carId = await _context
                .Car
                .Where(a => a.UserId == userId)
                .OrderByDescending(a => a.CreateDate)
                .Select(a => a.Id).FirstOrDefaultAsync();
            return Ok(await _context
                .CarInsurances
                .Where(a => a.CarId == carId)
                .Include(a=>a.Insurance)
                .Include(a=>a.Car)
                .Select(a=>new ShowCarInsuranceInformationViewModel()
                {
                    CarBrandTitle = a.Car.Brand.ToString(),
                    CarModelTitle = a.Car.Model.ToString(),
                    Createyear = a.Car.CreateYear,
                    InsuranceTitle = a.Insurance.Title,
                    CreateDate = a.CreateDate,
                    Price = a.Insurance.Price,
                    Id = a.Id
                }).ToListAsync());
        }

        [HttpGet("insurnce/single/{carInsuranceId}")]
        public async Task<IActionResult>GetSingleCarInsurance(long carInsuranceId)
        {
            return Ok(await _context.CarInsurances
                .Where(a => a.Id == carInsuranceId)
                .Include(a => a.Insurance)
                .Include(a => a.Car)
                .Select(a => new ShowCarInsuranceInformationViewModel()
                {
                    CarBrandTitle = a.Car.Brand.ToString(),
                    CarModelTitle = a.Car.Model.ToString(),
                    Createyear = a.Car.CreateYear,
                    InsuranceTitle = a.Insurance.Title,
                    Id = a.Id,
                    CreateDate = a.CreateDate,
                    Price  = a.PayedPrice
                }).FirstOrDefaultAsync());
        }
    }
}
