using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TaskBoardApp.Data.ValidationConstants.ForTask;
namespace TaskBoardApp.Data.Models
{
    public class Task
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(TitleMaxLength)]
        public required string Title { get; set; }

        [Required]
        [MaxLength(DescriptionMaxLength)]
        public required string Description { get; set; }

        public DateTime? CreatedOn { get; set; }

        [ForeignKey(nameof(Board))]
        public int? BoardId { get; set; }

        public Board? Board { get; set; }

        [Required]
        [ForeignKey(nameof(IdentityUser))]
        public required string OwnerId { get; set; }

        public IdentityUser Owner { get; set; } = null!;
    }
}
