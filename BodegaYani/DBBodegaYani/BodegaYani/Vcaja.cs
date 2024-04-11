using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class Vcaja
{
    public int CodigoCaja { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? Fecha { get; set; }

    public bool Estado { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoApertura { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoCierre { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal? MontoAdicional { get; set; }

    [Column("usuario")]
    [StringLength(50)]
    [Unicode(false)]
    public string Usuario { get; set; } = null!;
}
