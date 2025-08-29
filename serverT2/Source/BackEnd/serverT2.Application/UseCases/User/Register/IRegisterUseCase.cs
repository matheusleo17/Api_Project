using serverT2.Communication.Requests;
using serverT2.Communication.Responses;

namespace serverT2.Application.UseCases.User.Register
{
    public interface IRegisterUseCase
    {
        public Task<ResponseRegisterdUserJson> Execute(RequestRegisterUserJson request);

    }
}
