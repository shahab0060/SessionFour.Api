using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using SessionFour.Api.Context;

namespace SessionFour.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly InsuranceDbContext _context;
        public UserController()
        {
            _context = new InsuranceDbContext();
        }

        [HttpGet("user-exists-by-username-or-phonenumber/{value}")]
        public async Task<IActionResult>UserNameOrPhoneNumberExists(string value)
        {
            return Ok(await _context.User.AnyAsync(x => x.PhoneNumber == value || x.UserName == value));
        }

        [HttpGet("get-user-id-by-user-pass/{userName}/{password}")]
        public async Task<IActionResult>UserExistsWithUserNameAndPassword(string userName,string password)
        {
            return Ok(await _context.User.Where(x => (x.PhoneNumber == userName || x.UserName == userName) &&x.Password==password)
                .Select(a=>a.Id)
                .FirstOrDefaultAsync());
        }
    }
}
