using GlobalInsightsTribuneApi.Entitys;
using GlobalInsightsTribuneApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace GlobalInsightsTribuneApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]


    public class UsersController : Controller
    {
        private readonly IUsersRepository _usersRepository;
        public UsersController(IUsersRepository usersRepository) 
        {
        _usersRepository = usersRepository;
        }

        [HttpGet("GetUserById")]
        public async Task<ActionResult<Users>> GetUserById(int id) 
        {

            return Ok(await _usersRepository.SelectById(id));


        }

        [HttpPost("AddUsers")]
        public async Task<ActionResult> AddUsers(Users users)
        {
            _usersRepository.Add(users);
            if (await _usersRepository.SaveAllAsync())
            {
                return Ok("successfully saved ");   
            }

            return BadRequest("failed to save");



        }

    }
}
