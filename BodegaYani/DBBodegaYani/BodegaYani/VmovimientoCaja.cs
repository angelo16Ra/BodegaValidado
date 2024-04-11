using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class VmovimientoCaja
{
    public int CodigoMovimientoCaja { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Tipo { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? Monto { get; set; }

    [Column("fechaCaja", TypeName = "datetime")]
    public DateTime? FechaCaja { get; set; }

    [Column("montoInicial", TypeName = "decimal(10, 2)")]
    public decimal? MontoInicial { get; set; }

    [Column("montoFinal", TypeName = "decimal(10, 2)")]
    public decimal? MontoFinal { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoAdicional { get; set; }
}
