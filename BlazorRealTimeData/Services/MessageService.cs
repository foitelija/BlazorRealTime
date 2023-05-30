using BlazorRealTimeData.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TableDependency.SqlClient;
using TableDependency.SqlClient.Base.EventArgs;

namespace BlazorRealTimeData.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _dbContext;
        private readonly SqlTableDependency<Message> _dependency;
        private readonly string _connectionString;
        public MessageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
            _connectionString = "Server=localhost;Database=IncomingMessages;trusted_connection=true;Integrated Security=SSPI;MultipleActiveResultSets=True;TrustServerCertificate=True";
            _dependency = new SqlTableDependency<Message>(_connectionString, "Messages");
            _dependency.OnChanged += Changed;
            _dependency.Start();
        }

        private void Changed(object sender, RecordChangedEventArgs<Message> e)
        {
            int value = 0;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _dbContext.Messages.AsNoTracking().ToListAsync();
        }
    }
}
