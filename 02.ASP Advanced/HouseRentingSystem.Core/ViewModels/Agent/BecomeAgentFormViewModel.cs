using System.ComponentModel.DataAnnotations;
using static HouseRentingSystem.Core.Constants.MessageConstants;
using static HouseRentingSystem.Infrastructure.Constants.DataConstants.ForAgent;

namespace HouseRentingSystem.Core.ViewModels.Agent
{
    public class BecomeAgentFormViewModel
    {
        [Required(ErrorMessage = RequiredMessage)]
        [StringLength(PhoneNumberMaxLength, MinimumLength = PhoneNumberMinLength, ErrorMessage = StringLengthErrorMessage)]
        [Display(Name = "Phone Number")]
        [Phone]
        public string PhoneNumber { get; set; } = null!;
    }
}
