using serverT2.Application.Services.AutoMapper;
using AutoMapper;


namespace CommonTesteUtilities.Mapper
{
    public class MapperBuilder
    {
        public static IMapper Build()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapping());

            }).CreateMapper();
        }
    }
}
