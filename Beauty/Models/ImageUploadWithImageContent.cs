using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ImageUploadWithImageContent")]
public partial class ImageUploadWithImageContent
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("ImageUploadWithImageContent")]
    public virtual ICollection<ElementImageUploadWithImageContent> ElementImageUploadWithImageContents { get; set; } = new List<ElementImageUploadWithImageContent>();

    [ForeignKey("Id")]
    [InverseProperty("ImageUploadWithImageContent")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
