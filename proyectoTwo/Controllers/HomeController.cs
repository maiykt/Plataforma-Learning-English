using System.Diagnostics;
using System.Net.Mail;
using System.Net;
using Application.Services;
using Database;
using Microsoft.AspNetCore.Mvc;
using proyectoTwo.Models;
using TuProyecto.Models;

namespace proyectoTwo.Controllers;

public class HomeController : Controller
{
    private readonly ProductService _productService;

    public HomeController(AplicationContext dbContext)
    {
        _productService = new(dbContext);
    }

    public async Task<IActionResult> Index()
    {
        return View(await _productService.GetAllViewModel());
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


    // Acci�n que recibe el formulario mediante POST
    [HttpPost]
    public IActionResult EnviarCorreo(ContactoViewModel model)
    {
        try
        {
            // Crear una instancia del mensaje de correo
            var mensajeCorreo = new MailMessage();

            // Establecer el remitente como el correo que el usuario ingresa en el formulario
            mensajeCorreo.From = new MailAddress(model.Correo);

            // Definir el destinatario del correo (en este caso, el correo de recepci�n est�tico)
            mensajeCorreo.To.Add("stsrrail123@gmail.com");

            // Establecer el asunto del correo (fijo en este caso)
            mensajeCorreo.Subject = "Nuevo mensaje del formulario";

            // Construir el cuerpo del mensaje con la informaci�n proporcionada por el usuario
            mensajeCorreo.Body =
                $"Nombre: {model.Nombre}\n" +
                $"Correo: {model.Correo}\n" +
                $"Fecha: {model.Fecha.ToShortDateString()}\n" +
                $"Departamento: {model.Departamento}\n" +
                $"N�mero: {model.Numero}\n" +
                $"Mensaje:\n{model.Mensaje}";

            // Configurar el cliente SMTP para enviar el correo (usando el servidor de Gmail
            var smtp = new SmtpClient("smtp.gmail.com", 587)
            {
                // Proporcionar las credenciales del correo que enviar� el mensaje (correo y contrase�a de aplicaci�n

                Credentials = new NetworkCredential("stsrrail123@gmail.com", "udok ywvr thol raeu"),

                // Habilitar la seguridad SSL para la conexi�n
                EnableSsl = true
            };

            // Enviar el mensaje al destinatario configurado
            smtp.Send(mensajeCorreo);

            // Si el env�o fue exitoso, se establece un mensaje de �xito para mostrar al usuario
            ViewBag.Mensaje = "Correo enviado correctamente.";
        }
        catch (Exception ex)
        {
            // Si ocurre un error durante el env�o, se captura la excepci�n y se muestra el mensaje de error
            ViewBag.Mensaje = "Error al enviar el correo: " + ex.Message;
        }

        // Despu�s de intentar enviar el correo, se regresa a la vista 'Index'
        return View("Index");
    }

}



