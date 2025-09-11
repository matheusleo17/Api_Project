using serverT2.Domain.Repository.User;

namespace CommonTesteUtilities.Repositories
{
    public class UserWriteOnlyRespositoryBuilder
    {
        public static IUserWriteOnlyRespository Build()
        {
            var mock = new Moq.Mock<IUserWriteOnlyRespository>();

            return mock.Object;
        }
    }
}
