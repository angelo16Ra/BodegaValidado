using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class Vusuario
{
    public int CodigoUsuario { get; set; }

    [StringLength(50)]
    [Unicode(false)]
    public string UserName { get; set; } = null!;

    [StringLength(50)]
    [Unicode(false)]
    public string Password { get; set; } = null!;

    public bool Estado { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaActualizar { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime FechaRegistro { get; set; }

    public int CodigoPersona { get; set; }

    [StringLength(15)]
    [Unicode(false)]
    public string NumeroDocumento { get; set; } = null!;

    [Column("nombrePersona")]
    [StringLength(50)]
    [Unicode(false)]
    public string NombrePersona { get; set; } = null!;

    [Column("apellidoPaterno")]
    [StringLength(60)]
    [Unicode(false)]
    public string ApellidoPaterno { get; set; } = null!;

    [Column("apellidoMaterno")]
    [StringLength(60)]
    [Unicode(false)]
    public string ApellidoMaterno { get; set; } = null!;

    [Column("genero")]
    [StringLength(1)]
    [Unicode(false)]
    public string Genero { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string? Celular { get; set; }

    public int CodigoRol { get; set; }

    [Column("nombreRol")]
    [StringLength(70)]
    [Unicode(false)]
    public string NombreRol { get; set; } = null!;
}
