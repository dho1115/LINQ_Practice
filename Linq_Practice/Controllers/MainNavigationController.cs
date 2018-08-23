using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linq_Practice.Data;
using Linq_Practice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Linq_Practice.Controllers
{
    public class MainNavigationController : Controller
    {

        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;


        public MainNavigationController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            this._context = context;
            this._userManager = userManager;
        } 

        public IActionResult Index()
        {
            return View();
        }
    }
}