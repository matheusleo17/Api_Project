using Moq;
using serverT2.Domain.Repository.User;

namespace CommonTesteUtilities.Repositories
{
    public class UserReadOnlyRepositoryBuilder
    {
        private readonly Mock<IUserReadOnlyRespository> _repository;
        public UserReadOnlyRepositoryBuilder()
        {
            _repository = new Mock<IUserReadOnlyRespository>();
        }
        public  IUserReadOnlyRespository Build()
        {
           return _repository.Object;
        }
    }
}
