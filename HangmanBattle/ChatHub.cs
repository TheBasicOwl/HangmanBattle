using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace HangmanBattle
{
    public class ChatHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", $"{user}: {message}");
        }

        public override Task OnConnectedAsync()
        {
            Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId + " Has Joind");
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception exception)
        {
            Clients.All.SendAsync("ReceiveMessage", Context.ConnectionId + " Has Left");
            return base.OnDisconnectedAsync(exception);
        }
    }
}