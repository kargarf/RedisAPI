
using RedisAPI.Data;
using RedisAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace RedisAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlatformsController : ControllerBase
    {
        private readonly IPlatformRepo _repository;

        public PlatformsController(IPlatformRepo repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Platform>> GetPlatforms()
        {
            return Ok(_repository.GetAllPlatforms().ToList());
        }

        [HttpGet("{id}", Name="GetPlatformById")]
        public ActionResult<Platform> GetPlatformById(string id)
        {
            
            var platform = _repository.GetPlatformById(id);
            
            if (platform != null)
            {
                return Ok(platform);
            }

            return NotFound();
        }

        [HttpPost]
        public ActionResult <Platform> CreatePlatform(Platform platform)
        {
            _repository.CreatePlatform(platform);

            return Ok(platform);
        }

    }
}