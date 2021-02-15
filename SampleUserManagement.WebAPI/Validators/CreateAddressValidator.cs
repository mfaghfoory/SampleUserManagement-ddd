using FluentValidation;
using SampleUserManagement.WebAPI.ViewModels.AddressViewModels;

namespace SampleUserManagement.WebAPI.Validators
{
    public class CreateAddressValidator : AbstractValidator<CreateAddressViewModel>
    {
		public CreateAddressValidator()
		{
			RuleFor(x => x.Email).NotEmpty().EmailAddress();
			RuleFor(x => x.FullAddress).NotEmpty();
			RuleFor(x => x.Mobile).NotEmpty();
		}
	}
}
