using EcoOcean.Models;
using Microsoft.EntityFrameworkCore;


namespace EcoOcean.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Voluntario> Voluntario { get; set; } 

        public DbSet<Area> Area { get; set; }

        public DbSet<Coleta> Coleta { get; set; }

        public DbSet<Evento> Evento { get; set; }

        public DbSet<Administrador> Administrador { get; set; }

        public DbSet<Participacao> Participacao { get; set;}


    }
}
