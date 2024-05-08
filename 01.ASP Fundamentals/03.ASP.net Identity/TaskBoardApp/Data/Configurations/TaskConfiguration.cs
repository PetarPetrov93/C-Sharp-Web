using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Models;
using Task = TaskBoardApp.Data.Models.Task;
using static TaskBoardApp.Data.Configurations.ConfigurationHelper;

namespace TaskBoardApp.Data.Configurations
{
    public class TaskConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder
                .HasOne(t => t.Board)
                .WithMany(b => b.Tasks)
                .HasForeignKey(t => t.BoardId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasData(SeedTasks());
        }

        private Task[] SeedTasks()
        {
            return new Task[]
            {
                new Task()
                {
                    Id = 1,
                    Title = "Improve CSS styles",
                    Description = "Implement better styling for all public pages",
                    CreatedOn = DateTime.UtcNow.AddDays(-200),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Task()
                {
                    Id = 2,
                    Title = "Android Client App",
                    Description = "Create Android client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-5),
                    OwnerId = TestUser.Id,
                    BoardId = OpenBoard.Id
                },
                new Task()
                {
                    Id = 3,
                    Title = "Desktop Client App",
                    Description = "Create Desktop client App for the RESTful TaskBoard service",
                    CreatedOn = DateTime.UtcNow.AddMonths(-1),
                    OwnerId = TestUser.Id,
                    BoardId = InProgressBoard.Id
                },
                new Task()
                {
                    Id = 4,
                    Title = "Create Tasks",
                    Description = "Implement [Create Task] page for adding tasks",
                    CreatedOn = DateTime.UtcNow.AddYears(-1),
                    OwnerId = TestUser.Id,
                    BoardId = DoneBoard.Id
                }
            };
        }
    }
}
