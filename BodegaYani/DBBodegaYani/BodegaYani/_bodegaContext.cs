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

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

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

    public virtual DbSet<Vcaja> Vcajas { get; set; }

    public virtual DbSet<VmovimientoCaja> VmovimientoCajas { get; set; }

    public virtual DbSet<Vpedido> Vpedidos { get; set; }

    public virtual DbSet<Vpersona> Vpersonas { get; set; }

    public virtual DbSet<Vproducto> Vproductos { get; set; }

    public virtual DbSet<Vusuario> Vusuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-3SJ3EOR;Initial Catalog=BodegaYaninAlmacen;Trusted_Connection=True;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Almacene>(entity =>
        {
            entity.HasKey(e => e.CodigoAlmacenes).HasName("PK__Almacene__6E0B9BCCC054FE1D");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CodigoCaja).HasName("PK__Cajas__D33367CFDCF49CAB");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Cajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Cajas__CodigoUsu__6754599E");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CodigoCategoria).HasName("PK__Categori__3CEE2F4C4E2AD64E");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<DetallePedido>(entity =>
        {
            entity.HasKey(e => e.CodigoDetallePedido).HasName("PK__DetalleP__8168822DD24B7BE1");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.DetallePedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__DetallePe__Estad__6383C8BA");
        });

        modelBuilder.Entity<Error>(entity =>
        {
            entity.Property(e => e.CodigoError).ValueGeneratedNever();

            entity.HasOne(d => d.CodigoPersonaNavigation).WithMany(p => p.Errors).HasConstraintName("FK__Error__CodigoPer__73BA3083");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Errors).HasConstraintName("FK__Error__CodigoUsu__74AE54BC");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.CodigoMenus).HasName("PK__Menus__167FD37B899B08B6");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.CodigoMenuRol).HasName("PK__MenuRol__1386FD861D5E7AD7");

            entity.HasOne(d => d.CodigoMenusNavigation).WithMany(p => p.MenuRols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuRol__CodigoM__70DDC3D8");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.MenuRols)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__MenuRol__CodigoR__6FE99F9F");
        });

        modelBuilder.Entity<MovimientoCaja>(entity =>
        {
            entity.HasKey(e => e.CodigoMovimientoCaja).HasName("PK__Movimien__53FB280F0362ADCC");

            entity.HasOne(d => d.CodigoCajaNavigation).WithMany(p => p.MovimientoCajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Codig__6B24EA82");

            entity.HasOne(d => d.CodigoPedidoNavigation).WithMany(p => p.MovimientoCajas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Movimient__Codig__6A30C649");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.CodigoPedido).HasName("PK__Pedidos__72162F0B1C935302");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoProductoNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__CodigoP__5FB337D6");

            entity.HasOne(d => d.CodigoUsuarioNavigation).WithMany(p => p.Pedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__CodigoU__5EBF139D");
        });

        modelBuilder.Entity<Persona>(entity =>
        {
            entity.HasKey(e => e.CodigoPersona).HasName("PK__Personas__E60E3544473B3241");

            entity.Property(e => e.Estado).HasDefaultValue(true);
            entity.Property(e => e.Sexo).IsFixedLength();

            entity.HasOne(d => d.CodigoDocumentoNavigation).WithMany(p => p.Personas)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Personas__Codigo__4AB81AF0");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.CodigoProducto).HasName("PK__Producto__785B009E18C7131C");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoAlmacenesNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5AEE82B9");

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__5812160E");

            entity.HasOne(d => d.CodigoProveedorNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__59FA5E80");

            entity.HasOne(d => d.CodigoSubCategoriaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__59063A47");

            entity.HasOne(d => d.CodigoUnidadMedidaNavigation).WithMany(p => p.Productos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Productos__Codig__571DF1D5");
        });

        modelBuilder.Entity<Proveedore>(entity =>
        {
            entity.HasKey(e => e.CodigoProveedor).HasName("PK__Proveedo__137549F53754A886");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.CodigoRol).HasName("PK__Rol__F0D13057D058759A");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<SubCategoria>(entity =>
        {
            entity.HasKey(e => e.CodigoSubCategoria).HasName("PK__SubCateg__CAF55A55AC4860AC");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoCategoriaNavigation).WithMany(p => p.SubCategoria)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__SubCatego__Codig__3E52440B");
        });

        modelBuilder.Entity<TipoDocumento>(entity =>
        {
            entity.HasKey(e => e.CodigoDocumento).HasName("PK__TipoDocu__46955BB3DC010CC5");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<UnidadMedida>(entity =>
        {
            entity.HasKey(e => e.CodigoUnidadMedida).HasName("PK__UnidadMe__9F32DF2EDBF0FCB5");

            entity.Property(e => e.Estado).HasDefaultValue(true);
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.CodigoUsuario).HasName("PK__Usuarios__F0C18F588167DEE0");

            entity.Property(e => e.Estado).HasDefaultValue(true);

            entity.HasOne(d => d.CodigoPersonaNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__4E88ABD4");

            entity.HasOne(d => d.CodigoRolNavigation).WithMany(p => p.Usuarios)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Usuarios__Codigo__4F7CD00D");
        });

        modelBuilder.Entity<Vcaja>(entity =>
        {
            entity.ToView("VCaja");
        });

        modelBuilder.Entity<VmovimientoCaja>(entity =>
        {
            entity.ToView("VMovimientoCaja");
        });

        modelBuilder.Entity<Vpedido>(entity =>
        {
            entity.ToView("VPedido");
        });

        modelBuilder.Entity<Vpersona>(entity =>
        {
            entity.ToView("VPERSONA");

            entity.Property(e => e.Sexo).IsFixedLength();
        });

        modelBuilder.Entity<Vproducto>(entity =>
        {
            entity.ToView("VProductos");
        });

        modelBuilder.Entity<Vusuario>(entity =>
        {
            entity.ToView("VUSUARIO");

            entity.Property(e => e.Genero).IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
