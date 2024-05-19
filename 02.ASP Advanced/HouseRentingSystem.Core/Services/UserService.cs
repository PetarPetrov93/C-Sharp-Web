using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.ViewModels.Administrator;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository repository;
        public UserService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<IEnumerable<UserServiceModel>> AllAsync()
        {
            return await repository.AllReadOnly<ApplicationUser>()
                .Include(u => u.Agent)
                .Select(u => new UserServiceModel()
                {
                    Email = u.Email ?? string.Empty,
                    FullName = $"{u.FirstName} {u.LastName}",
                    PhoneNumber = u.Agent != null ? u.Agent.PhoneNumber : null,
                    IsAgent = u.Agent != null
                })
                .ToListAsync();
        }

        public async Task<string> UserFullNameAsync(string userId)
        {
            string result = string.Empty;
            var user = await repository.GetByIdAsync<ApplicationUser>(userId);

            if (user != null)
            {
                result = $"{user.FirstName} {user.LastName}";
            }

            return result;
        }
    }
}
