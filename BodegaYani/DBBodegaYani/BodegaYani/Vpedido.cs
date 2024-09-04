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

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioUnitario { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioTotal { get; set; }

    [Column("nombreProducto")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreProducto { get; set; } = null!;
}
