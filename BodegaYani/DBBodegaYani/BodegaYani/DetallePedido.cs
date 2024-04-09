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

    [Column(TypeName = "decimal(8, 2)")]
    public decimal Cantidad { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioTotal { get; set; }

    [Column(TypeName = "decimal(8, 2)")]
    public decimal PrecioUnitario { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("CodigoDetallePedidoNavigation")]
    public virtual ICollection<Pedido> Pedidos { get; set; } = new List<Pedido>();
}
