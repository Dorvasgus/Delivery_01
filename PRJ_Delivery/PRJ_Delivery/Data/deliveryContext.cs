using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PRJ_Delivery.Models;

namespace PRJ_Delivery.Data
{
    public partial class deliveryContext : DbContext
    {
        public deliveryContext()
        {
        }

        public deliveryContext(DbContextOptions<deliveryContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Cliente> Clientes { get; set; } = null!;
        public virtual DbSet<DetallePedido> DetallePedidos { get; set; } = null!;
        public virtual DbSet<Factura> Facturas { get; set; } = null!;
        public virtual DbSet<Funcionario> Funcionarios { get; set; } = null!;
        public virtual DbSet<Localidad> Localidads { get; set; } = null!;
        public virtual DbSet<Pedido> Pedidos { get; set; } = null!;
        public virtual DbSet<Persona> Personas { get; set; } = null!;
        public virtual DbSet<Producto> Productos { get; set; } = null!;
        public virtual DbSet<TipoVehiculo> TipoVehiculos { get; set; } = null!;
        public virtual DbSet<Vehiculo> Vehiculos { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Name=ConnectionStrings:Default");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.HasKey(e => e.IdCliente);

                entity.ToTable("Cliente");

                entity.HasIndex(e => e.UserName, "IX_Cliente")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "IX_Cliente_1")
                    .IsUnique();

                entity.Property(e => e.IdCliente).ValueGeneratedNever();

                entity.Property(e => e.Nit).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.RazonSocial).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.Clientes)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Cliente_Localidad");
            });

            modelBuilder.Entity<DetallePedido>(entity =>
            {
                entity.HasKey(e => e.IdDetallePedido);

                entity.ToTable("DetallePedido");

                entity.Property(e => e.IdDetallePedido).ValueGeneratedNever();

                entity.Property(e => e.Detalles).HasMaxLength(50);

                entity.HasOne(d => d.TipoProductoNavigation)
                    .WithMany(p => p.DetallePedidos)
                    .HasForeignKey(d => d.TipoProducto)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DetallePedido_DetallePedido");
            });

            modelBuilder.Entity<Factura>(entity =>
            {
                entity.HasKey(e => e.IdFactura);

                entity.ToTable("Factura");

                entity.Property(e => e.IdFactura).ValueGeneratedNever();

                entity.Property(e => e.Detalle).HasMaxLength(50);

                entity.Property(e => e.EstadodelPedido).HasMaxLength(50);

                entity.Property(e => e.FechaHoraEmision).HasColumnType("date");

                entity.Property(e => e.Nit).HasMaxLength(50);
            });

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.HasKey(e => e.IdFuncionario);

                entity.ToTable("Funcionario");

                entity.HasIndex(e => e.UserName, "IX_Funcionario")
                    .IsUnique();

                entity.HasIndex(e => e.Password, "IX_Funcionario_1")
                    .IsUnique();

                entity.Property(e => e.IdFuncionario).ValueGeneratedNever();

                entity.Property(e => e.Correo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Rol).HasMaxLength(50);

                entity.Property(e => e.UserName).HasMaxLength(50);

                entity.Property(e => e.Vehiculo).HasColumnName("vehiculo");

                entity.HasOne(d => d.VehiculoNavigation)
                    .WithMany(p => p.Funcionarios)
                    .HasForeignKey(d => d.Vehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Funcionario_Vehiculo");
            });

            modelBuilder.Entity<Localidad>(entity =>
            {
                entity.HasKey(e => e.IdLocalidad);

                entity.ToTable("Localidad");

                entity.Property(e => e.IdLocalidad).ValueGeneratedNever();

                entity.Property(e => e.Barrio).HasMaxLength(50);

                entity.Property(e => e.Calle).HasMaxLength(50);

                entity.Property(e => e.Zona).HasMaxLength(50);
            });

            modelBuilder.Entity<Pedido>(entity =>
            {
                entity.HasKey(e => e.IdPedido);

                entity.ToTable("Pedido");

                entity.Property(e => e.IdPedido).ValueGeneratedNever();

                entity.Property(e => e.Calle).HasMaxLength(50);

                entity.Property(e => e.FechaHoraCreacion)
                    .HasColumnType("date")
                    .HasColumnName("fechaHoraCreacion");

                entity.Property(e => e.FechaHoraEntrega)
                    .HasColumnType("date")
                    .HasColumnName("fechaHoraEntrega");

                entity.Property(e => e.NombreCliente).HasMaxLength(50);

                entity.Property(e => e.Numero).HasMaxLength(50);

                entity.Property(e => e.TelefonoCliente).HasColumnName("telefonoCliente");

                entity.HasOne(d => d.FacturaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Factura)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_factura_Pedido");

                entity.HasOne(d => d.IdPedidoNavigation)
                    .WithOne(p => p.Pedido)
                    .HasForeignKey<Pedido>(d => d.IdPedido)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_DetallePedido");

                entity.HasOne(d => d.LocalidadNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Localidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Localidad");

                entity.HasOne(d => d.PersonaNavigation)
                    .WithMany(p => p.Pedidos)
                    .HasForeignKey(d => d.Persona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Pedido_Persona");
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona);

                entity.ToTable("Persona");

                entity.Property(e => e.IdPersona).ValueGeneratedNever();

                entity.Property(e => e.Apellido).HasMaxLength(50);

                entity.Property(e => e.Nombre).HasMaxLength(50);

                entity.Property(e => e.NumeroIdentidad).HasMaxLength(50);

                entity.HasOne(d => d.IdPersonaNavigation)
                    .WithOne(p => p.Persona)
                    .HasForeignKey<Persona>(d => d.IdPersona)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Cliente");

                entity.HasOne(d => d.RolNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.Rol)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Persona_Funcionario");
            });

            modelBuilder.Entity<Producto>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.PizzaFamiliar)
                    .HasMaxLength(50)
                    .HasColumnName("pizzaFamiliar");

                entity.Property(e => e.PizzaMediana).HasMaxLength(50);

                entity.Property(e => e.PizzaPequeña).HasMaxLength(50);
            });

            modelBuilder.Entity<TipoVehiculo>(entity =>
            {
                entity.HasKey(e => e.IdTipoVehi);

                entity.ToTable("TipoVehiculo");

                entity.Property(e => e.IdTipoVehi).ValueGeneratedNever();

                entity.Property(e => e.Nombre).HasMaxLength(50);
            });

            modelBuilder.Entity<Vehiculo>(entity =>
            {
                entity.HasKey(e => e.IdVehiculo);

                entity.ToTable("Vehiculo");

                entity.Property(e => e.IdVehiculo).ValueGeneratedNever();

                entity.Property(e => e.Licencia).HasMaxLength(50);

                entity.Property(e => e.Modelo)
                    .HasMaxLength(50)
                    .HasColumnName("modelo");

                entity.Property(e => e.Patente).HasMaxLength(50);

                entity.HasOne(d => d.TipoVehiculoNavigation)
                    .WithMany(p => p.Vehiculos)
                    .HasForeignKey(d => d.TipoVehiculo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Vehiculo_TipoVehiculo");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
