using Microsoft.AspNetCore.Mvc;
using WebServicesAPI.DAL.Models;
using WebServicesAPI.DTO;
using WebServicesAPI.Services;

namespace WebServicesAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;

        public UserController(IUserServices userServices)
        {
            _userServices = userServices;
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            var users = _userServices.GetAllUsers();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userServices.GetUserById(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] AddUserRequest userRequest)
        {
            if (userRequest == null)
                return BadRequest("User request is null");

            try
            {
                _userServices.AddUser(userRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult UpdateUser([FromBody] UpdateUserRequest userRequest)
        {
            if (userRequest == null)
                return BadRequest("User request is null");

            try
            {
                _userServices.UpdateUser(userRequest);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userServices.DeleteUser(id);
            return NoContent();
        }
    }
}