using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static GameZone.Common.ValidationConstants.ForGame;

namespace GameZone.Data.Models
{
    [Comment("Game")]
    public class Game
    {
        [Comment("Game idenrifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Game Title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Game Description")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Game Pucture")]
        public string? ImageUrl { get; set; }

        [Comment("Game's publisher identifier")]
        [Required]
        public string PublisherId { get; set; } = null!;

        [Comment("Game's publisher")]
        [Required]
        [ForeignKey(nameof(PublisherId))]
        public IdentityUser Publisher { get; set; } = null!;

        [Comment("Game's release date")]
        [Required]
        public DateTime ReleasedOn { get; set; }

        [Comment("Game's genre identifier")]
        [Required]
        public int GenreId { get; set; }

        [Comment("Game's genre")]
        [Required]
        [ForeignKey(nameof(GenreId))]
        public Genre Genre { get; set; } = null!;

        public ICollection<GamerGame> GamersGames { get; set; } = new HashSet<GamerGame>();
    }
}
