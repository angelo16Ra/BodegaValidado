using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Index("Nombre", Name = "UQ__UnidadMe__75E3EFCF3497042E", IsUnique = true)]
public partial class UnidadMedida
{
    [Key]
    public int CodigoUnidadMedida { get; set; }

    [StringLength(40)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(70)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    [InverseProperty("CodigoUnidadMedidaNavigation")]
    public virtual ICollection<Producto> Productos { get; set; } = new List<Producto>();
}
