using serverT2.Communication.Requests;
using serverT2.Communication.Responses;
using serverT2.Application.UseCases.User.Register;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

namespace serverT2.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisterdUserJson),StatusCodes.Status201Created)]
        public IActionResult add(RequestRegisterUserJson request)
        {
            var usecase = new RegisterUserUseCase();

            var result = usecase.Execute(request);
            
            return Created(string.Empty, result);
        }
        
    }
}
