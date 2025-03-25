using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api._20.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterdUserJson),StatusCodes.Status201Created)]
        public IActionResult add(RequestRegisterUserJson request)
        {
            return Created();
        }
    }
}
