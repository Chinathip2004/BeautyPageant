using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Button")]
public partial class Button
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public string? Url { get; set; }

    [Column("isUrl")]
    public bool? IsUrl { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Button")]
    public virtual Component IdNavigation { get; set; } = null!;
}
