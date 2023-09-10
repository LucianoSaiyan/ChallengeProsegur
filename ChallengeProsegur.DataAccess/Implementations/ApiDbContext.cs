using ChallengeProsegur.Abtractions;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChallengeProsegur.Entities.Model;

namespace ChallengeProsegur.DataAccess.Implementations
{
    public class ApiDbContext : DbContext
    {
        #region DbSets

        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Pedido> Pedido { get; set; }
        public DbSet<Material> Material { get; set; }
        public DbSet<ItemPedido> ItemPedido { get; set; }
        public DbSet<Producto> Productos { get; set; }

        #endregion

        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {
        }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Ignorara la clase Entity para que no genere una clase
            modelBuilder.Ignore<Entity>();
            
            modelBuilder.Entity<ItemPedido>()
                    .Property(i => i.Precio)
                    .HasColumnType("decimal(18, 2)");

            modelBuilder.Entity<ItemPedido>()
                    .Property(i => i.Impuestos)
                    .HasColumnType("decimal(18, 2)");


            modelBuilder.Entity<Producto>()
                    .Property(i => i.PrecioBase)
                    .HasColumnType("decimal(18, 2)");

            base.OnModelCreating(modelBuilder);
        }

    }
}
