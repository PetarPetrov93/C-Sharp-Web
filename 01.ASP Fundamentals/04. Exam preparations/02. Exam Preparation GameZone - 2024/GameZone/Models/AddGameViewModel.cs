using System.ComponentModel.DataAnnotations;
using static GameZone.Common.ValidationConstants.ForGame;

namespace GameZone.Models
{
    public class AddGameViewModel
    {

        [Required]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength)]
        public string Title { get; set; } = null!;

        [Required]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength)]
        public string Description { get; set; } = null!;

        public string? ImageUrl { get; set; }

        [Required]
        [RegularExpression(@"^\d{4}-\d{2}-\d{2}$")]
        public string ReleasedOn { get; set; } = null!;

        [Range(1, int.MaxValue)]
        public int GenreId { get; set; }

        public IEnumerable<GenreViewModel> Genres { get; set; } = new HashSet<GenreViewModel>();

    }
}
