using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForCategory;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Comment("House category")]
    public class Category
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; init; }

        [Required]
        [MaxLength(NameMaxLength)]
        [Comment("Category name")]
        public required string Name { get; set; }

        public IEnumerable<House> Houses { get; init; } = new List<House>();
    }
}
