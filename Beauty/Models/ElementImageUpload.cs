using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementImageUpload")]
public partial class ElementImageUpload
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public int? ImageUploadId { get; set; }

    [ForeignKey("ImageUploadId")]
    [InverseProperty("ElementImageUploads")]
    public virtual ImageUpload? ImageUpload { get; set; }
}
