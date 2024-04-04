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

    [Column("nombreMedida")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreMedida { get; set; } = null!;

    [Column("descripcionMedida")]
    [StringLength(70)]
    [Unicode(false)]
    public string DescripcionMedida { get; set; } = null!;

    [Column("estadomedida")]
    public bool Estadomedida { get; set; }

    [Column("c_cate")]
    public int CCate { get; set; }

    [Column("nombreCategoria")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreCategoria { get; set; } = null!;

    [Column("descripcionCategoria")]
    [StringLength(150)]
    [Unicode(false)]
    public string DescripcionCategoria { get; set; } = null!;

    [Column("fechaReCategoria", TypeName = "datetime")]
    public DateTime FechaReCategoria { get; set; }

    [Column("fechaAcCategoria", TypeName = "datetime")]
    public DateTime FechaAcCategoria { get; set; }

    [Column("estadoCategoria")]
    public bool EstadoCategoria { get; set; }

    public int CodigoSubCategoria { get; set; }

    [Column("codCategoria")]
    public int CodCategoria { get; set; }

    [Column("nombreSub")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreSub { get; set; } = null!;

    [Column("descripcionSub")]
    [StringLength(150)]
    [Unicode(false)]
    public string DescripcionSub { get; set; } = null!;

    [Column("fechaReSub", TypeName = "datetime")]
    public DateTime FechaReSub { get; set; }

    [Column("fechaAcSub", TypeName = "datetime")]
    public DateTime FechaAcSub { get; set; }

    [Column("estadoSub")]
    public bool EstadoSub { get; set; }

    public int CodigoProveedor { get; set; }

    [Column("nombreProveedor")]
    [StringLength(150)]
    [Unicode(false)]
    public string NombreProveedor { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string RazonSocial { get; set; } = null!;

    [Column("correoProveedor")]
    [StringLength(150)]
    [Unicode(false)]
    public string CorreoProveedor { get; set; } = null!;

    [Column("telefonoPro")]
    [StringLength(15)]
    [Unicode(false)]
    public string TelefonoPro { get; set; } = null!;

    [Column("fechaReProveedor", TypeName = "datetime")]
    public DateTime FechaReProveedor { get; set; }

    [Column("fechaAcProveedor", TypeName = "datetime")]
    public DateTime FechaAcProveedor { get; set; }

    [Column("rucProveedor")]
    [StringLength(20)]
    [Unicode(false)]
    public string RucProveedor { get; set; } = null!;

    [Column("estadoProveedor")]
    public bool EstadoProveedor { get; set; }

    public int CodigoAlmacenes { get; set; }

    [Column("nombreAlmacen")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreAlmacen { get; set; } = null!;

    [Column("capLimAlmacen")]
    public int CapLimAlmacen { get; set; }

    [Column("estadoAlmacen")]
    public bool EstadoAlmacen { get; set; }
}
