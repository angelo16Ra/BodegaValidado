using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class Vpedido
{
    public int CodigoPedido { get; set; }

    public int CodigoUsuario { get; set; }

    public int CodigoProducto { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal MontoTotalPedido { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal MontoPagado { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Vuelto { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime RegistroPedido { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime EntregaPedido { get; set; }

    [Column("nombreUsuario")]
    [StringLength(50)]
    [Unicode(false)]
    public string NombreUsuario { get; set; } = null!;

    [Column("nombreProducto")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreProducto { get; set; } = null!;

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioTotal { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioUnitario { get; set; }
}
