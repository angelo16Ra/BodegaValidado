using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Pedido
{
    [Key]
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

    public bool Estado { get; set; }

    [ForeignKey("CodigoProducto")]
    [InverseProperty("Pedidos")]
    public virtual Producto CodigoProductoNavigation { get; set; } = null!;

    [ForeignKey("CodigoUsuario")]
    [InverseProperty("Pedidos")]
    public virtual Usuario CodigoUsuarioNavigation { get; set; } = null!;

    [InverseProperty("CodigoPedidoNavigation")]
    public virtual ICollection<DetallePedido> DetallePedidos { get; set; } = new List<DetallePedido>();

    [InverseProperty("CodigoPedidoNavigation")]
    public virtual ICollection<MovimientoCaja> MovimientoCajas { get; set; } = new List<MovimientoCaja>();
}
