using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Producto
{
    [Key]
    public int CodigoProducto { get; set; }

    public int CodigoUnidadMedida { get; set; }

    public int CodigoCategoria { get; set; }

    public int CodigoSubCategoria { get; set; }

    public int CodigoProveedor { get; set; }

    public int CodigoAlmacenes { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(4)]
    [Unicode(false)]
    public string Stock { get; set; } = null!;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Precio { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [ForeignKey("CodigoAlmacenes")]
    [InverseProperty("Productos")]
    public virtual Almacene CodigoAlmacenesNavigation { get; set; } = null!;

    [ForeignKey("CodigoCategoria")]
    [InverseProperty("Productos")]
    public virtual Categoria CodigoCategoriaNavigation { get; set; } = null!;

    [ForeignKey("CodigoProveedor")]
    [InverseProperty("Productos")]
    public virtual Proveedore CodigoProveedorNavigation { get; set; } = null!;

    [ForeignKey("CodigoSubCategoria")]
    [InverseProperty("Productos")]
    public virtual SubCategoria CodigoSubCategoriaNavigation { get; set; } = null!;

    [ForeignKey("CodigoUnidadMedida")]
    [InverseProperty("Productos")]
    public virtual UnidadMedida CodigoUnidadMedidaNavigation { get; set; } = null!;

    [InverseProperty("CodigoProductoNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
