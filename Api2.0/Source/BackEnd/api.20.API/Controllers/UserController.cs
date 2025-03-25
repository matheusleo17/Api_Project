using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;
using api2._0.Application.UseCases.User.Register;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.AccessControl;

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
            var usecase = new RegisterUserUseCase();

            var result = usecase.Execute(request);
            
            return Created(string.Empty, result);
        }
        
    }
}
