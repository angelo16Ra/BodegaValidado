using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

[Table("MenuRol")]
public partial class MenuRol
{
    [Key]
    public int CodigoMenuRol { get; set; }

    public int CodigoMenus { get; set; }

    public int CodigoRol { get; set; }

    [ForeignKey("CodigoMenus")]
    [InverseProperty("MenuRols")]
    public virtual Menu CodigoMenusNavigation { get; set; } = null!;

    [ForeignKey("CodigoRol")]
    [InverseProperty("MenuRols")]
    public virtual Rol CodigoRolNavigation { get; set; } = null!;
}
