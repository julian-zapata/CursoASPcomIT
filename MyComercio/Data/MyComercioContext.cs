using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyComercio.Models;

namespace MyComercio.Data
{
    public class MyComercioContext : DbContext
    {
        public MyComercioContext() : base()
        {
            initContext();
        }

        public MyComercioContext(DbContextOptions<MyComercioContext> options)
            : base(options)
        {
            initContext();
        }

        public DbSet<MyComercio.Models.BasePersona> Persona { get; set; }

        public DbSet<MyComercio.Models.Cliente> Cliente { get; set; }

        public DbSet<MyComercio.Models.Vendedor> Vendedor { get; set; }

        public DbSet<MyComercio.Models.Pais> Pais { get; set; }

        public DbSet<MyComercio.Models.Ciudad> Ciudad { get; set; }



             //Configuracion para validar el Campo Unique sin hacer inyeccion de dependencia
        protected override void OnConfiguring(DbContextOptionsBuilder option) => option.UseSqlServer(connectionString);

        private string connectionString;

        private void initContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("MyComercioContext").ToString();
        }

        public DbSet<MyComercio.Models.CategoriaProducto> CategoriaProducto { get; set; }

        public DbSet<MyComercio.Models.Producto> Producto { get; set; }

        public DbSet<MyComercio.Models.Venta> Venta { get; set; }

        public DbSet<MyComercio.Models.VentaDetalle> VentaDetalle { get; set; }
    }
}
