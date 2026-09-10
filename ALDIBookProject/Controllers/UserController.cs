using ALDIBookProject.DTOs.Entitites;
using ALDIBookProject.Entities;
using ALDIBookProject.Services.Implementations;
using ALDIBookProject.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ALDIBookProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<IEnumerable<User>> Get()
        {
            return await _userService.ListAllUsers();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User?>> Get(Guid id)
        {
            User? user = await _userService.GetById(id);

            return user == null ? NotFound() : Ok(user);
        }

        // POST api/<UserController>
        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] UserDto userDto)
        {
            User? existingUser = await _userService.GetUserByEmail(userDto.Email);

            if (existingUser != null)
            {
                return BadRequest("User with this email already exists.");
            }

            User user = await _userService.CreateUser(userDto);

            return user == null ? BadRequest() : CreatedAtAction(nameof(Get), new { id = user.Id }, user);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<User?>> Update(Guid id, [FromBody] UserDto userDto)
        {
            User? user = await _userService.UpdateUser(id, userDto);

            return user == null ? NotFound() : Ok(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<bool>> Delete(Guid id)
        {
            bool isDeleted = await _userService.DeleteUser(new UserDto { Id = id });

            return isDeleted ? NotFound() : Ok(isDeleted);
        }
    }
}
