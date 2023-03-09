using System.Data.Common;

namespace dotnet_dapper.Repository
{
    public interface ICommandExecuter
    {
        T ExecuteCommand<T>(Func<DbConnection, T> task);
        Task ExecuteCommandAsync(Func<DbConnection, Task> task);
        Task<T> ExecuteCommandAsync<T>(Func<DbConnection, Task<T>> task);
    }
}
