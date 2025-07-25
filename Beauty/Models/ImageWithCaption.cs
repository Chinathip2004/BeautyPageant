using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ImageWithCaption")]
public partial class ImageWithCaption
{
    [Key]
    public int Id { get; set; }

    public int? FileId { get; set; }

    public string? Value { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("ImageWithCaptions")]
    public virtual FileImg? File { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("ImageWithCaption")]
    public virtual Component IdNavigation { get; set; } = null!;
}
