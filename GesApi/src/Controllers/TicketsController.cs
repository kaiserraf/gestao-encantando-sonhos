using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using gesApi.src.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GesApi.src.Controllers {
    [ApiController]
    [Route("controller")]
    public class TicketsController {
        // injeção de dependencia

        // criar
        [HttpPost("NewTicket")]
        public async Task<IActionResult> Register([FromBody] TicketReq ticket) {
            try
            {
                
            }
            catch (System.Exception)
            {
                
                throw;
            }
            
            
            throw new NotImplementedException();
        }
        // ler
        // ler por id
        // ler por filtros
        // editar
        // deletar
    }
}