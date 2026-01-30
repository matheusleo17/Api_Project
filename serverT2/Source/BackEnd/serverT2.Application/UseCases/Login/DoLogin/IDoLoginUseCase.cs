using serverT2.Communication.Requests;
using serverT2.Communication.Responses;

namespace serverT2.Application.UseCases.Login.DoLogin
{
    public interface IDoLoginUseCase
    {
        Task<ResponseRegisterdUserJson> Execute(RequestLoginJson request);
       
    }
}
