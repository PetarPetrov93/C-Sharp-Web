using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForHouse;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.ViewModels.House
{
    public class HouseServiceModel : IHouseModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Address { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = string.Empty;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), MinimumPrice, MaximumPrice, ErrorMessage = PriceErrorMessage)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Is Rented")]
        public bool IsRented { get; set; }
    }
}