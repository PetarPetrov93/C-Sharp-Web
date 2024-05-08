using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TaskBoardApp.Data.Models;
using static TaskBoardApp.Data.Configurations.ConfigurationHelper;

namespace TaskBoardApp.Data.Configurations
{
    public class BoardConfiguration : IEntityTypeConfiguration<Board>
    {
        public void Configure(EntityTypeBuilder<Board> builder)
        {
            builder.HasData(new Board[]
            {
                InProgressBoard,
                DoneBoard,
                OpenBoard
            });
        }
    }
}
