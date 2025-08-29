namespace serverT2.Domain.Repository
{
    public interface IUnityOfWork
    {
        public Task Commit();

    }
}
