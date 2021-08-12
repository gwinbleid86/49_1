using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _49_1.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _49_1.Controllers
{
    public class UsersController : Controller
    {
        private ApplicationContext _db;

        public UsersController(ApplicationContext db)
        {
            _db = db;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            List<UserModel> users = _db.UsersModel.ToList();
            return View(users);
        }
    }
}
