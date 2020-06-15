using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ChefsDishes.Models;
using Microsoft.EntityFrameworkCore;

namespace ChefsDishes.Controllers
{
    public class HomeController : Controller
    {
        private MyContext dbContext;
        public HomeController(MyContext context)
        {
            dbContext = context;
        }
        public IActionResult Index()
        {
            ViewBag.AllChefsDishes=dbContext.Chefs.Include(c=>c.ChefDishes).ToList();
            List <Chef> AllChefs=dbContext.Chefs.ToList();
            return View(AllChefs);
        }
        [HttpGet]
        [Route("dishes")]
        public IActionResult ViewDishes()
        {
            ViewBag.AllDishes=dbContext.Dishes.Include(d=>d.DishCreator).ToList();

            return View();

        }
        [HttpGet]
        [Route("newchef")]
        public IActionResult AddChef()
        {

            return View();

        }
        [HttpPost]
        [Route("processchef")]
        public IActionResult ProcessChef(Chef newbie)
        {
            if (ModelState.IsValid)
            { 
                dbContext.Chefs.Add(newbie);
                dbContext.SaveChanges();
                return Redirect("/");

            }
            else {
    
            return View("AddChef");

            }
            
        }
        [HttpGet]
        [Route("newdish")]
        public IActionResult AddDish()
        {
            ViewBag.Chefs=dbContext.Chefs.ToList();

            return View();

        }

        [HttpPost]
        [Route("processdish")]
        public IActionResult ProcessDish(Dish newDish)
        {
            if (ModelState.IsValid)
            {
                int? chefid=newDish.ChefId;
                List <Dish> chefdishes=dbContext.Chefs
                    .Include(c=>c.ChefDishes)
                    .FirstOrDefault(c=>c.ChefId==(int)chefid)
                    .ChefDishes.ToList();

                newDish.DishId = (int)chefid;
                dbContext.Dishes.Add(newDish);
                dbContext.SaveChanges();
                return Redirect("/");
            }

            return View("AddDish");

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
