using ExamenAWSConciertoMauricio.Data;
using ExamenAWSConciertoMauricio.Models;
using Microsoft.EntityFrameworkCore;

namespace ExamenAWSConciertoMauricio.Repositories
{
    public class RepositoryConciertos
    {
        private ConciertosContext context;

        public RepositoryConciertos(ConciertosContext context)
        {
            this.context = context;
        }

        public async Task<List<Evento>> GetEventosAsync()
        {
            //https://bucket-examen-conciertos.s3.amazonaws.com/
            List<Evento> eventos = await this.context.Eventos.ToListAsync();
            foreach (Evento evento in eventos)
            {
                evento.Imagen = "https://bucket-examen-conciertos.s3.amazonaws.com/" + evento.Imagen;
            }
            return eventos;
        }

        public async Task<List<Evento>> FindEventosByCategoriaAsync(int idcategoria)
        {
            List<Evento> eventos = await this.context.Eventos.Where(x => x.IdCategoria == idcategoria).ToListAsync();
            foreach (Evento evento in eventos)
            {
                evento.Imagen = "https://bucket-examen-conciertos.s3.amazonaws.com/" + evento.Imagen;
            }
            return eventos;
        }

        public async Task<List<CategoriaEvento>> GetCategoriasEventoAsync()
        {
            return await this.context.CategoriasEvento.ToListAsync();
        }
    }
}
