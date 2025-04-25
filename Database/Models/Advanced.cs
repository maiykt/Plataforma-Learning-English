using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Models
{
   public class Advanced
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Descripcion { get; set; }
        public string ImagePath { get; set; }
        public double Price { get; set; }

        public int CategoryId { get; set; }

        public Category? Category { get; set; }
    }
}
