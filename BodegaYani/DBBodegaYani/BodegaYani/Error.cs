using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Table("Error")]
public partial class Error
{
    [Key]
    public int CodigoError { get; set; }

    [Column("urls")]
    [Unicode(false)]
    public string? Urls { get; set; }

    [Column("controller")]
    [StringLength(200)]
    public string? Controller { get; set; }

    [Column("ips")]
    [StringLength(100)]
    public string? Ips { get; set; }

    [Column("method")]
    [StringLength(20)]
    public string? Method { get; set; }

    [Column("user_agent")]
    [StringLength(150)]
    public string? UserAgent { get; set; }

    [Column("host")]
    public string? Host { get; set; }

    [Column("class_component")]
    [StringLength(100)]
    [Unicode(false)]
    public string? ClassComponent { get; set; }

    [Column("function_name")]
    [StringLength(100)]
    [Unicode(false)]
    public string? FunctionName { get; set; }

    [Column("line_number")]
    public int LineNumber { get; set; }

    [Column("error")]
    public string? Error1 { get; set; }

    public string? StackTrace { get; set; }

    [Column("statu")]
    public short Statu { get; set; }

    [Column("request")]
    public string? Request { get; set; }

    [Column("error_code")]
    public int ErrorCode { get; set; }

    public int? CodigoPersona { get; set; }

    public DateTime FechaRegistro { get; set; }

    public DateTime FechaActualizar { get; set; }

    public int? CodigoUsuario { get; set; }

    [ForeignKey("CodigoPersona")]
    [InverseProperty("Errors")]
    public virtual Persona? CodigoPersonaNavigation { get; set; }

    [ForeignKey("CodigoUsuario")]
    [InverseProperty("Errors")]
    public virtual Usuario? CodigoUsuarioNavigation { get; set; }
}
