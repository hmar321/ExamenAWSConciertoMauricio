using ExamenAWSConciertoMauricio.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenAWSConciertoMauricio.Data
{
    public class ConciertosContext : DbContext
    {
        public ConciertosContext(DbContextOptions<ConciertosContext> options) : base(options)
        {
        }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<CategoriaEvento> CategoriasEvento { get; set; }
    }
}
