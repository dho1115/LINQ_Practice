using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Linq_Practice.Data;
using Linq_Practice.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Linq_Practice.Controllers
{
    public class FiltersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<ApplicationUser> _userManager;

        public FiltersController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        } 

        //These are for the IEnumerable view.

        public IActionResult index()
        {
            //IENUMERABLE: Ages < 25
            IEnumerable<person> LessThan25 = from item in _context.persons
                                             where item.age < 25
                                             select item;


            //IENUMERABLE: Everyone Who Loves To Travel
            IEnumerable<person> LovesToTravel = _context.persons.Where(x => x.LovesToTravel == true);
            

            //Name Match: NOTE: This works in IEnumerable, too.
            var NameMatch = from item in _context.persons
                            where item.name == "Jamie"
                            select item;

            return View(LovesToTravel);
        } 

        //These are for the non-IEnumerables that cannot fit inside the @models IEnumerable<> view. I constructed a separate view.         

        public IActionResult IndexII()
        {
            person LovesToTravelFirst = _context.persons.Where(x => x.LovesToTravel == true).First();


            person LessThan25FirstorDefault = _context.persons.Where(x => x.LovesToTravel == true && x.age < 25).FirstOrDefault();

            //Removed Aron
            person removeAron = _context.persons.SingleOrDefault(x => x.name == "Aron");
            _context.persons.Remove(removeAron);

            _context.SaveChanges();

            return View(LessThan25FirstorDefault);
        }



        public IActionResult RemoveDataSet()
        {
            if(_context.persons.Count() > 1)
            {
                IEnumerable<person> IDGreaterThan1 = _context.persons.Where(x => x.id > 1);

                //OR...
                
                var remove = from items in _context.persons
                             where items.id > 1
                             select items;

                _context.persons.RemoveRange(IDGreaterThan1);
            }

            else
            {
                return Content(String.Format("The count for table persons is {0}", _context.persons.Count()));
            }

            return RedirectToAction("Index", "Peoples");
        } 



        public IActionResult RemoveAction()
        {
            person getPerson = _context.persons.SingleOrDefault(x => x.id == 4);
            _context.persons.Remove(getPerson);

            _context.SaveChanges(); //*** ALWAYS REMEMBER TO SAVE CHANGES!!! ***

            return RedirectToAction("Index", "peoples");
        } 



        public IActionResult DeleteBasedOnName(string Name)
        {
            var getName = _context.persons.SingleOrDefault(x => x.name == Name);
            _context.persons.Update(getName);

            _context.SaveChanges();
            
            return RedirectToAction("index", "MainNavigation");            
        } 

        public IActionResult EditView()
        {
            return View();
        } 

        public IActionResult GetPrimaryandForeignKeys()
        {
            var HotelLocation = _context.hotels.Include(x => x.Location);
            _context.SaveChanges();

            return View(HotelLocation);
        }

    }
}