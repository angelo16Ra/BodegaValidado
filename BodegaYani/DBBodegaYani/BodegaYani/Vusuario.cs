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
    public string Username { get; set; } = null!;

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

    [StringLength(50)]
    [Unicode(false)]
    public string NombrePersona { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string ApPaterno { get; set; } = null!;

    [StringLength(60)]
    [Unicode(false)]
    public string ApMaterno { get; set; } = null!;

    [StringLength(1)]
    [Unicode(false)]
    public string Sexo { get; set; } = null!;

    [Column(TypeName = "datetime")]
    public DateTime FechaNacimiento { get; set; }

    [StringLength(60)]
    [Unicode(false)]
    public string Correo { get; set; } = null!;

    [StringLength(12)]
    [Unicode(false)]
    public string? Celular { get; set; }

    public int CodigoRol { get; set; }

    [StringLength(70)]
    [Unicode(false)]
    public string Nombre { get; set; } = null!;
}
