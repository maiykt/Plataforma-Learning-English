using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuProyecto.Models
{
    public class ContactoViewModel
    {
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public DateTime Fecha { get; set; }
        public string Departamento { get; set; }
        public string Numero { get; set; }
        public string Mensaje { get; set; }
    }
}
