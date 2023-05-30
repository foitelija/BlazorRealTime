using BlazorRealTimeData.Data;

namespace BlazorRealTimeData.Services
{
    public interface IMessageService
    {
        Task<List<Message>> GetMessagesAsync();
    }
}
