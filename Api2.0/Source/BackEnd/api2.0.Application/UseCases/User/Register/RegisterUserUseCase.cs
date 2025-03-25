
using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;

namespace api2._0.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        public ResponseRegisterdUserJson Execute(RequestRegisterUserJson request)
        {
            Validate(request);
            return new ResponseRegisterdUserJson
            {
                Name = request.Name,
            };
        }
        private void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();

            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage);
                throw new Exception();

            }
        }
    }
}
