using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static DeskMarket.Common.ValidationConstants;

namespace DeskMarket.Data.Models
{

    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(ProductNameMaxLength)]
        public string ProductName { get; set; } = null!;

        [Required]
        [StringLength(ProductDescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Required]
        public decimal Price { get; set; }

        public string? ImageUrl { get; set; }

        [Required]
        public string SellerId { get; set; } = null!;

        [Required]
        [ForeignKey(nameof(SellerId))]
        public IdentityUser Seller { get; set; } = null!;

        [Required]
        public DateTime AddedOn { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        public bool IsDeleted { get; set; } = false;

        public ICollection<ProductClient> ProductsClients { get; set; } = new HashSet<ProductClient>();
    }
}
