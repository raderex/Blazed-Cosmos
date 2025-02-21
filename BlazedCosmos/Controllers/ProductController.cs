using Microsoft.AspNetCore.Mvc;
using BlazedCosmos.Services.Interfaces;
using BlazedCosmos.Models;
using System.Threading.Tasks;

namespace BlazedCosmos.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        // GET: /Product
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            return View(products);
        }

        // GET: /Product/Details/{id}
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(); // Return 404 if product not found
            }
            return View(product);
        }
    }
}