
using AutoMapper;
using serverT2.Application.Services.AutoMapper;
using serverT2.Application.Services.Criptography;
using serverT2.Communication.Requests;
using serverT2.Communication.Responses;
using serverT2.Domain.Repository;
using serverT2.Domain.Repository.User;
using serverT2.Domain.Security.Cryptography;
using serverT2.Exceptions;
using serverT2.Exceptions.BaseExceptions;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;

namespace serverT2.Application.UseCases.User.Register
{
    public class RegisterUserUseCase : IRegisterUseCase
    {
        private readonly IUserWriteOnlyRespository _writeOnlyRepository;
        private readonly IUserReadOnlyRespository _readOnlyRepository;
        private readonly IMapper _mapper;
        private readonly IUnityOfWork _unityOfWork;
        private readonly IPasswordEncripter _passwordCryptography;
        public RegisterUserUseCase(
                IUserWriteOnlyRespository writeOnlyRepository,
                IUserReadOnlyRespository readOnlyRepository,
                IMapper mapper,
                IUnityOfWork unityOfWork,
                IPasswordEncripter passwordCryptography)
        {
            _writeOnlyRepository = writeOnlyRepository;
            _readOnlyRepository = readOnlyRepository;
            _mapper = mapper;
            _unityOfWork = unityOfWork;
            _passwordCryptography = passwordCryptography;
        }  

        public async Task<ResponseRegisterdUserJson> Execute(RequestRegisterUserJson request)
        {

            Validate(request);

            var user = _mapper.Map<serverT2.Domain.Entities.User>(request);

            user.Password = _passwordCryptography.Encrypt(request.Password);

            await _writeOnlyRepository.Add(user);

            await _unityOfWork.Commit();

            return new ResponseRegisterdUserJson
            {
                Name = user.Name,
            };
        }
        private async void Validate(RequestRegisterUserJson request)
        {
            var validator = new RegisterUserValidator();
            var result = validator.Validate(request);

            var emailExists = await _readOnlyRepository.ExistsActiveUserEmail(request.Email);

            if(emailExists)
            {
                result.Errors.Add(new FluentValidation.Results.ValidationFailure(string.Empty, ResourceMessages.EMAIL_EMPTY));
            }

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(e => e.ErrorMessage).ToList();

                throw new ErrorOnValidationException(errorMessages);

            } 
        }
    }
}
