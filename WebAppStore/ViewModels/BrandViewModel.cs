using System.ComponentModel.DataAnnotations;

namespace WebAppStore.ViewModels
{
    public class BrandViewModel
    {
        
        public int Id { get; set; }
        [MaxLength(100)]
        public string BrandName { get; set; }

        public int? LaptopCount { get; set; }

        public string? ImageUrl { get; set; }
    }
}
