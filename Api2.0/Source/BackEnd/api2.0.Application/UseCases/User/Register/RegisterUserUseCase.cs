
using Ap2._0.Communication.Requests;
using Ap2._0.Communication.Responses;
using api2._0.Application.Services.AutoMapper;
using api2._0.Application.Services.Criptography;
using Api2._0.Domain.Repository.User;
using Api2._0.Exceptions.BaseExceptions;
using System.Security.AccessControl;

namespace api2._0.Application.UseCases.User.Register
{
    public class RegisterUserUseCase
    {
        private readonly IUserWriteOnlyRespository _writeOnlyRepository;
        private readonly IUserReadOnlyRespository _readOnlyRepository;

        public async Task<ResponseRegisterdUserJson> Execute(RequestRegisterUserJson request)
        {
            var cryptoPassword = new PasswordCryptography();

            Validate(request);
            var autoMapper = new AutoMapper.MapperConfiguration(options =>
            {
                options.AddProfile(new AutoMapping());

            }).CreateMapper();

            var user = autoMapper.Map<Api2._0.Domain.Entities.User>(request);
            user.Password = cryptoPassword.Encrypt(request.Password);
            await _writeOnlyRepository.Add(user);
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
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);

            } 
        }
    }
}
