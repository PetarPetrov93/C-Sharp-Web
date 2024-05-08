using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.ValidationConstants.ForBoard;
using Task = TaskBoardApp.Data.Models.Task;

namespace TaskBoardApp.Data.Models
{
    public class Board
    {
        public Board()
        {
            Tasks = new HashSet<Task>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(BoardNameMaxLength)]
        public required string Name { get; set; }

        public IEnumerable<Task> Tasks { get; set; }
    }
}
