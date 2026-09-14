namespace gesta_encantando_sonhos.src.Models
{
    public class Buyer : User
    {
        public long EmployeeId { get; set; }
        public Employee Employee { get; set; }
        public long TicketId { get; set; }
        public Ticket Ticket { get; set; }
    }
}