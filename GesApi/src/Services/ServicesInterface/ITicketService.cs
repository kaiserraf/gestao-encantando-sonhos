using gesApi.src.DTOs;
using GesApi.src.DTOs.Ticket;

namespace GesApi.src.Services.ServicesInterface {
    public interface ITicketService {
        public Task<TicketRes> CreateTicket(TicketReq ticket);
        public Task<List<TicketRes>> ReadAllTickets();
        public Task<TicketRes> ReadTicketById(long id);
        public Task<List<TicketRes>> ReadTicketsByFilter(TicketFilters ticket);
        public Task<Boolean> ClearedTicketById(long id, bool cleared);
        public Task<Boolean> DeleteTicket(long id);
    }
}