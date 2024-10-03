using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static Library.Common.Constants.CategoryConstants;

namespace Library.Data.Models
{
    [Comment("Category")]
    public class Category
    {
        [Comment("Category idenrifier")]
        [Key]
        public int Id { get; set; }

        [Comment("Category name")]
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;

        public ICollection<Book> Books { get; set; } = new HashSet<Book>();
    }
}
