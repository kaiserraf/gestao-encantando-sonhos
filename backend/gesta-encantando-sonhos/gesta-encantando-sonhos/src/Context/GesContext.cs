using gesta_encantando_sonhos.src.Models;
using Microsoft.EntityFrameworkCore;

/// <summary>
/// Contexto para o banco de dados, somente as classes que irão virar tabela estã aqui
/// </summary>

namespace gesta_encantando_sonhos.src.Context
{
    public class GesContext : DbContext
    {
        public GesContext(DbContextOptions<GesContext> options) : base(options){}

        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}