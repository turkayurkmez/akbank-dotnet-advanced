using course.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace course.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult Login(UserLoginModel userLoginModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userService.ValidateUser(userLoginModel.UserName, userLoginModel.Password);
                //istemciye token vereceksiniz:
                if (user != null)
                {
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("bu-cumle-bizim-sirrimiz"));
                    var credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email),
                        new Claim("role",user.Role)

                    };

                    var token = new JwtSecurityToken(
                          issuer: "api.akbank",
                          audience: "mobil.akbank",
                          claims: claims,
                          notBefore: DateTime.Now,
                          expires: DateTime.Now.AddDays(1),
                          signingCredentials: credential
                        );

                    return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });

                }
                return BadRequest(new { message = "Kullanıcı adı ya da şifre yanlış!" });

            }
            return BadRequest(ModelState);

        }
    }
}
