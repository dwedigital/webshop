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
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;

        public ProductsController(ILogger<ProductsController> logger, DbConnection connection)
        {
            _logger = logger;
            DbConnection.Current = connection;
        }
        [HttpGet]
        public IActionResult Index()
        {

            List<ProductModel> products = ProductModel.GetAll();

            return View(products);


        }
        [HttpGet]
        public IActionResult New()
        {
            return View(new ProductModel());
        }
        [HttpPost]
        public IActionResult Add(ProductModel product){
            if(ModelState.IsValid){
                ProductModel.Save(product);
                return RedirectToAction("Index");
            }

            return View("New", product);
        }
        [HttpGet]
        public IActionResult Product(int id)
        {
            ProductModel product = ProductModel.GetById(id);
            return View(product);
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
