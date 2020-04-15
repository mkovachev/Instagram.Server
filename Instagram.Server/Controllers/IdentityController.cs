using Instagram.Server.Data.Models;
using Instagram.Server.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Instagram.Server.Controllers
{
    public class IdentityController : ApiBaseController
    {
        private readonly UserManager<User> userManager;
        private readonly AppSettings appSettings;

        public IdentityController(UserManager<User> userManager, AppSettings appSettings)
        {
            this.userManager = userManager;
            this.appSettings = appSettings;
        }

        public async Task<ActionResult> Register(RegisterRequestModel model)
        {
            var user = new User
            {
                Email = "user@test.com"
            };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                return StatusCode((int)HttpStatusCode.Created);
            }

            return BadRequest(result.Errors);
        }

        public async Task<ActionResult<string>> Login(LoginRequestModel model)
        {
            var user = await this.userManager.FindByEmailAsync(model.Email);

            if (user == null)
            {
                return Unauthorized();
            }

            var passwordValid = await this.userManager.CheckPasswordAsync(user, model.Password);

            if (!passwordValid)
            {
                return Unauthorized();
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(this.appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
