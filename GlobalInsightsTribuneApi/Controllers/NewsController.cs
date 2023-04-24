using GlobalInsightsTribuneApi.Entitys;
using GlobalInsightsTribuneApi.Interfaces;
using GlobalInsightsTribuneApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace GlobalInsightsTribuneApi.Controllers
{

    [ApiController]
    [Route("api/[controller]")]

    public class NewsController : Controller
    {
        private readonly INewsRepository _newsRepository;

        public NewsController(INewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<News>>> GetNews()
        {
            return Ok(await _newsRepository.SelectAll());
        }


    }





   
}
