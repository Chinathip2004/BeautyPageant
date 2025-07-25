using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ImageDescription")]
public partial class ImageDescription
{
    [Key]
    public int Id { get; set; }

    public int? FileId { get; set; }

    public string? Value { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("ImageDescriptions")]
    public virtual FileImg? File { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ImageDescription")]
    public virtual Component IdNavigation { get; set; } = null!;
}
