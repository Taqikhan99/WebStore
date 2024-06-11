using System.ComponentModel.DataAnnotations;

namespace WebAppStore.Models
{
    public class Laptop
    {
        public int Id { get; set; }

        [MaxLength(100)]
        public string ModelNumber { get; set; }

        [MaxLength(100)]
        public string Processor { get; set; }

        public string Generation { get; set; }

        public int ProcessorId { get; set; }
        

        public int RamInGb { get; set; }

        
        public int StorageInGb { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        public DateTime InsertedAt { get; set; }
        
        public DateTime? UpdatedAt { get; set; }

        //navigation
        public int BrandId { get; set; } //foreign key
        public Brand Brand { get; set; }

        public string? ImageUrl { get; set; }

    }
}
