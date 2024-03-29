using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class MovimientoCaja
{
    [Key]
    public int CodigoMovimientoCaja { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Monto { get; set; }

    public int CodigoCaja { get; set; }

    public int CodigoPedido { get; set; }

    [ForeignKey("CodigoCaja")]
    [InverseProperty("MovimientoCajas")]
    public virtual Caja CodigoCajaNavigation { get; set; } = null!;

    [ForeignKey("CodigoPedido")]
    [InverseProperty("MovimientoCajas")]
    public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;
}
