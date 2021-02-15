using FluentValidation;
using SampleUserManagement.WebAPI.ViewModels;

namespace SampleUserManagement.WebAPI.Validators
{
    public class LoginValidator : AbstractValidator<LoginViewModel>
    {
		public LoginValidator()
		{
			RuleFor(x => x.Username).NotEmpty();
			RuleFor(x => x.Password).NotEmpty();
		}
	}
}
