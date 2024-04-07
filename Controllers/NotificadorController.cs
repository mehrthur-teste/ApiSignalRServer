using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSignalRServer.Model;
using ApiSignalRServer.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ApiSignalRServer.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotificadorController : Controller
    {
        private  IHubContext<NotificadorHub> _hub ;

        public NotificadorController(IHubContext<NotificadorHub> hub) {
            _hub = hub;
        }

        [HttpPost]
        public async Task<string> Notificar(NotificacaoModel mensagem) {

            try
            {
                await _hub.Clients.All.SendAsync("BroadcastMessage", mensagem);
                return "OK";
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
            }
        }
               
        
    }
}
