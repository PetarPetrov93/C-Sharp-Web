using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForHouse;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House to rent")]
    public class House
    {
        [Key]
        [Comment("House identifier")]
        public int Id {  get; init; }

        [Required]
        [MaxLength(TitleMaxLength)]
        [Comment("House title")]
        public required string Title { get; set; }

        [Required]
        [MaxLength(AddressMaxLength)]
        [Comment("House address")]
        public required string Address { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        [Comment("Description")]
        public required string Description { get; set; }

        [Required]
        [Comment("Image URL")]
        public required string ImageUrl { get; set; }

        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        [Comment("Price for one month")]
        public decimal PricePerMonth { get; set; }

        [Required]
        [Comment("Category Id")]
        public int CategoryId { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        [Required]
        [Comment("Agent Id")]
        public int AgentId { get; set; }

        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;

        [Comment("Renter Id")]
        public string? RenterId { get; set; }

        [Comment("Is house approved by admin")]
        public bool IsApproved {  get; set; }
    }
}
