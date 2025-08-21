using Ap2._0.Communication.Requests;
using AutoMapper;
using Api2._0.Domain.Entities;
using System.Security.Cryptography.X509Certificates;


namespace api2._0.Application.Services.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestDomain();
        }
        private void RequestDomain()
        {
            CreateMap<RequestRegisterUserJson, Api2._0.Domain.Entities.User>()
                .ForMember(x => x.Password, opt=> opt.Ignore());
        }
    }
}
