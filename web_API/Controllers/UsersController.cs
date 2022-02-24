using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using web_API.Context;
using web_API.Entities;
using web_API.Services;

namespace web_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private CompanyContext _companyContext;
        public UsersController(CompanyContext companyContext)
        {
            _companyContext = companyContext;
        }

        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _userService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }

        // GET: api/<UsersController>
        public IEnumerable<User> Get()
        {

            return _companyContext.Users;
        }

        // GET api/<UsersController>/1
        [HttpGet("{id}")]
        public User Get(string id)
        {

            return _companyContext.Users.FirstOrDefault(s => s.Id == id);
        }

        // POST api/<UsersController>
        [HttpPost]
        public void Post([FromBody] User value)
        {

            _companyContext.Users.Add(value);
            _companyContext.SaveChanges();
        }

        // PUT api/<UsersController>/1
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] User value)
        {
            var usr = _companyContext.Users.FirstOrDefault(s => s.Id == id);
            if (usr != null)
            {
                _companyContext.Entry<User>(usr).CurrentValues.SetValues(value);
                _companyContext.SaveChanges();
            }
        }

        // DELETE api/<UsersController>/1

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var delusr = _companyContext.Users.FirstOrDefault(s => s.Id == id);
            if (delusr != null)
            {
                _companyContext.Users.Remove(delusr);
                _companyContext.SaveChanges();
            }
        }

        [Authorize]
        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }
    }
}
