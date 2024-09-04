using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Usuario
{
    [Key]
    public int CodigoUsuario { get; set; }

    public int CodigoRol { get; set; }

    public int CodigoPersona { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public bool Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaActualizar { get; set; }

    [InverseProperty("CodigoUsuarioNavigation")]
    public virtual ICollection<Caja> Cajas { get; set; } = new List<Caja>();

    [ForeignKey("CodigoPersona")]
    [InverseProperty("Usuarios")]
    public virtual Persona CodigoPersonaNavigation { get; set; } = null!;

    [ForeignKey("CodigoRol")]
    [InverseProperty("Usuarios")]
    public virtual Rol CodigoRolNavigation { get; set; } = null!;

    [InverseProperty("CodigoUsuarioNavigation")]
    public virtual ICollection<Error> Errors { get; set; } = new List<Error>();
}
