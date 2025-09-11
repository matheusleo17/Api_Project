using CommonTesteUtilities.Cryptography;
using CommonTesteUtilities.Mapper;
using CommonTesteUtilities.Requests;
using CommonTesteUtilities.Repositories;
using FluentAssertions;
using Microsoft.Identity.Client;
using serverT2.Application.UseCases.User.Register;

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

        private RegisterUserUseCase CreateUseCase()
        {
            var request = RequestRegisterUserJsonBuilder.Build();
            var mapper = MapperBuilder.Build();
            var passwordEncripter = PasswordEncripterBuilder.Build();
            var writeOnlyRepository = UserWriteOnlyRespositoryBuilder.Build();
            var unityOfWork = UnityOfWorkBuilder.Build();
            var readOnlyRepository = new UserReadOnlyRepositoryBuilder().Build();

            return new RegisterUserUseCase(writeOnlyRepository, readOnlyRepository, mapper, unityOfWork, passwordEncripter);
        }
    }
}
