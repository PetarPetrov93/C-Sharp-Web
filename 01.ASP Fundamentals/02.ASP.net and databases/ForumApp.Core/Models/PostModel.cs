using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ForumApp.Infrastructure.Constants.ValidationConstants.PostModelValidationConstants;

namespace ForumApp.Core.Models
{
    public class PostModel
    {
        public string? Id { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = ErrorMessage)]
        public required string Title { get; set; }

        [Required(ErrorMessage = RequiredErrorMessage)]
        [StringLength(ContentMaxLength, MinimumLength = ContentMinLength, ErrorMessage = ErrorMessage)]
        public required string Content { get; set; }
    }
}
