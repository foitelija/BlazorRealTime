using BlazorRealTimeData.Data;
using BlazorRealTimeData.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace BlazorRealTimeData.Services
{
    public class MessageService : IMessageService
    {
        private AppDbContext? _dbContext;
        private readonly IHubContext<MessageHub> _context;
        private readonly IServiceScopeFactory _scopeFactory;
        private readonly SqlTableDependency<Message> _dependency;
        private readonly string _connectionString;
        public MessageService(IHubContext<MessageHub> context, IServiceScopeFactory scopeFactory)
        {
            _context = context;
            _scopeFactory = scopeFactory;
            _connectionString = "Server=localhost;Database=IncomingMessages;trusted_connection=true;Integrated Security=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True";
            _dependency = new SqlTableDependency<Message>(_connectionString, "Messages");
            _dependency.OnChanged += Changed;
            _dependency.Start();
        }

        private async void Changed(object sender, RecordChangedEventArgs<Message> e)
        {
            var messages = await GetMessagesAsync();
            await _context.Clients.All.SendAsync("RefreshMessages", messages);
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            using (var scope = _scopeFactory.CreateScope())
            {
                _dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                return await _dbContext.Messages.AsNoTracking().ToListAsync();
            }
        }
    }
}
