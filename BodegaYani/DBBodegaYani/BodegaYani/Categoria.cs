using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Categoria
{
    [Key]
    public int CodigoCategoria { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(150)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaActualizacion { get; set; }

    [InverseProperty("CodigoCategoriaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();

    [InverseProperty("CodigoCategoriaNavigation")]
    public virtual ICollection<SubCategoria> SubCategoria { get; set; } = new List<SubCategoria>();
}
