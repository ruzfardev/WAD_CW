using System.Collections.Generic;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using WADAPI.Models;
using WADAPI.Repository;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WADAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }
        // GET: api/Users
        [HttpGet]
        public IActionResult Get()
        {
            var user = _usersRepository.GetAllUsers();
            return new OkObjectResult(user);
        }
        // GET: api/Users/5
        [HttpGet("{id}", Name = "Users")]
        public IActionResult Get(int id)
        {
            var user = _usersRepository.GetUserById(id);
            return new OkObjectResult(user);
        }
        // POST: api/Users
        [HttpPost]
        public IActionResult Post([FromBody] Users user)
        {
            using (var scope = new TransactionScope())
            {
                _usersRepository.CreateUser(user);
                scope.Complete();
                return CreatedAtAction(nameof(Get), new { id = user.UserId }, user);
            }
        }
        // PUT: api/Users/5
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Users user)
        {
            if (user != null)
            {
                using (var scope = new TransactionScope())
                {
                    _usersRepository.UpdateUser(user);
                    scope.Complete();
                    return new OkResult();
                }
            }
            return new NoContentResult();
        }
        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _usersRepository.DeleteUser(id);
            return new OkResult();
        }
    }
}
