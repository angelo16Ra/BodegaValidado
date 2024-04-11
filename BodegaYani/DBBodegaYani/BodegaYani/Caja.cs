using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Caja
{
    [Key]
    public int CodigoCaja { get; set; }

    public int CodigoUsuario { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    public bool Estado { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoApertura { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoCierre { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoAdicional { get; set; }

    [ForeignKey("CodigoUsuario")]
    [InverseProperty("Cajas")]
    public virtual Usuario CodigoUsuarioNavigation { get; set; } = null!;

    [InverseProperty("CodigoCajaNavigation")]
    public virtual ICollection<MovimientoCaja> MovimientoCajas { get; set; } = new List<MovimientoCaja>();
}
