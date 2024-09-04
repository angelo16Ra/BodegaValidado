using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class DetallePedido
{
    [Key]
    public int CodigoDetallePedido { get; set; }

    public int CodigoProducto { get; set; }

    public int CodigoPedido { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioTotal { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioUnitario { get; set; }

    [ForeignKey("CodigoPedido")]
    [InverseProperty("DetallePedidos")]
    public virtual Pedido CodigoPedidoNavigation { get; set; } = null!;

    [ForeignKey("CodigoProducto")]
    [InverseProperty("DetallePedidos")]
    public virtual Producto CodigoProductoNavigation { get; set; } = null!;
}
