using OnlineMarket.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace OnlineMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userModel)
        {
            var user = new IdentityUser { UserName = userModel.Username, Email = userModel.Email };
            var result = await _userManager.CreateAsync(user, userModel.Password);

            if(result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = GenerateJwtToken(user);
                return Ok(new {Token = token});
            }
            return BadRequest(result.Errors);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody]  Login userLogin)
        {
            var user = await _userManager.FindByNameAsync(userLogin.Username);
            if(user != null && await _userManager.CheckPasswordAsync(user, userLogin.Password))
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                var token = GenerateJwtToken(user);
                return Ok(new {Token = token});
            }
            return Unauthorized();
        }

        private string GenerateJwtToken(IdentityUser user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("Iaminlovewithverymuchbadkeyisverygoodandbeketseperated"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = creds

            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
