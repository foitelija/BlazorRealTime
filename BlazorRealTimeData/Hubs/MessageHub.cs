using BlazorRealTimeData.Data;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace BlazorRealTimeData.Hubs
{
    public class MessageHub : Hub
    {

        public async Task RefreshMessages(List<Message> messages)
        {
            await Clients.All.SendAsync("RefreshMessages", messages);
        }
    }
}
