using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SampleUserManagement.Common;
using SampleUserManagement.Domain.UserAggregate;
using SampleUserManagement.Repository.Interfaces;
using SampleUserManagement.WebAPI.Mappers;
using SampleUserManagement.WebAPI.ViewModels.AddressViewModels;
using SampleUserManagement.WebAPI.ViewModels.UserViewModels;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleUserManagement.WebAPI.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        private readonly ILogger<UsersController> _logger;

        public UsersController(ILogger<UsersController> logger, IUserRepository userRepository)
        {
            _logger = logger;
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<ICollection<UserViewModel>>> Get()
        {
            var result = await userRepository.GetAll();
            return Ok(result.Select(x => x.ToViewModel()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserViewModel>> GetById(int id)
        {
            var result = await userRepository.Find(id);
            if (result == null) return NotFound();
            return Ok(result.ToViewModel());
        }

        [HttpPost]
        public async Task<ActionResult<UserViewModel>> Post(CreateUpdateUserViewModel model)
        {
            var result = await userRepository.Add(new User(model.Username, model.Password.ComputeSha256Hash(), model.Fullname));
            await userRepository.SaveChanges();
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result.ToViewModel());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<UserViewModel>> Delete(int id)
        {
            var result = await userRepository.Find(id);
            if (result == null) return NotFound();
            if (result.Id == -1) return BadRequest("You can not remove admin user");
            result = userRepository.Remove(result);
            await userRepository.SaveChanges();
            return Ok(result.ToViewModel());
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserViewModel>> Update(int id, CreateUpdateUserViewModel model)
        {
            var result = await userRepository.Find(id);
            if (result == null) return NotFound();
            if (result.Id == -1) return BadRequest("You can not update admin user");
            result.SetUsername(model.Username).SetPassword(model.Password.ComputeSha256Hash()).SetFullname(model.Fullname);
            result = userRepository.Update(result);
            await userRepository.SaveChanges();
            return Ok(result.ToViewModel());
        }


        [HttpGet("{userId}/Address")]
        public async Task<ActionResult<ICollection<AddressViewModel>>> GetAllAddressByUserId(int userId)
        {
            var result = await userRepository.GetAllAddresses(userId);
            return Ok(result);
        }

        [HttpPost("{userId}/Address")]
        public async Task<ActionResult<AddressViewModel>> AddAddressToUser(int userId, CreateAddressViewModel model)
        {
            var user = await userRepository.Find(userId);
            if (user == null) return NotFound();
            var address = userRepository.AddAddress(user, model.FullAddress, model.Mobile, model.Email);
            await userRepository.SaveChanges();
            return Ok(address.ToViewModel());
        }

        [HttpDelete("{userId}/Address/{addressId}")]
        public async Task<ActionResult<AddressViewModel>> RemoveAddressFromUser(int userId, int addressId)
        {
            var user = await userRepository.Find(userId);
            if (user == null) return NotFound();
            var address = userRepository.RemoveAddress(user, addressId);
            await userRepository.SaveChanges();
            return Ok(address.ToViewModel());
        }
    }
}
