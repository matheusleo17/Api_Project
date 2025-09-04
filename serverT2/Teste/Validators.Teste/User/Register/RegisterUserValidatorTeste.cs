using CommonTesteUtilities.Requests;
using serverT2.Application.UseCases.User.Register;
using Shouldly;
using serverT2.Exceptions;
namespace Validators.Teste.User.Register
{
    public class RegisterUserValidatorTeste
    {
        [Fact]
        public void Success()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();

            var result = validator.Validate(request);

            result.IsValid.ShouldBeTrue();

        }
        [Fact]
        public void ErrorNameEmpty()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Name =string.Empty;


            var result = validator.Validate(request);
            var error = result.Errors.ShouldHaveSingleItem();

            result.IsValid.ShouldBeFalse();

        }
        [Fact]
        public void ErrorNameInvalid()
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build();
            request.Email = "Email.com";


            var result = validator.Validate(request);
            var error = result.Errors.ShouldHaveSingleItem();

            result.IsValid.ShouldBeFalse();

        }
        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        [InlineData(5)]
        public void ErrorPassword(int passwordLegth)
        {
            var validator = new RegisterUserValidator();

            var request = RequestRegisterUserJsonBuilder.Build(passwordLegth);


            var result = validator.Validate(request);
            var error = result.Errors.ShouldHaveSingleItem();

            result.IsValid.ShouldBeFalse();

            error.ShouldSatisfyAllConditions(e => e.ErrorMessage.ShouldBe(ResourceMessages.PASSWORD_INVALID));


        }
    }
}
