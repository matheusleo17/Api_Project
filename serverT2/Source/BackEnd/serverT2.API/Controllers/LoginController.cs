using Microsoft.AspNetCore.Mvc;
using serverT2.Application.UseCases.Login.DoLogin;
using serverT2.Communication.Requests;
using serverT2.Communication.Responses;

namespace serverT2.API.Controllers
{

    public class LoginController : ServerT2BaseController
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterdUserJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status401Unauthorized)]

        public async Task<IActionResult> Login([FromServices] IDoLoginUseCase usecase, [FromBody] RequestLoginJson request)
        {
            var response = await usecase.Execute(request);

            return Ok(response);
        }
    }
}
