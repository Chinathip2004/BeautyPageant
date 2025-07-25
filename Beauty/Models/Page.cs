using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Page")]
public partial class Page
{
    [Key]
    public int Id { get; set; }

    public string? Name { get; set; }

    [InverseProperty("Page")]
    public virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();

    [ForeignKey("Id")]
    [InverseProperty("Page")]
    public virtual Container IdNavigation { get; set; } = null!;
}
