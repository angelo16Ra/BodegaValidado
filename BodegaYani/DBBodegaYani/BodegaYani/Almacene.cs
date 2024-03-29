using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Almacene
{
    [Key]
    public int CodigoAlmacenes { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    public int CapacidadLimite { get; set; }

    public bool Estado { get; set; }

    [InverseProperty("CodigoAlmacenesNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
