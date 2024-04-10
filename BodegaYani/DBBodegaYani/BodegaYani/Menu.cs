using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace DBBodegaYani.BodegaYani;

public partial class Menu
{
    [Key]
    public int CodigoMenus { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Nombre { get; set; }

    [StringLength(30)]
    [Unicode(false)]
    public string? Icono { get; set; }

    [StringLength(1000)]
    [Unicode(false)]
    public string Url { get; set; } = null!;

    [InverseProperty("CodigoMenusNavigation")]
    public virtual ICollection<MenuRol> MenuRols { get; set; } = new List<MenuRol>();
}
