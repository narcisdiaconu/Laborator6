using System.ComponentModel.DataAnnotations;

namespace Presentation.Models
{
    public class PoiViewModel
    {
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Lat { get; set; }

        public decimal Long { get; set; }

    }
}
