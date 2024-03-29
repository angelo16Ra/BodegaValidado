using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Table("Rol")]
public partial class Rol
{
    [Key]
    public int CodigoRol { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;

    [StringLength(70)]
    [Unicode(false)]
    public string Descripcion { get; set; } = null!;

    public bool Estado { get; set; }

    [InverseProperty("CodigoRolNavigation")]
    public virtual ICollection<Persona> Personas { get; set; } = new List<Persona>();

    [InverseProperty("CodigoRolNavigation")]
    public virtual ICollection<Usuario> Usuarios { get; set; } = new List<Usuario>();
}
