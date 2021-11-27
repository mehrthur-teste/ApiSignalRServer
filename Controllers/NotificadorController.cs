using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiSignalRServer.Model;
using ApiSignalRServer.Service;
using Microsoft.AspNetCore.Mvc;

namespace ApiSignalRServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NotificadorController : Controller
    {
        

        public NotificadorController() {
            
        }

        [HttpPost]
        public async Task<string> Notificar(NotificacaoModel mensagem) {
            NotificadorHub _notificadorHub = new NotificadorHub();
           return await _notificadorHub.BroadcastMessage(mensagem);
        }
               
        
    }
}
