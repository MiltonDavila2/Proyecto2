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
                },
                new Producto
                {
                    IdProducto = 3,
                    Nombre = "Agarradera con Toallero para Puerta de Vidrio Templado",
                    Descripcion = "Agarradera con toallero 2 en 1 para puertas de vidrio\r\nTubo de 19 mm que ofrece un gran soporte\r\nDiseño simple pero elegante",
                    IdCategoria = 2,
                    Precio = 30,
                    Imagen = "producto3.jpg"

                },
                new Producto
                {
                    IdProducto = 4,
                    Nombre = "Agarradera de Acero Inoxidable",
                    Descripcion = "Vaciada Tipo Barra",
                    IdCategoria = 2,
                    Precio = 1,
                    Imagen = "producto4.jpg"
                },
                new Producto
                {
                    IdProducto= 5,
                    Nombre= "Bisagra de Suelo Jackson 120 KG",
                    Descripcion = "Bisagra de suelo jackson 120 kg para puertas de aluminio y cristal templado modernas.\r\nLogra un sistema de cierre automático y de fácil instalación\r\nDimensiones de la caja: 32 x 10 x 10 cm",
                    IdCategoria = 3,
                    Precio = 75,
                    Imagen = "producto5.jpg"
                },
                new Producto
                {
                    IdProducto = 6,
                    Nombre = "Bisagra de Suelo King 8300",
                    Descripcion = "Bomga King 8300\r\nMedidas: 950*2100 mm aprox.\r\nCobertura de 180°",
                    IdCategoria = 3,
                    Precio = 50,
                    Imagen = "producto6.jpg"
                },
                new Producto
                {
                    IdProducto = 7,
                    Nombre = "Cerradura de Puerta para Baño",
                    Descripcion = "Cerradura de puerta para baño y entradas de dormitorio.\r\nDimensiones de la caja: 20 x 17 cm (Ancho x Alto).\r\nIncluye un juego de 3 llaves.",
                    IdCategoria = 4,
                    Precio = 11,
                    Imagen = "producto7.jpg"
                },
                new Producto
                {
                    IdProducto = 8,
                    Nombre = "Cerradura Pico de Loro",
                    Descripcion = "Cerradura pico de loro hecho en metal de calidad que ofrece una estabilidad y mayor seguridad.\r\nColores: natural, blanco, negro.\r\nIdeal para puertas de aluminio, pvc, madera, corredizas, etc.",
                    IdCategoria = 4,
                    Precio = 15,
                    Imagen = "producto8.jpg"
                },
                new Producto
                {
                    IdProducto = 9,
                    Nombre = "Chova para Impermeabilizar",
                    Descripcion = "Chova para impermeabilizar techo, pared, piso y más\r\nDimensiones: 20 centímetros x 10 metros.\r\nEvita superficies húmedas y mantén tu patrimonio libre del deterioro.",
                    IdCategoria = 5,
                    Precio = 25,
                    Imagen = "producto9.jpg"
                },
                new Producto
                {
                    IdProducto = 10,
                    Nombre = "Chova Tapa Goteras",
                    Descripcion = "Sella fisuras, uniones, juntas, traslapes, etc.\r\n10 m x 10 cm Marca Alumband\r\nDuctos de ventilación y aire acondicionado.",
                    IdCategoria = 5,
                    Precio = 14,
                    Imagen = "producto10.jpg"
                },
                new Producto
                {
                    IdProducto = 11,
                    Nombre = "Disco Diamante",
                    Descripcion = "Disco diamante continuo\r\nDisco de 4.5 pulgadas\r\nMáximo rpm 13200",
                    IdCategoria = 6,
                    Precio = 6,
                    Imagen = "producto11.jpg"
                },
                new Producto
                {
                    IdProducto = 12,
                    Nombre = "Disco Diamante Segmentado",
                    Descripcion = "Disco diamante segmentado de 4.5 para corte de ladrillo, piedra, granito y otro material de gran dureza.\r\nDimensiones: 115X10X22.23MM\r\nMáx rpm: 13200",
                    IdCategoria = 6,
                    Precio = 4,
                    Imagen = "producto12.jpg"
                }


                );
        }

       
    }
}
