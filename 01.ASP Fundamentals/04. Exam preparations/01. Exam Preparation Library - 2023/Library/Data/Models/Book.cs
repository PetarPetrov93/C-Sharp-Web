using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Library.Common.Constants.BookConstants;

namespace Library.Data.Models
{
    [Comment("Books for the library")]
    public class Book
    {
        [Comment("Book idenrifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Title of the book")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public string Title { get; set; } = null!;

        [Comment("Author of the book")]
        [Required]
        [MaxLength(AuthorMaxLength)]
        public string Author { get; set; } = null!;

        [Comment("Description of the book")]
        [Required]
        [MaxLength(DescriptionMaxLength)]
        public string Description { get; set; } = null!;

        [Comment("Image of the book")]
        [Required]
        public string ImageUrl { get; set; } = null!;

        [Comment("Rating of the book")]
        [Required]
        public decimal Rating { get; set; }

        [Comment("Category ID of the book")]
        [Required]
        public int CategoryId { get; set; }

        [Comment("Category of the book")]
        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public ICollection<IdentityUserBook> UsersBooks { get; set; } = new HashSet<IdentityUserBook>();
    }
}
