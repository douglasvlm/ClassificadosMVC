using Microsoft.EntityFrameworkCore;

namespace Classificados.Models
{
    public class Context : DbContext
    {   
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Classificado> Classificados { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Classificados;Integrated Security=True");

        }
    }
}
