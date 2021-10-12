using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CandD.Models;
using Microsoft.EntityFrameworkCore;

namespace CandD.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.AllData = _context.Chefs.ToList();
            return View();
        }

        [HttpGet("/dishes")]
        public IActionResult IndexDish()
        {
            ViewBag.AllData = _context.Dishes
                .Include(dish => dish.Chef)
                .ToList();
            return View();
        }


        [HttpGet("/create")]
        public IActionResult Create()
        {
            return View("Create");
        }


        [HttpPost("/add")]
        public IActionResult Add(Chef newChef)
        {
            if(ModelState.IsValid)
            {
            _context.Add(newChef);
            _context.SaveChanges();
            return RedirectToAction("");
            }
            return View("Create");
        }

        [HttpGet("/createDish")]
        public IActionResult CreateDish()
        {
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("CreateDish");
        }

        [HttpPost("/addDish")]
        public IActionResult AddDish(Dish newDish)
        {
            Console.WriteLine(newDish.Name);
            Console.WriteLine(newDish.Calories);
            Console.WriteLine(newDish.Tastiness);
            Console.WriteLine(newDish.Description);
            Console.WriteLine(newDish.ChefId);
            if(ModelState.IsValid)
            {
                _context.Add(newDish);
                _context.SaveChanges();
                return RedirectToAction("");
            }
            ViewBag.AllChefs = _context.Chefs.ToList();
            return View("CreateDish");
        }


        [HttpGet("delete/{ChefId}")]
        public IActionResult DeleteChef(int chefId)
        {
            Chef retrievedChef = _context.Chefs
                .SingleOrDefault(chef => chef.ChefId == chefId);

            _context.Chefs.Remove(retrievedChef);
            
            _context.SaveChanges();

            return RedirectToAction("");
        }  

        [HttpGet("delete/{DishId}")]
        public IActionResult DeleteDish(int dishId)
        {
            Dish retrievedDish = _context.Dishes
                .SingleOrDefault(dish => dish.DishId == dishId);

            _context.Dishes.Remove(retrievedDish);
            
            _context.SaveChanges();

            return RedirectToAction("");
        }  




        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
