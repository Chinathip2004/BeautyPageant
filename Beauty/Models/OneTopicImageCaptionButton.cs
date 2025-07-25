using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("OneTopicImageCaptionButton")]
public partial class OneTopicImageCaptionButton
{
    [Key]
    public int Id { get; set; }

    public int? FileId { get; set; }

    public string? Value1 { get; set; }

    public string? Value2 { get; set; }

    public string? ButtonName { get; set; }

    public string? Url { get; set; }

    [Column("isUrl")]
    public bool IsUrl { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("OneTopicImageCaptionButtons")]
    public virtual FileImg? File { get; set; }

    [ForeignKey("Id")]
    [InverseProperty("OneTopicImageCaptionButton")]
    public virtual Component IdNavigation { get; set; } = null!;
}
