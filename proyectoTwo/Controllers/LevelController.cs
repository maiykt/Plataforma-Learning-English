using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace proyectoTwo.Controllers
{
    public class LevelController : Controller
    {
        private readonly ProductService _productService;

        public LevelController(AplicationContext dbContext)
        {
            _productService = new(dbContext);
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAllViewModel());
        }
        public async Task<IActionResult> Intermediate(int? categoryId)
        {
            var productos = await _productService.GetAllViewModel(categoryId);  // Aquí el parámetro categoryId se pasa al servicio

            return View(await _productService.GetAllViewModel());  // Se pasan los productos filtrados a la vista
        }




        public async Task<IActionResult> Advanced()
        {
            return View(await _productService.GetAllViewModel());
        }
    }
}
