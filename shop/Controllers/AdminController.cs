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
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {

            IndexViewModel model = new IndexViewModel();
            model.Title = "Welcome to the shop";
            return View(model);
        }

        public IActionResult Products(int? id){
            List<ProductModel> products = new List<ProductModel>();
            if (id != null){
                ProductModel product = new ProductModel();
                product.Id = (int)id;
                product.Name = "Product " + id;
                product.Description = "This is a product description";
                product.Price = (decimal)id;
                product.Category = "Category " + id;

                products.Add(product);

                return View(products);
            }else{
                return View();
            }
            
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
