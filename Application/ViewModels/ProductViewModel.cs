using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
     
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }
    }
}
