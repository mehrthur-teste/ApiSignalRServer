using ApiSignalRServer.Model;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace ApiSignalRServer.Service
{
    public class NotificadorHub : Hub
    {
        public async Task<string> BroadcastMessage(NotificacaoModel message) => await Task.Run(async () =>
        {
            try {
                await Clients.All.SendAsync("BroadcastMessage", message);
                return "OK";
            }
            catch (Exception ex) {
                return  ex.Message.ToString();
            }
        });

        //  public async Task BroadcastMessage(NotificacaoModel message) => await Clients.All.SendAsync("BroadcastMessage", message);

    }
}
