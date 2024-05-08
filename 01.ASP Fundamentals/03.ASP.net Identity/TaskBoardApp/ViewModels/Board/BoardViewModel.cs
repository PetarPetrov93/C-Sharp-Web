using System.ComponentModel.DataAnnotations;
using TaskBoardApp.ViewModels.Task;
using static TaskBoardApp.Data.ValidationConstants.ForBoard;

namespace TaskBoardApp.ViewModels.Board
{
    public class BoardViewModel
    {
        public BoardViewModel()
        {
            Tasks = new HashSet<TaskViewModel>();
        }
        public int Id { get; set; }

        [StringLength(BoardNameMaxLength, MinimumLength = BoardNameMinLength, ErrorMessage = ErrorMsg)]
        public required string Name { get; set; }

        public IEnumerable<TaskViewModel> Tasks { get; set; }
    }
}
