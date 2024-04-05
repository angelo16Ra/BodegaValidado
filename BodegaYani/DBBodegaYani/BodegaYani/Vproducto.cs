using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class Vproducto
{
    public int CodigoProducto { get; set; }

    [Column("c_almacenes")]
    public int CAlmacenes { get; set; }

    [Column("c_categoria")]
    public int CCategoria { get; set; }

    [Column("c_proveedor")]
    public int CProveedor { get; set; }

    [Column("c_subcategoria")]
    public int CSubcategoria { get; set; }

    [Column("c_unidadmedida")]
    public int CUnidadmedida { get; set; }

    [Column("nombreProducto")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreProducto { get; set; } = null!;

    [Column("stockProducto")]
    [StringLength(4)]
    [Unicode(false)]
    public string StockProducto { get; set; } = null!;

    [Column("precioProducto", TypeName = "decimal(8, 2)")]
    public decimal PrecioProducto { get; set; }

    [Column("imagenProducto")]
    [StringLength(50)]
    [Unicode(false)]
    public string ImagenProducto { get; set; } = null!;

    [Column("descripcionProducto")]
    [StringLength(200)]
    [Unicode(false)]
    public string DescripcionProducto { get; set; } = null!;

    public int CodigoUnidadMedida { get; set; }

    [Column("nomnombreMedida")]
    [StringLength(40)]
    [Unicode(false)]
    public string NomnombreMedida { get; set; } = null!;

    public int CodigoCategoria { get; set; }

    [Column("nombreCategoria")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreCategoria { get; set; } = null!;

    public int CodigoSubCategoria { get; set; }

    [Column("nombreSub")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreSub { get; set; } = null!;

    public int CodigoProveedor { get; set; }

    [Column("nombreProveedor")]
    [StringLength(150)]
    [Unicode(false)]
    public string NombreProveedor { get; set; } = null!;

    public int CodigoAlmacenes { get; set; }

    [Column("nombreAlmacen")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreAlmacen { get; set; } = null!;
}
