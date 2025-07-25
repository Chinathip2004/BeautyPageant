using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Section")]
public partial class Section
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Section")]
    public virtual Container IdNavigation { get; set; } = null!;
}
