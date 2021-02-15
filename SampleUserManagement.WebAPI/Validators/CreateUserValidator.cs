using FluentValidation;
using SampleUserManagement.WebAPI.ViewModels.UserViewModels;

namespace SampleUserManagement.WebAPI.Validators
{
    public class CreateUserValidator : AbstractValidator<CreateUpdateUserViewModel>
    {
		public CreateUserValidator()
		{
			RuleFor(x => x.Fullname).NotEmpty();
			RuleFor(x => x.Username).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
