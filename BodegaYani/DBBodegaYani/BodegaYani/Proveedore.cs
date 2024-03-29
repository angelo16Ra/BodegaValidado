using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Proveedore
{
    [Key]
    public int CodigoProveedor { get; set; }

    [StringLength(150)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(20)]
    [Unicode(false)]
    public string Ruc { get; set; } = null!;

    [StringLength(500)]
    [Unicode(false)]
    public string RazonSocial { get; set; } = null!;

    [StringLength(15)]
    [Unicode(false)]
    public string Telefono { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("CodigoProveedorNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
