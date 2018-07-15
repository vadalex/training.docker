using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Training.Docker.WebApp.Models;
using Training.Docker.WebApp.Models.ItemRepository;

namespace Training.Docker.WebApp.Controllers
{
    public class HomeController : Controller
    {
        public readonly IItemRepository itemRepository;

        public HomeController(IItemRepository itemRepository)
        {
            this.itemRepository = itemRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Todo()
        {
            var items = itemRepository.GetAll();
            return View(items);
        }

        [HttpPost]
        public IActionResult AddItem(string value)
        {
            if (!string.IsNullOrEmpty(value))
                itemRepository.Add(value);

            return RedirectToAction("Todo");
        }        

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
