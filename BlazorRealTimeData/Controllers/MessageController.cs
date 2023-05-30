using BlazorRealTimeData.Data;
using BlazorRealTimeData.Services;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRealTimeData.Controllers
{
    public class MessageController : IMessageController
    {
        private readonly IMessageService _service;

        public MessageController(IMessageService service)
        {
            _service = service;
        }
        [HttpGet]
        public Task<List<Message>> GetMessageAsync()
        {
            return _service.GetMessagesAsync();
        }
    }
}
