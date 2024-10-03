using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Data.Models
{
    [Comment("Users Books")]
    public class IdentityUserBook
    {
        [Comment("Book Collector ID")]
        public string CollectorId { get; set; } = null!;


        [Comment("Book Collector")]
        [ForeignKey(nameof(CollectorId))]
        public IdentityUser Collector { get; set; } = null!;


        [Comment("Book ID")]
        public int BookId { get; set; }


        [Comment("Book")]
        [ForeignKey(nameof(BookId))]
        public Book Book { get; set; } = null!;
    }
}
