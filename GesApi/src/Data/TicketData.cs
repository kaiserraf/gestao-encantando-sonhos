using gesApi.src.Config;
using gesApi.src.Data.ModelsEFCore;
using gesApi.src.DTOs;
using GesApi.src.Data.DataInterface;
using GesApi.src.DTOs.Ticket;
using Microsoft.EntityFrameworkCore;

namespace GesApi.src.Data {
    public class TicketData : ITicketsData {
        private readonly GesContext _context;
        public TicketData(GesContext context) {
            _context = context;
        }

        public async Task<TicketRes> CreateTicket(TicketRes ticket) {
            await _context.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return ticket;
        }

        public async Task<bool> DeleteTicket(long id) {
            Ticket ticketDb = await _context.Tickets.FindAsync(id);
            if(ticketDb is null) throw new KeyNotFoundException("ESSE TICKET NÃO EXISTE");
            _context.Remove(ticketDb);
            _context.SaveChanges();
            return true;
        }

        public async Task<List<TicketRes>> ReadAllTickets() {
            return await _context.Tickets
            .Select(t => new TicketRes(
                t.Id,
                t.BuyDate,
                t.Cleared,
                t.ClearedDate,
                t.MealId,
                t.BuyerId
            )).ToListAsync();
        }

        public async Task<TicketRes> ReadTicketById(long id) {
            return await _context.Tickets
            .Where(t => t.Id == id)
            .Select(t => new TicketRes(
               t.Id,
               t.BuyDate,
               t.Cleared,
               t.ClearedDate,
               t.MealId,
               t.BuyerId
            )).FirstOrDefaultAsync();
        }

        public async Task<List<TicketRes>> ReadTicketsByFilter(TicketFilters ticket) {
            IQueryable<Ticket> query = _context.Tickets.AsNoTracking();

            if(ticket.Cleared.HasValue) query = query.Where(t => t.Cleared == ticket.Cleared.Value); 
            if(ticket.MealId.HasValue) query = query.Where(t => t.MealId == ticket.MealId.Value); 
            if(ticket.BuyerId.HasValue) query = query.Where(t => t.BuyerId == ticket.BuyerId.Value); 
            if(ticket.BuyDateStart.HasValue) query = query.Where(t => t.BuyDate >= ticket.BuyDateStart.Value); 
            if(ticket.BuyDateEnd.HasValue) query = query.Where(t => t.BuyDate <= ticket.BuyDateEnd.Value); 

            return await query.OrderByDescending(t => t.BuyDate)
            .Select(t => new TicketRes(
               t.Id,
               t.BuyDate,
               t.Cleared,
               t.ClearedDate,
               t.MealId,
               t.BuyerId
            )).ToListAsync();
        }

        public async Task<Boolean> ClearedTicketById(long id, bool cleared, DateTime clearedDate) {
            Ticket ticket = await _context.Tickets.FindAsync(id);
            if(ticket is null) throw new KeyNotFoundException();

            ticket.Cleared = cleared;
            ticket.ClearedDate = clearedDate;

            await _context.SaveChangesAsync();

            return true;
        }
    }
}