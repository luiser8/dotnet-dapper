using System.Data.Common;

namespace dotnet_dapper.Shared
{
    public sealed class CommandExecuter : ICommandExecuter, IDisposable, IAsyncDisposable
    {
        private readonly Lazy<DbConnection> _lazyConnection;

        public CommandExecuter(Lazy<DbConnection> lazyConnection)
        {
            _lazyConnection = lazyConnection;
        }

        public T ExecuteCommand<T>(Func<DbConnection, T> task)
        {
            var connection = _lazyConnection.Value;
            return task(connection);
        }

        public async Task ExecuteCommandAsync(Func<DbConnection, Task> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var connection = _lazyConnection.Value;
            await task(connection);
        }

        public async Task<T> ExecuteCommandAsync<T>(Func<DbConnection, Task<T>> task)
        {
            if (task == null)
                throw new ArgumentNullException(nameof(task));

            var connection = _lazyConnection.Value;
            return await task(connection);
        }

        public void Dispose()
        {
            if (_lazyConnection.IsValueCreated)
                _lazyConnection.Value.Dispose();
        }

        public async ValueTask DisposeAsync()
        {
            if (_lazyConnection.IsValueCreated)
                await _lazyConnection.Value.DisposeAsync();
        }
    }
}
