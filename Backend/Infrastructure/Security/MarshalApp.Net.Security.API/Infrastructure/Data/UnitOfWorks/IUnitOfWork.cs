namespace MarshalApp.Net.Security.API.Infrastructure.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        bool Save();
    }
}