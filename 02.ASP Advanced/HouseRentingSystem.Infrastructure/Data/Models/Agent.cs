using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForAgent;

namespace HouseRentingSystem.Infrastructure.Data.Models
{
    [Index(nameof(PhoneNumber), IsUnique = true)]
    [Comment("Agent")]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; init; }

        [Required]
        [MaxLength(PhoneNumberMaxLength)]
        [Comment("Agent's phone number")]
        public required string PhoneNumber { get; set; }

        [Required]
        [Comment("User Id")]
        public required string UserId { get; set; }

        [ForeignKey(nameof(UserId))]
        public ApplicationUser User { get; set; } = null!;

        public List<House> Houses { get; set; } = new List<House>();
    }
}
