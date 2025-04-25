
using Database.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class SaveProductViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe colocar el nombre de la clase")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe colocar la Descripcion de la clase")]
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Debe colocar la duracion de la clase")]
        public double Price { get; set; }

        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Debe colocar el tipo de clase")]
        public Category? Category { get; set; }

    }
}
