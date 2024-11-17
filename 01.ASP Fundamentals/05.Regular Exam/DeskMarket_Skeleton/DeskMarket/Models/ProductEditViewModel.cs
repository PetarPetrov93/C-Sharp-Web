using System.ComponentModel.DataAnnotations;
using System.Drawing;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Models
{
    public class ProductEditViewModel
    {
        [Required]
        [StringLength(ProductNameMaxLength, MinimumLength = ProductNameMinLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength, MinimumLength = ProductDescriptionMinLength)]
        public string Description { get; set; } = null!;

        [Required]
        [Range(1.0, 300.0)]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d{2}-\d{2}-\d{4}$")]
        public string AddedOn { get; set; } = null!;

        [Required]
        public string SellerId { get; set; } = null!;

        [Required]
        [Range(1, int.MaxValue)]
        public int CategoryId { get; set; }

        public IEnumerable<CategoryViewModel> Categories { get; set; } = new HashSet<CategoryViewModel>();
    }
}
