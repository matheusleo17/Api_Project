using serverT2.Domain.Repository;

namespace CommonTesteUtilities.Repositories
{
    public  class UnityOfWorkBuilder
    {
        public static IUnityOfWork Build()
        {
          var mock = new Moq.Mock<IUnityOfWork>();

            return mock.Object;
        }
    }
}
