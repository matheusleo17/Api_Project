using serverT2.Communication.Requests;
using AutoMapper;
using serverT2.Domain.Entities;
using System.Security.Cryptography.X509Certificates;


namespace serverT2.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestDomain();
        }
        private void RequestDomain()
        {
            CreateMap<RequestRegisterUserJson, serverT2.Domain.Entities.User>()
                .ForMember(x => x.Password, opt=> opt.Ignore());
        }
    }
}
