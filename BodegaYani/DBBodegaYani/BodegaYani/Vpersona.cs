using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Keyless]
public partial class Vpersona
{
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

    public int CodigoDocumento { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string NombreDocumento { get; set; } = null!;
}
