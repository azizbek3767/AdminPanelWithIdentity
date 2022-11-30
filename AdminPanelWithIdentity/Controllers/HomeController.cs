using AdminPanelWithIdentity.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace AdminPanelWithIdentity.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult Users()
        {
            var model = _context.Users;
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpPost]
        public IActionResult Block(string id) 
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Status = StatusTypes.Blocked;
                _context.Update(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Users");

        }

        [HttpPost]
        public IActionResult UnBlock(string id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                user.Status = StatusTypes.Active;
                _context.Update(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Users");

        }

        [HttpPost]
        public IActionResult Delete(string id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction("Users");

        }
    }
}
