using gesApi.src.Data.ModelsEFCore;
using gesApi.src.DTOs;
using GesApi.src.DTOs.Ticket;

namespace GesApi.src.Data.DataInterface {
    public interface ITicketsData {
        public Task<Ticket> CreateTicket(Ticket ticket);
        public Task<List<Ticket>> ReadAllTickets();
        public Task<Ticket> ReadTicketById(long id);
        public Task<List<Ticket>> ReadTicketsByFilter(TicketFilters ticket);
        public Task<Boolean> ClearedTicketById(long id, bool cleared, DateTime clearedDate);
        public Task<Boolean> DeleteTicket(long id);
    }
}