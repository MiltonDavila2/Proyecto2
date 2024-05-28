using Ecommerce.Modelos;
using Ecommerce.Utilidades;
using Microsoft.EntityFrameworkCore;


namespace Ecommerce.DataAcess
{
    public class EcommerceDbContext : DbContext
    {
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Direccion> Direcciones { get; set; }
        public DbSet<Tarjeta> Tarjetas { get; set; }
        public DbSet<Compra> Compras { get; set; }
        public DbSet<DetalleCompra> DetalleCompras { get; set; }
        public DbSet<Carrito> Carritos { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string conexionDb = $"Filename={ConexionDB.DevolverRuta("ecommerce.db")}";
            optionsBuilder.UseSqlite(conexionDb);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categoria>(entity =>
            {
                entity.HasKey(c => c.IdCategoria);
                entity.Property(c => c.IdCategoria).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Direccion>(entity =>
            {
                entity.HasKey(c => c.IdDireccion);
                entity.Property(c => c.IdDireccion).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Tarjeta>(entity =>
            {
                entity.HasKey(c => c.IdTarjeta);
                entity.Property(c => c.IdTarjeta).IsRequired().ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Producto>(entity => {
                entity.HasKey(c => c.IdProducto);
                entity.Property(c => c.IdProducto).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCategoria).WithMany(p => p.Productos)
                .HasForeignKey(p => p.IdCategoria);
            });

            modelBuilder.Entity<Compra>(entity => {
                entity.HasKey(c => c.IdCompra);
                entity.Property(c => c.IdCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefDireccion).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdDireccion);
                entity.HasOne(c => c.RefTarjeta).WithMany(p => p.Compras)
                .HasForeignKey(p => p.IdTarjeta);
            });


            modelBuilder.Entity<DetalleCompra>(entity => {
                entity.HasKey(c => c.IdDetalleCompra);
                entity.Property(c => c.IdDetalleCompra).IsRequired().ValueGeneratedOnAdd();
                entity.HasOne(c => c.RefCompra).WithMany(p => p.RefDetalleCompra)
                .HasForeignKey(p => p.IdCompra);
                entity.HasOne(c => c.RefProducto).WithMany(p => p.RefDetalleCompra)
               .HasForeignKey(p => p.IdProducto);
            });

            modelBuilder.Entity<Carrito>(entity =>
            {
                entity.HasKey(c => c.IdCarrito);
                entity.Property(c => c.IdCarrito).IsRequired().ValueGeneratedOnAdd();
            });


            modelBuilder.Entity<Categoria>().HasData(
                new Categoria { IdCategoria = 1, Descripcion = "Brocas", Imagen = "broca.svg" },
                new Categoria { IdCategoria = 2, Descripcion = "Agarradera", Imagen = "agarradera.svg" },
                new Categoria { IdCategoria = 3, Descripcion = "Bisagra", Imagen = "bisagra.svg" },
                new Categoria { IdCategoria = 4, Descripcion = "Cerradura", Imagen = "cerradura.svg" },
                new Categoria { IdCategoria = 5, Descripcion = "Chova", Imagen = "chova.svg" },
                new Categoria { IdCategoria = 6, Descripcion = "Disco", Imagen = "disco.svg" }
                );

            modelBuilder.Entity<Producto>().HasData(
                new Producto { 
                    IdProducto = 1, 
                    Nombre = "Broca para Pared Punta", 
                    Descripcion = "Broca de pared color dorado\r\nMedidas: 5mm D x 85mm L.\r\nPerfecto para bloque de concreto.\r\nTrabajos más exigentes.",
                    IdCategoria = 1,
                    Precio = 3,
                    Imagen = "producto1.jpg"
                },
                new Producto
                {
                    IdProducto = 2,
                    Nombre = "Broca para Perforar Vidrio",
                    Descripcion = "Para vidrio de 16 mm\r\nBroca metálica con punta de diamante\r\nMayor rendimiento y duración",
                    IdCategoria = 1,
                    Precio = 8,
                    Imagen = "producto2.jpg"
                }
               
                );
        }

       
    }
}
