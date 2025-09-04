using CommonTesteUtilities.Requests;
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

            var useCase = new RegisterUserUseCase();

             var result = await useCase.Execute(request);

            result.Should().BeNull();

            result.Name.Should().Be(request.Name);


        }
    }
}
