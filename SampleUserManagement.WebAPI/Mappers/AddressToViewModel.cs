using SampleUserManagement.Domain.UserAggregate;
using SampleUserManagement.WebAPI.ViewModels.AddressViewModels;

namespace SampleUserManagement.WebAPI.Mappers
{
    public static class AddressToViewModel
    {
        public static AddressViewModel ToViewModel(this Address model)
        {
            return new AddressViewModel
            {
                Id = model.Id,
                Email = model.Email,
                FullAddress = model.FullAddress,
                Mobile = model.Mobile,
                UserId = model.UserId
            };
        }
    }
}
