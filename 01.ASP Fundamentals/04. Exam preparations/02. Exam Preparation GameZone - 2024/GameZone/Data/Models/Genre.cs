using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants.ForGenre;

namespace GameZone.Data.Models
{
    [Comment("This is the genre of the game")]
    public class Genre
    {
        [Comment("Genre Identifier")]
        [Key]
        public int Id { get; set; }

        [Comment("This is the genre name")]
        [Required]
        [MaxLength(NameMaxLength)]
        public string Name { get; set; } = null!;

        [Comment("a collection of all games for the given genre")]
        public ICollection<Game> Games { get; set; } = new HashSet<Game>();
    }
}
