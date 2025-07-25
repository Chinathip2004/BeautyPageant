using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ImageUpload")]
public partial class ImageUpload
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("ImageUpload")]
    public virtual ICollection<ElementImageUpload> ElementImageUploads { get; set; } = new List<ElementImageUpload>();

    [ForeignKey("Id")]
    [InverseProperty("ImageUpload")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
