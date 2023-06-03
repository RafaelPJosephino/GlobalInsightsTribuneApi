using GlobalInsightsTribune.Application.DTOs;
using GlobalInsightsTribune.Application.Interfaces;
using GlobalInsightsTribune.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GlobalInsightsTribune.MVC.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        public readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("getAll")]
        public IActionResult GetAll()
        {

            try
            {
                return Ok(_userService.GetUserAll());
            }
            catch (Exception e)
            {
                return BadRequest("Error:" + e);

            }
        }


        [HttpPost("RegisterUser")]
        public IActionResult RegisterUser(UserDTO user)
        {
            try
            {
                _userService.RegisterUser(user);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest("Error:"+ e);
                
            }
            
        }

    }
}
