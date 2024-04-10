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

    public int CodigoAlmacenes { get; set; }

    public int CodigoCategoria { get; set; }

    public int CodigoProveedor { get; set; }

    public int CodigoSubCategoria { get; set; }

    public int CodigoUnidadMedida { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Stock { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Precio { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string Imagen { get; set; } = null!;

    [StringLength(200)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    [Column("nomnombreMedida")]
    [StringLength(40)]
    [Unicode(false)]
    public string NomnombreMedida { get; set; } = null!;

    [Column("nombreCategoria")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreCategoria { get; set; } = null!;

    [Column("nombreSub")]
    [StringLength(40)]
    [Unicode(false)]
    public string NombreSub { get; set; } = null!;

    [Column("nombreProveedor")]
    [StringLength(150)]
    [Unicode(false)]
    public string NombreProveedor { get; set; } = null!;

    [Column("nombreAlmacen")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreAlmacen { get; set; } = null!;
}
