using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HouseRentingSystem.Infrastructure.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure(EntityTypeBuilder<ApplicationUser> builder)
        {
            var data = new DataSeed();

            builder.HasData(new ApplicationUser[] { data.AgentUser, data.GuestUser, data.AdminUser });
        }
    }
}
