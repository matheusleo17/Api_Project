
using serverT2.Communication.Requests;
using serverT2.Communication.Responses;
using serverT2.Application.Services.AutoMapper;
using serverT2.Application.Services.Criptography;
using serverT2.Domain.Repository.User;
using serverT2.Exceptions.BaseExceptions;
using System.Security.AccessControl;
using AutoMapper;

namespace serverT2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUseCase
    {
        private readonly IUserWriteOnlyRespository _writeOnlyRepository;
        private readonly IUserReadOnlyRespository _readOnlyRepository;
        private readonly IMapper _mapper;
            public RegisterUserUseCase(
                IUserWriteOnlyRespository writeOnlyRepository,
                IUserReadOnlyRespository readOnlyRepository,
                IMapper mapper)
             {
                _writeOnlyRepository = writeOnlyRepository;
                _readOnlyRepository = readOnlyRepository;
                _mapper = mapper;
             }  

        public async Task<ResponseRegisterdUserJson> Execute(RequestRegisterUserJson request)
        {
            var cryptoPassword = new PasswordCryptography();

            Validate(request);

            var user = _mapper.Map<serverT2.Domain.Entities.User>(request);
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
