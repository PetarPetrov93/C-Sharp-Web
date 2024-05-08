using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.ValidationConstants.ForTask;

namespace TaskBoardApp.ViewModels.Task
{
    public class TaskFormModel
    {
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = ErrorMsg)]
        [Required]
        public string Title { get; set; } = string.Empty;

        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = ErrorMsg)]
        [Required]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Board")]
        public int? BoardId { get; set; }

        public IEnumerable<TaskBoardModel> Boards { get; set; } = new HashSet<TaskBoardModel>();
    }
}
