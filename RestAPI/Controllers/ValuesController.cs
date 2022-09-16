using Data.Data.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Services.Contracts;
using System.Security.Claims;

namespace RestAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        private readonly IPeopleService _peopleService;
        public ValuesController(IPeopleService peopleService)
        {
            _peopleService = peopleService;
        }

        [HttpGet]
        public async Task<ActionResult<Person>> Get()
        {
            var domainPeople = await _peopleService.GetOneAsync();
            return Ok(domainPeople);
        }

        // POST api/values
        [HttpPost]
        public async Task<ActionResult<Person>> Post(Person addBook)
        {
            if (addBook == null)
            {
                return BadRequest();
            }

            var newPerson = await _peopleService.AddPersonAsync(addBook);
            return Ok(newPerson);
        }

//        [Authorize]
        [Route("getlogin")]
        public IActionResult GetLogin()
        {
            return Ok($"Ваш логин: {User.Identity.Name}");
        }

//        [Authorize]
        [Route("getrole")]
        public IActionResult GetRole()
        {
            return Ok($"Ваша роль: {User.Claims.Single(x => x.Type == ClaimsIdentity.DefaultRoleClaimType).Value}");
        }
    }
}
