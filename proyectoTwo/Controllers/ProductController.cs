using Application.Services;
using Application.ViewModels;
using Database;
using Microsoft.AspNetCore.Mvc;

namespace proyectoTwo.Controllers
{
    public class ProductController : Controller
    {
        
    private readonly ProductService _productService;

        public ProductController(AplicationContext dbContext)
        {
            _productService = new(dbContext);
        }


 



        public IActionResult Create()
        {
            return View("SaveProduct", new SaveProductViewModel());
        }
        public async Task<IActionResult> Index()
        {
        
            var rol = HttpContext.Session.GetString("UserRol");
            Console.WriteLine("ROL ACTUAL: " + rol);
            if (rol != "Admin" && rol != "Profesor")
            {
                return RedirectToAction("Index", "Home");
            }

            
     
            return View(await _productService.GetAllViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveProductViewModel vm)
        {
            var rol = HttpContext.Session.GetString("Rol");

            if (rol == "Estudiante")
            {
                return RedirectToAction("Index"); // o a donde quieras mandarlo
            }

            await _productService.Add(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });


        }


    
       
      

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveProduct", await _productService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SaveProductViewModel vm)
        {
         
            await _productService.Update(vm);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
        public async Task<IActionResult> Delete(int Id)
        {
            return View( await _productService.GetByIdSaveViewModel(Id));
        }
        [HttpPost]
        public async Task<IActionResult> DeletePost(int Id)
        {
          
            await _productService.Delete(Id);
            return RedirectToRoute(new { controller = "Product", action = "Index" });
        }
    }
}


