using System.ComponentModel.DataAnnotations;
using static TaskBoardApp.Data.ValidationConstants.ForTask;

namespace TaskBoardApp.ViewModels.Task
{
    public class TaskViewModel
    {
        public int Id { get; set; }

        
        public string Title { get; set; } = string.Empty;

        
        public string Description { get; set; } = string.Empty;

        
        public string Owner { get; set; } = string.Empty;
    }
}