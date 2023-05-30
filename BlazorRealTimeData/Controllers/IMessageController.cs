using BlazorRealTimeData.Data;

namespace BlazorRealTimeData.Controllers
{
    public interface IMessageController
    {
        Task<List<Message>> GetMessageAsync();
    }
}
