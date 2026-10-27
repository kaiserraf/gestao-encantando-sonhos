using gesApi.src.DTOs;
using GesApi.src.DTOs.Ticket;

namespace GesApi.src.Data.DataInterface {
    public interface ITicketsData {
        public Task<TicketRes> CreateTicket(TicketRes ticket);
        public Task<List<TicketRes>> ReadAllTickets();
        public Task<TicketRes> ReadTicketById(long id);
        public Task<List<TicketRes>> ReadTicketsByFilter(TicketFilters ticket);
        public Task<Boolean> ClearedTicketById(long id, bool cleared, DateTime clearedDate);
        public Task<Boolean> DeleteTicket(long id);
    }
}