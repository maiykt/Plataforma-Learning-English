

namespace Database.Models
{
    public class Category : BaseModel
    {
        public ICollection<Product>? Products { get; set; }


    }
}
