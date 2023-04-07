using System.Collections.Generic;
using System.Transactions;
using System.Web.Http.Results;
using Microsoft.AspNetCore.Mvc;
using WADAPI.Models;
using WADAPI.Repository;
using OkResult = Microsoft.AspNetCore.Mvc.OkResult;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _usersRepository;
        public UsersController(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var user = _usersRepository.GetAll();
            return new OkObjectResult(user);
        }
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Users")]
        public IActionResult Get(int id)
        {
            var user = _usersRepository.GetById(id);
            return new OkObjectResult(user);
        }
        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            using (var scope = new TransactionScope())
            {
                _usersRepository.Add(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
        }
        // PUT: api/Users/5
        [HttpPut]
        public IActionResult Put([FromBody] Users user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _usersRepository.Update(user);
                    scope.Complete();
                    return CreatedAtAction(nameof(Get), new {}, user);
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersRepository.Delete(id);
            return new OkResult();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel request)
        {
            var user = _usersRepository.ValidateUser(request.Email, request.Password);

            if (user != null)
            {
                // You can return the user data or a token for the client to store and use for authentication
                return new OkObjectResult(user);
            }

            return BadRequest(new { message = "Error" });
        }

    }
}
