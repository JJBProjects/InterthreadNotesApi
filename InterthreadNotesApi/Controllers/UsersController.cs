using AutoMapper;
using InterthreadNotesApi.Models;
using InterthreadNotesApi.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace InterthreadNotesApi.Controllers
{
    [ApiController]
    [Route("api")]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UsersController(IUserRepository userRepository,
            IMapper mapper)
        {
            _userRepository = userRepository ??
                throw new ArgumentNullException(nameof(userRepository));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet("getuser/{userid}", Name = "GetUser")]
        public async Task<IActionResult> GetUser(
            int userId)
        {
            var user = await _userRepository.GetUserAsync(userId);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<UserDto>(user));
        }

        [HttpPost("createuser", Name = "CreateUser")]
        public async Task<ActionResult<UserDto>> CreateUser(
          UserForCreationDto user)
        {
            var newUser = _mapper.Map<Entities.User>(user);

            await _userRepository.AddUserAsync(newUser);

            await _userRepository.SaveChangesAsync();

            var createdUserToReturn =
                _mapper.Map<UserDto>(newUser);

            return CreatedAtRoute("GetUser",
                 new
                 {
                     userId = createdUserToReturn.UserId,
                 },
                 createdUserToReturn);
        }

        [HttpPatch("updateuser/{userid}", Name = "UpdateUser")]
        public async Task<ActionResult> PartiallyUpdateUser(
            int userId,
            JsonPatchDocument<UserForUpdateDto> patchDocument)
        {
            var userEntity = await _userRepository.GetUserAsync(userId);
            if (userEntity == null)
            {
                return NotFound();
            }

            var userToPatch = _mapper.Map<UserForUpdateDto>(
                userEntity);

            patchDocument.ApplyTo(userToPatch, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (!TryValidateModel(userToPatch))
            {
                return BadRequest(ModelState);
            }

            _mapper.Map(userToPatch, userEntity);
            await _userRepository.SaveChangesAsync();

            return NoContent();
        }
    }
}
