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

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioApertura { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string? UsuarioCierre { get; set; }

    public bool Estado { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoApertura { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoCierre { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoAdicional { get; set; }

    [InverseProperty("CodigoCajaNavigation")]
    public virtual ICollection<MovimientoCaja> MovimientoCajas { get; set; } = new List<MovimientoCaja>();
}
