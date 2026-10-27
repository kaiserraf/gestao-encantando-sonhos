using gesApi.src.Data.ModelsEFCore;
using gesApi.src.DTOs;
using GesApi.src.Data.DataInterface;
using GesApi.src.DTOs.Ticket;
using GesApi.src.Services.ServicesInterface;

namespace GesApi.src.Services {
    public class TicketService : ITicketService {
        private readonly ITicketsData _ticketData;
        public TicketService(ITicketsData ticketData) {
            _ticketData = ticketData;
        }

        public async Task<Boolean> ClearedTicketById(long id, bool cleared) {
            DateTime clearedDate = DateTime.UtcNow;
            return await _ticketData.ClearedTicketById(id, true, clearedDate);
        }

        public async Task<TicketRes> CreateTicket(TicketReq ticket) {
            Ticket t = new Ticket(
                buyDate: DateTime.UtcNow,
                cleared: ticket.Cleared,
                mealId: ticket.MealId,
                buyerId: ticket.BuyerId
            );
            
            Ticket data = await _ticketData.CreateTicket(t);
            return TransformToResponse(data);
        }

        public async Task<Boolean> DeleteTicket(long id) {
            return await _ticketData.DeleteTicket(id);
        }

        public async Task<List<TicketRes>> ReadAllTickets() {
            List<Ticket> data = await _ticketData.ReadAllTickets();
            return data.Select(TransformToResponse).ToList();
        }

        public async Task<TicketRes> ReadTicketById(long id) {
            Ticket data = await _ticketData.ReadTicketById(id);
            return TransformToResponse(data);
        }

        public async Task<List<TicketRes>> ReadTicketsByFilter(TicketFilters ticket) {
            if(ticket.BuyDateStart.HasValue) { 
                ticket.BuyDateStart = DateTime.SpecifyKind(ticket.BuyDateStart.Value, DateTimeKind.Utc);
            }
            if(ticket.BuyDateEnd.HasValue) { 
                ticket.BuyDateEnd = DateTime.SpecifyKind(ticket.BuyDateEnd.Value, DateTimeKind.Utc);
            }

            List<Ticket> data = await _ticketData.ReadTicketsByFilter(ticket);
            return data.Select(TransformToResponse).ToList();
        }

        public static TicketRes TransformToResponse(Ticket ticket) {
            return new TicketRes(
                ticket.Id,
                ticket.BuyDate,
                ticket.Cleared,
                ticket.ClearedDate,
                ticket.MealId,
                ticket.BuyerId
            );
        }

    }
}