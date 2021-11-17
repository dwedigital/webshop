using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using shop.Models;


namespace shop.Controllers
{
    public class HomeController : Controller
    {
        ProductsViewModel model = new ProductsViewModel();
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;

            model.Products.Add(new ProductModel
            {
                Id=1,
                Name="Product 1",
            });
            model.Products.Add(new ProductModel
            {
                Id=2,
                Name="Product 2",
            });
            model.Products.Add(new ProductModel
            {
                Id=3,
                Name="Product 3",
            });
        }

        public IActionResult Index()
        {

            IndexViewModel model = new IndexViewModel();
            model.Title = "Welcome to the shop";
            return View(model);
        }

        public IActionResult Products()
        {
            
            

            return View(model); 
        }
        public IActionResult Product(int? id){
            System.Console.WriteLine(model.Products);
                ProductModel product = model.Products.FirstOrDefault(t => t.Id == id);
                return View(product);
            
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
