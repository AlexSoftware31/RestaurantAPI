using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Dto;
using RestaurantWebAPI.Helpers;
using WebApi.Entities.Models;
using WebApi.Services.Interfaces;

namespace RestaurantWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IUserLoginServices userLoginServices) : ControllerBase
    {
        private readonly IUserLoginServices _userLoginServices = userLoginServices;

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto model)
        {
            UserLogin userLogin = new()
            {
                Username = model.Username,
                Password = model.Password,
            };

            if ( await _userLoginServices.IsAuthorized(userLogin)) 
            {
                var token = JwtHelper.GenerateJwtToken(model.Username);
                return Ok(new { token });
            }

            return Unauthorized();
        }

    }
}
