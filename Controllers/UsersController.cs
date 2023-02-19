using Microsoft.AspNetCore.Mvc;
using WAD_CW.Repository;

namespace WAD_CW.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUsersRepository _uservice;

        public UsersController(IUsersRepository service)
        {
            _uservice = service;
        }
        public IActionResult Index()
        {
            var data = _uservice.GetAll();
            return View(data);
        }
    }
}
