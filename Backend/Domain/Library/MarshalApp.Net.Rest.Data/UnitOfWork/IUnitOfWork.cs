namespace MarshalApp.Net.Rest.Infrastructure.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
    }
}