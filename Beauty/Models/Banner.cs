using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Banner")]
public partial class Banner
{
    [Key]
    public int Id { get; set; }

    public int? FileId { get; set; }

    public string? Value { get; set; }

    public string? ButtonName { get; set; }

    public string? UrlButton { get; set; }

    [Column("isUrl")]
    public bool IsUrl { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("Banner")]
    public virtual Component IdNavigation { get; set; } = null!;
}
