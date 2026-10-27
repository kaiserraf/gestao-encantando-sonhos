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
            DateTime buyDate = DateTime.UtcNow;
            TicketRes t = new TicketRes(
                buyDate: buyDate,
                cleared: ticket.Cleared,
                mealId: ticket.MealId,
                buyerId: ticket.BuyerId
            );
            TicketRes data = await _ticketData.CreateTicket(t);
            return data;
        }

        public async Task<Boolean> DeleteTicket(long id) {
            return await _ticketData.DeleteTicket(id);
        }

        public async Task<List<TicketRes>> ReadAllTickets() {
            return await _ticketData.ReadAllTickets();
        }

        public async Task<TicketRes> ReadTicketById(long id) {
            return await _ticketData.ReadTicketById(id);
        }

        public async Task<List<TicketRes>> ReadTicketsByFilter(TicketFilters ticket) {
            if(ticket.BuyDateStart.HasValue) { 
                ticket.BuyDateStart = DateTime.SpecifyKind(ticket.BuyDateStart.Value, DateTimeKind.Utc);
            }
            if(ticket.BuyDateEnd.HasValue) { 
                ticket.BuyDateEnd = DateTime.SpecifyKind(ticket.BuyDateEnd.Value, DateTimeKind.Utc);
            }

            List<TicketRes> data = await _ticketData.ReadTicketsByFilter(ticket);
            return data;
        }
    }
}