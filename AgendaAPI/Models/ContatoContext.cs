using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;

namespace AgendaAPI.Models
{
    public class ContatoContext : DbContext
    {
        public ContatoContext(DbContextOptions<ContatoContext> options)
            : base(options)
        {
        }
        
        public DbSet<Contato> Contatos { get; set; } = null!;
    }
}