using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("FormComponent")]
public partial class FormComponent
{
    [Key]
    public int Id { get; set; }

    public int? FormId { get; set; }

    public string? Name { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual BirthDate? BirthDate { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ButtonForm? ButtonForm { get; set; }

    [InverseProperty("FormComponent")]
    public virtual ICollection<CopyFormComponent> CopyFormComponents { get; set; } = new List<CopyFormComponent>();

    [InverseProperty("IdNavigation")]
    public virtual Date? Date { get; set; }

    [ForeignKey("FormId")]
    [InverseProperty("FormComponents")]
    public virtual Form? Form { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ImageUpload? ImageUpload { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual ImageUploadWithImageContent? ImageUploadWithImageContent { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual SingleSelection? SingleSelection { get; set; }

    [InverseProperty("IdNavigation")]
    public virtual TextField? TextField { get; set; }
}
