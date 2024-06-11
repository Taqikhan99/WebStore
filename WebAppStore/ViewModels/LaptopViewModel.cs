using System.ComponentModel.DataAnnotations;
using WebAppStore.Models;

namespace WebAppStore.ViewModels
{
    public class LaptopViewModel
    {
        public int Id { get; set; }
        [MaxLength(100)]
        public string ModelNumber { get; set; }

        [MaxLength(100)]
        public string Processor { get; set; }

        public int RamInGb { get; set; }
        public int StorageInGb { get; set; }

        [MaxLength(250)]
        public string Description { get; set; } = string.Empty;

        public int BrandId { get; set; } 

        public string? BrandName { get; set; }
        public List<Brand> BrandsList { get; set; }
    }
}
