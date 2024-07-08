using ApiVentas.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiVentas.Data
{
    public class DbContextAPI:DbContext
    {

        public DbContextAPI(DbContextOptions<DbContextAPI> options) : base(options) { }


        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
