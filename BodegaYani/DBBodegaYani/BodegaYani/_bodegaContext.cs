using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class _bodegaContext : DbContext
{
    public _bodegaContext()
    {
    }

    public _bodegaContext(DbContextOptions<_bodegaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Almacene> Almacenes { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<DetallePedido> DetallePedidos { get; set; }

    public virtual DbSet<Error> Errors { get; set; }

    public virtual DbSet<MovimientoCaja> MovimientoCajas { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Persona> Personas { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Proveedore> Proveedores { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SubCategoria> SubCategorias { get; set; }

    public virtual DbSet<TipoDocumento> TipoDocumentos { get; set; }

    public virtual DbSet<UnidadMedida> UnidadMedidas { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<VPersona> Vpersonas { get; set; }

    public virtual DbSet<Vproducto> Vproductos { get; set; }

    public virtual DbSet<Vusuario> Vusuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3SJ3EOR;Initial Catalog=BodegaYaninAlmacen;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.HasKey(e => e.CodigoAlmacenes).HasName("PK__Almacene__6E0B9BCCD31A8861");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CodigoCaja).HasName("PK__Cajas__D33367CFF7FF88D7");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__3CEE2F4C36C01ED4");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.CodigoDetallePedido).HasName("PK__DetalleP__8168822DB2CFCC39");

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__Codig__5EBF139D");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.Property(e => e.CodigoError).ValueGeneratedNever();

            entity.HasOne(d => d.CodigoPersonaNavigation).WithMany(p => p.Errors).HasConstraintName("FK__Error__CodigoPer__02FC7413");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Errors).HasConstraintName("FK__Error__CodigoUsu__03F0984C");
        });

        modelBuilder.Entity<MovimientoCaja>(entity =>
        {
            entity.HasKey(e => e.CodigoMovimientoCaja).HasName("PK__Movimien__53FB280F2027D500");

            entity.HasOne(d => d.CodigoCajaNavigation).WithMany(p => p.MovimientoCajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Codig__6477ECF3");

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.MovimientoCajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Codig__6383C8BA");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.CodigoPedido).HasName("PK__Pedidos__72162F0B282ECF4B");

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__CodigoP__5BE2A6F2");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__CodigoU__5AEE82B9");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.CodigoPersona).HasName("PK__Personas__E60E3544B1A4D4A6");

            entity.Property(e => e.Sexo).IsFixedLength();

            entity.HasOne(d => d.CodigoDocumentoNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personas__Codigo__49C3F6B7");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personas__Codigo__48CFD27E");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009E6614B22B");

            entity.Property(e => e.Stock).IsFixedLength();

            entity.HasOne(d => d.CodigoAlmacenesNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5812160E");

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5535A963");

            entity.HasOne(d => d.CodigoProveedorNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__571DF1D5");

            entity.HasOne(d => d.CodigoSubCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5629CD9C");

            entity.HasOne(d => d.CodigoUnidadMedidaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5441852A");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.CodigoProveedor).HasName("PK__Proveedo__137549F51D22EFB3");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.CodigoRol).HasName("PK__Rol__F0D13057B12C546B");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.CodigoSubCategoria).HasName("PK__SubCateg__CAF55A558F394B1E");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.SubCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Codig__3D5E1FD2");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.CodigoDocumento).HasName("PK__TipoDocu__46955BB3AD826792");
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.HasKey(e => e.CodigoUnidadMedida).HasName("PK__UnidadMe__9F32DF2E44D8D3C7");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuarios__F0C18F582E3AE88B");

            entity.HasOne(d => d.CodigoPersonaNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__4CA06362");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__4D94879B");
        });

        modelBuilder.Entity<VPersona>(entity =>
        {
            entity.ToView("VPERSONA");

            entity.Property(e => e.Sexo).IsFixedLength();
        });

        modelBuilder.Entity<Vproducto>(entity =>
        {
            entity.ToView("VProductos");

            entity.Property(e => e.StockProducto).IsFixedLength();
        });

        modelBuilder.Entity<Vusuario>(entity =>
        {
            entity.ToView("VUSUARIO");

            entity.Property(e => e.Sexo).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
