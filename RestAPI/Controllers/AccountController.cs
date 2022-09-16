using Data.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using RestAPI.Constants;
using RestAPI.Models;
using RestAPI.ViewModels;
using Services.Services;
using Services.Services.Contracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    public class AccountController : Controller
    {
/*
        private readonly IPeopleService _peopleService;
        public AccountController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpPost("/token")]
        public async Task<IActionResult> Token(string username, string password)
        {
            var identity = await GetIdentityAsync(username, password);
            if (identity == null)
            {
                return BadRequest(new { errorText = ApiConstants.AuthError });
            }

            var now = DateTime.UtcNow;
            // JWT-токен
            var jwt = new JwtSecurityToken(
                    issuer: AuthService.ISSUER,
                    audience: AuthService.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthService.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthService.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);

            var response = new
            {
                access_token = encodedJwt,
                username = identity.Name
            };

            return Json(response);
        }

        private async Task<ClaimsIdentity> GetIdentityAsync(string username, string password)
        {
            var person = await _peopleService.GetByIdAsync(username, password);
//            Person person = people.FirstOrDefault(x => x.Login == username && x.Password == password);
            if (person != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimsIdentity.DefaultNameClaimType, person.Login),
                    new Claim(ClaimsIdentity.DefaultRoleClaimType, person.Role)
                };
                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;
            }

            // если пользователя не найдено
            return null;
        }
*/
    }
}
