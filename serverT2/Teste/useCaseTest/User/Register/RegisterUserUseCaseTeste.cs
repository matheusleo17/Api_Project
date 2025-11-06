using CommonTesteUtilities.Cryptography;
using CommonTesteUtilities.Mapper;
using CommonTesteUtilities.Repositories;
using CommonTesteUtilities.Requests;
using FluentAssertions;
using Microsoft.Identity.Client;
using serverT2.Application.UseCases.User.Register;
using serverT2.Exceptions;
using serverT2.Exceptions.BaseExceptions;

namespace useCaseTest.User.Register
{
    public class RegisterUserUseCaseTeste
    {
        [Fact]
        public async Task Success()
        {

            var request = RequestRegisterUserJsonBuilder.Build();

            var useCase = CreateUseCase();

            var result = await useCase.Execute(request);

            result.Should().NotBeNull();

            result.Name.Should().Be(request.Name);


        }
        [Fact]
        public async Task ErrorMailAlreadyRegisted()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var useCase = CreateUseCase(request.Email);
            Func<Task> act = async () => await useCase.Execute(request);

            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.errorsMessage.Count == 1 && e.errorsMessage.Contains(ResourceMessages.EMAIL_EMPTY));

        }

        [Fact]
        public async Task ErrorNameAlreadyRegisted()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name = string.Empty;
            var useCase = CreateUseCase();
            Func<Task> act = async () => await useCase.Execute(request);

            (await act.Should().ThrowAsync<ErrorOnValidationException>())
                .Where(e => e.errorsMessage.Count == 1 && e.errorsMessage.Contains(ResourceMessages.NAME_EMPTY));

        }

        private RegisterUserUseCase CreateUseCase(string? email = null)
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var mapper = MapperBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var writeOnlyRepository = UserWriteOnlyRespositoryBuilder.Build();
            var unityOfWork = UnityOfWorkBuilder.Build();
            var readOnlyRepositoryBuilder = new UserReadOnlyRepositoryBuilder();

            if(string.IsNullOrEmpty(email)== false)
            {
                readOnlyRepositoryBuilder.ExistsActiveUserEmail(email);
            }
     
                return new RegisterUserUseCase(writeOnlyRepository, readOnlyRepositoryBuilder.Build(), mapper, unityOfWork, passwordEncripter);
        }
    }
}
