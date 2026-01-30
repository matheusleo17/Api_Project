using serverT2.Application.Services.Criptography;
using serverT2.Communication.Requests;
using serverT2.Communication.Responses;
using serverT2.Domain.Repository.User;
using serverT2.Domain.Security.Cryptography;
using serverT2.Exceptions.BaseExceptions;

namespace serverT2.Application.UseCases.Login.DoLogin
{
    public class DoLoginUseCase : IDoLoginUseCase
    {
        private readonly IUserReadOnlyRespository _repository;
        private readonly IPasswordEncripter _passwordEncripter;

        public DoLoginUseCase(IUserReadOnlyRespository respository, IPasswordEncripter passwordEncripter)
        {
            _repository = respository;
            _passwordEncripter = passwordEncripter;
        }

        public async Task<ResponseRegisterdUserJson> Execute(RequestLoginJson request)
        {
            var encriptedPassword = _passwordEncripter.Encrypt(request.Password);
            var user = await _repository.GetbyEmailAndPassword(request.Email, request.Password) ?? throw new InvalidLoginException();

            return new ResponseRegisterdUserJson { Name = user.Name};

        }
    }
}
