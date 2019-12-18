using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HangmanBattle
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId, message);
        }

        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("ReceiveMessage", "Server", Context.ConnectionId + "Has Joind");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            return base.OnDisconnectedAsync(exception);
        }
    }
}