using BlazorRealTimeData.Data;
using Microsoft.EntityFrameworkCore;

namespace BlazorRealTimeData.Services
{
    public class MessageService : IMessageService
    {
        private readonly AppDbContext _dbContext;

        public MessageService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Message>> GetMessagesAsync()
        {
            return await _dbContext.Messages.AsNoTracking().ToListAsync();
        }
    }
}
