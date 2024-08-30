
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet]
        public ResultDTO Get()
        {
            ResultDTO result = new ResultDTO()
            {
                Code = 200,
                Message = "获取选型OK",
                Age = 22
            };
            return result;
        }
    }
}
