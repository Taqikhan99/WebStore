using System.ComponentModel.DataAnnotations;

namespace WebAppStore.ViewModels
{
    public class CreateBrandViewModel
    {
        [Required]
        public string BrandName { get; set; }
        public IFormFile ImageFile { get; set; }
    }
}
