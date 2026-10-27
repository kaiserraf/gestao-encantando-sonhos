using gesApi.src.DTOs;
using GesApi.src.DTOs.Ticket;
using GesApi.src.Services.ServicesInterface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GesApi.src.Controllers {
    [ApiController]
    [Route("controller")]
    public class TicketsController : ControllerBase {
        private readonly ITicketService _ticketService;
        public TicketsController(ITicketService ticketService) {
            _ticketService = ticketService;
        }

        [HttpPost("NewTicket")]
        public async Task<IActionResult> Register([FromBody] TicketReq ticket) {
            try {
                TicketRes res = await _ticketService.CreateTicket(ticket);
                return Created("", res);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
        }

        [HttpGet("Tickets")]
        public async Task<IActionResult> ReadAllTickets() {
            try {
                List<TicketRes> res = await _ticketService.ReadAllTickets();
                return Ok(res);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
        }

        [HttpGet("Tickets/{id:long}")]
        public async Task<IActionResult> ReadTicketById([FromRoute] long id) {
            try {
                TicketRes res = await _ticketService.ReadTicketById(id);
                return Ok(res);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
        }

        [HttpGet("TicketsFilter")]
        public async Task<IActionResult> GetByFilters([FromQuery] TicketFilters ticket) {
            try {
                List<TicketRes> res = await _ticketService.ReadTicketsByFilter(ticket);
                return Ok(res);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
        }
        
        [HttpPost("TicketCleared/{id:long}")]
        public async Task<IActionResult> ClearedTicketById([FromRoute] long id, [FromBody] bool cleared) {
            try {
                Boolean res = await _ticketService.ClearedTicketById(id, cleared);
                return Ok(res);
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
            catch (KeyNotFoundException knfe) {
                return StatusCode(StatusCodes.Status404NotFound, knfe.Message);
            }
        }

        [HttpDelete("Tickets/{id:long}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] long id) {
            try {
                bool res = await _ticketService.DeleteTicket(id);
                return Ok("DELETED");
            }
            catch (OperationCanceledException ope) {
                return StatusCode(StatusCodes.Status500InternalServerError, ope.Message);
            }
            catch (DbUpdateException dbe) {
                return StatusCode(StatusCodes.Status500InternalServerError, dbe.Message);
            }
            catch (KeyNotFoundException knfe) {
                return StatusCode(StatusCodes.Status404NotFound, knfe.Message);
            }
        }
    }
}