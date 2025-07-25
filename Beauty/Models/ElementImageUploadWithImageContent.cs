using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementImageUploadWithImageContent")]
public partial class ElementImageUploadWithImageContent
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public int? FileId { get; set; }

    public int? ImageUploadWithImageContentId { get; set; }

    [ForeignKey("FileId")]
    [InverseProperty("ElementImageUploadWithImageContents")]
    public virtual FileImg? File { get; set; }

    [ForeignKey("ImageUploadWithImageContentId")]
    [InverseProperty("ElementImageUploadWithImageContents")]
    public virtual ImageUploadWithImageContent? ImageUploadWithImageContent { get; set; }
}
