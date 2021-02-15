namespace SampleUserManagement.WebAPI.ViewModels.AddressViewModels
{
    public class AddressViewModel
    {
        public int Id { get; set; }

        public int UserId { get; set; }

        public string FullAddress { get; set; }

        public string Mobile { get; set; }

        public string Email { get; set; }
    }
}
