using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Configurations
{
    internal class AgentConfiguration : IEntityTypeConfiguration<Agent>
    {
        public void Configure(EntityTypeBuilder<Agent> builder)
        {
            var data = new DataSeed();

            builder.HasData(new Agent[] { data.Agent, data.AdminAgent });
        }
    }
}
