using static ForumApp.Infrastructure.Constants.ValidationConstants.PostValidationConstants;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumApp.Infrastructure.Data.Models
{
    [Comment("Popsts table")]
    public class Post
    {
        public Post()
        {
            Id = Guid.NewGuid();
        }

        [Comment("Post identifier")]
        [Key]
        public Guid Id { get; set; }

        [Comment("Post title")]
        [Required]
        [MaxLength(TitleMaxLength)]
        public required string Title { get; set; }

        [Comment("Post content")]
        [Required]
        [MaxLength(ContentMaxLength)]
        public required string Content { get; set; }
    }
}
