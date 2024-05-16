using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForHouse;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using System.Runtime.CompilerServices;
using HouseRentingSystem.Core.Contracts;

namespace HouseRentingSystem.Core.ViewModels.House
{
    public class HouseFormViewModel : IHouseModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(TitleMaxLength, MinimumLength = TitleMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(AddressMaxLength, MinimumLength = AddressMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Address { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(DescriptionMaxLength, MinimumLength = DescriptionMinLength, ErrorMessage = StringLengthErrorMessage)]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image URL")]
        public string ImageUrl { get; set; } = null!;

        [Required(ErrorMessage = RequiredMessage)]
        [Range(typeof(decimal), MinimumPrice, MaximumPrice, ErrorMessage = PriceErrorMessage)]
        [Display(Name = "Price Per Month")]
        public decimal PricePerMonth { get; set; }

        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        public IEnumerable<HouseCategoryServiceViewModel> Categories { get; set; } = new HashSet<HouseCategoryServiceViewModel>();
    }
}
