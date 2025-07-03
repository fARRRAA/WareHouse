﻿using KvalikApi.Model;
using Microsoft.AspNetCore.SignalR;

namespace KvalikApi.Hubs
{
    public class ChatHub : Hub
    {
        private static Dictionary<int, string> Users = new Dictionary<int, string>();
        public override Task OnConnectedAsync()
        {
            return base.OnConnectedAsync();
        }
        public async Task RegisterUser(User user)
        {
            Users[user.id] = $"{Context.ConnectionId}_{user.id}";
        }
        public async Task SendMessage(User user, UserChatMessage message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public async Task SendMessageToUser(User sender, User recipient, UserChatMessage message)
        {
            if (Users.TryGetValue(recipient.id, out var connectionId))
            {
                await Clients.Client(connectionId).SendAsync("ReceiveMessageFromUser", sender, recipient, message);

            }
        }
    }
}
