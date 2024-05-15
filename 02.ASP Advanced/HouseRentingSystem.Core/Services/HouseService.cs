using HouseRentingSystem.Core.Contracts;
using HouseRentingSystem.Core.Enums;
using HouseRentingSystem.Core.ViewModels.Home;
using HouseRentingSystem.Core.ViewModels.House;
using HouseRentingSystem.Infrastructure.Data.Common;
using HouseRentingSystem.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace HouseRentingSystem.Core.Services
{
    public class HouseService : IHouseService
    {
        private readonly IRepository repository;
        public HouseService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<HouseQueryServiceModel> AllAsync(string? category = null, string? searchTerm = null, HouseSorting sorting = HouseSorting.Newest, int currentPage = 1, int housesPerPage = 2)
        {
            var housesToSHow = repository.AllReadOnly<House>();

            if (category != null)
            {
                housesToSHow = housesToSHow
                    .Where(h => h.Category.Name == category);
            }

            if (searchTerm != null)
            {
                string normalizedSearchTerm = searchTerm.ToLower();
                housesToSHow = housesToSHow.
                    Where(h => h.Title.ToLower().Contains(normalizedSearchTerm) ||
                               h.Address.ToLower().Contains(normalizedSearchTerm) ||
                               h.Description.ToLower().Contains(normalizedSearchTerm));
            }

            housesToSHow = sorting switch
            {
                HouseSorting.Price => housesToSHow
                            .OrderBy(h => h.PricePerMonth),

                HouseSorting.NotRentedFirst => housesToSHow
                            .OrderBy(h => h.RenterId == null)
                            .ThenBy(h => h.Id),

                _ => housesToSHow
                            .OrderByDescending(h => h.Id)
            };

            var houses = await housesToSHow
                .Skip((currentPage - 1) * housesPerPage)
                .Take(housesPerPage)
                .ProjetToHouseServiceModel()
                .ToListAsync();

            int totalHouses = await housesToSHow.CountAsync();

            return new HouseQueryServiceModel()
            {
                Houses = houses,
                TotalHousesCount = totalHouses
            };
        }

        public async Task<IEnumerable<HouseCategoryServiceViewModel>> AllCategoriesAsync()
        {
            return await repository
                .AllReadOnly<Category>()
                .Select(c => new HouseCategoryServiceViewModel()
                {
                    Name = c.Name,
                    Id = c.Id,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
        {
            return await repository.AllReadOnly<Category>()
                .Select(c => c.Name)
                .Distinct()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByAgentIdAsync(int agentId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.AgentId == agentId)
                .ProjetToHouseServiceModel()
                .ToListAsync();
        }

        public async Task<IEnumerable<HouseServiceModel>> AllHousesByUserIdAsync(string userId)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.RenterId == userId)
                .ProjetToHouseServiceModel()
                .ToListAsync();
        }

        public Task<bool> CategoryExistsAsync(int categoryId)
        {
            return repository
                .AllReadOnly<Category>()
                .AnyAsync(c => c.Id == categoryId);
        }

        public async Task<int> CreateAsync(HouseFormViewModel model, int agentId)
        {
            House house = new House()
            {
                Address = model.Address,
                AgentId = agentId,
                Description = model.Description,
                ImageUrl = model.ImageUrl,
                PricePerMonth = model.PricePerMonth,
                Title = model.Title,
                CategoryId = model.CategoryId,
            };

            await repository.AddAsync(house);
            await repository.SaveChangesAsync();


            return house.Id;
        }

        public async Task DeleteAsync(int houseId)
        {
            await repository.DeleteAsync<House>(houseId);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int houseId, HouseFormViewModel model)
        {
            var house = await repository
                .GetByIdAsync<House>(houseId);

            if (house != null)
            {
                house.Address = model.Address;
                house.CategoryId = model.CategoryId;
                house.Description = model.Description;
                house.ImageUrl = model.ImageUrl;
                house.PricePerMonth = model.PricePerMonth;
                house.Title = model.Title;

                await repository.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .AnyAsync(h => h.Id == id);
        }

        public async Task<HouseFormViewModel?> GetHouseFormViewModelByIdAsync(int id)
        {
            var house = await repository
                .AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseFormViewModel()
                {
                    Address = h.Address,
                    CategoryId = h.CategoryId,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    PricePerMonth = h.PricePerMonth,
                    Title = h.Title,
                })
                .FirstOrDefaultAsync();

            if (house != null)
            {
            house.Categories = await AllCategoriesAsync();
            }

            return house;
        }

        public async Task<bool> HasAgentWithIdAsync(int houseId, string userId)
        {
            return await repository
                .AllReadOnly<House>()
                .AnyAsync(h => h.Id == houseId && h.Agent.UserId == userId);
        }

        public async Task<HouseDetailsServiceModel> HouseDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<House>()
                .Where(h => h.Id == id)
                .Select(h => new HouseDetailsServiceModel()
                {
                    Id = h.Id,
                    Address = h.Address,
                    Agent = new ViewModels.Agent.AgentServiceModel()
                    {
                        Email = h.Agent.User.Email,
                        PhoneNumber = h.Agent.PhoneNumber
                    },
                    Category = h.Category.Name,
                    Description = h.Description,
                    ImageUrl = h.ImageUrl,
                    IsRented = h.RenterId != null,
                    PricePerMonth= h.PricePerMonth,
                    Title = h.Title,
                })
                .FirstAsync();
        }

        public async Task<bool> IsRentedAsync(int houseId)
        {
            bool result = false;

            var house = await repository.GetByIdAsync<House>(houseId);
            if (house != null)
            {
                result = house.RenterId != null;
            }

            return result;
        }

        public async Task<bool> IsRentedByUserByIdAsync(int houseId, string userId)
        {
            bool result = false;

            var house = await repository.GetByIdAsync<House>(houseId);
            if (house != null)
            {
                result = house.RenterId == userId;
            }

            return result;
        }

        public async Task<IEnumerable<HouseServiceIndexViewModel>> LastThreeHousesAsync()
        {
            return await repository
                .AllReadOnly<House>()
                .OrderByDescending(h => h.Id)
                .Take(3)
                .Select(h => new HouseServiceIndexViewModel()
                {
                    Id = h.Id,
                    ImageUrl = h.ImageUrl,
                    Title = h.Title,
                })
                .ToListAsync();
        }

        public async Task RentAsync(int id, string userId)
        {
            var house = await repository.GetByIdAsync<House>(id);
            if (house != null)
            {
                house.RenterId = userId;
                await repository.SaveChangesAsync();
            }

        }
    }
}
