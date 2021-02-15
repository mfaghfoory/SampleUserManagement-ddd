using SampleUserManagement.Domain.UserAggregate;
using SampleUserManagement.WebAPI.ViewModels.UserViewModels;

namespace SampleUserManagement.WebAPI.Mappers
{
    public static class UserToViewModel
    {
        public static UserViewModel ToViewModel(this User user)
        {
            return new UserViewModel
            {
                Id = user.Id,
                Fullname = user.Fullname,
                Username = user.Username
            };
        }
    }
}
