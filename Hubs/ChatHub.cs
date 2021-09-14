using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using WebChat.Data;
using WebChat.Models;

namespace WebChat.Hubs
{
    public class ChatHub : Hub
    {
        Context _context;
        IHttpContextAccessor _httpContextAcessor;
        public ChatHub(Context context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task SendMessage(Message m){
            
            m.Datetime = DateTime.Now;
            _context.Message.Add(m);
            _context.SaveChanges();
            await Clients.All.SendAsync("ReceiveMessage", m);
        }

        public string GetConnectionId() => Context.ConnectionId;
        
    }
}