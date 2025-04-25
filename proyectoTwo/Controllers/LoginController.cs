using Database.Data;
using Database.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;


namespace proyectoTwo.Controllers
{
    public class LoginController : Controller
    
    {
        private readonly AppDbContext _context;

        public LoginController(AppDbContext context)
        {
            _context = context;
        }

      
        public IActionResult Login() => View();

        // Registro View
        public IActionResult Register() => View();

        [HttpPost]
        public IActionResult Register(User user)

        {

            // Código que tú estableces
            const string adminCode = "ADMIN345";
            const string profCode = "TEACH89";
            const string estCode = "study";

            if ((user.Rol == "Admin" && user.RolCode != adminCode) ||
                (user.Rol == "Profesor" && user.RolCode != profCode)
                ||
                (user.Rol == "Estudiante" && user.RolCode != estCode))
            {
                ViewBag.Error = "Código de acceso inválido para el rol seleccionado.";
                return View(user); // vuelve al form con los datos
            }
            if (ModelState.IsValid)
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return RedirectToAction("Login");
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var existingUser = _context.Users
                .FirstOrDefault(u => u.Username == user.Username && u.Password == user.Password);

            if (existingUser != null)
            {
                HttpContext.Session.SetString("UserRol", existingUser.Rol); // guarda bien el rol
                HttpContext.Session.SetString("UserRol", existingUser.Rol);
                Console.WriteLine("Rol guardado en sesión: " + existingUser.Rol);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Error = "Credenciales inválidas.";
                return View();
            }
        }


       




        

        

        public IActionResult Welcome() => View();
    }
}
