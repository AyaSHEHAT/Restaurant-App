using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using RestrauntApp.Data;
using RestrauntApp.Models;
using System.Diagnostics;

namespace RestrauntApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        RestContext db;
        public HomeController(ILogger<HomeController> logger, RestContext _db)
        {
            _logger = logger;
			db=_db;
		}

        public IActionResult Index()
        {
            ViewBag.Cities= db.Cities.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult FindRestaurant(int CityId)
        {
            if (CityId != null)
            {
                var cityName = db.Cities.Where(a => a.CityId==CityId).Select(a => a.Name).FirstOrDefault();
                var rests = db.Restaurants.Where(a => a.CityId == CityId).ToList();
                ViewBag.CityName = cityName;
              return View(rests);
            }

            return RedirectToAction("Index");
        }
        /* public IActionResult ShowItems(int id, int page = 1)
         {
             if (id != 0)
             {
                 int pageSize = 3; 

                 var model = db.Items.Where(a => a.RestaurantId == id).ToList();
                 int totalItems = model.Count();

                 var itemsForPage = model.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                 ViewBag.Page = page;
                 ViewBag.TotalPages = (int)Math.Ceiling((double)totalItems / pageSize);

                 return View(itemsForPage);
             }
             return RedirectToAction("Index");
         }*/
        public IActionResult ShowItems(int id)
        {
            if (id != 0)
            {
                var model = db.Items.Where(a => a.RestaurantId==id).ToList();
                return View(model);
            }
            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Checkout(List<int> id)
        {
           decimal total=0; 
           List<Item> items = new List<Item>();
           if (id != null)
            {
                for (int i = 0; i < id.Count; i++)
                {
                    var item = db.Items.FirstOrDefault(a => a.Id==id[i]);
                    total+=item.Price;
					items.Add(item);
                }
            }

            ViewBag.TotalPrice=total;

			return View(items);
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
