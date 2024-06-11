using System.ComponentModel.DataAnnotations;

namespace WebAppStore.Models
{
    public class Brand
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string BrandName { get; set; }

        public string? ImageUrl { get; set; }
        public ICollection<Laptop> Laptops { get; set; }=new List<Laptop>();
    }
}
