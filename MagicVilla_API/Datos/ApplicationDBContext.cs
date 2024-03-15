using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    public class ApplicationDBContext: DbContext
    {
        public DbSet<Villa> Villas { get; set; }

        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    nombre = "Villa real",
                    detalle = "Es verde",
                    imagenUrl = "",
                    ocupante = 5,
                    metrocuadrado = 50,
                    tarifa = 50,
                    amenidad = "",
                    fechaCreacion = DateTime.Now,
                    fechaActualizacion = DateTime.Now,
                },
                new Villa()
                {
                    Id = 2,
                    nombre = "Villa azul",
                    detalle = "Es azul",
                    imagenUrl = "",
                    ocupante = 6,
                    metrocuadrado = 25,
                    tarifa = 80,
                    amenidad = "",
                    fechaCreacion = DateTime.Now,
                    fechaActualizacion = DateTime.Now,
                }
                );
        }
    }
}
