using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("CopyForm")]
public partial class CopyForm
{
    [Key]
    public int Id { get; set; }

    public int? FormId { get; set; }

    [InverseProperty("CopyForm")]
    public virtual ICollection<CopyFormComponent> CopyFormComponents { get; set; } = new List<CopyFormComponent>();

    [ForeignKey("FormId")]
    [InverseProperty("CopyForms")]
    public virtual Form? Form { get; set; }
}
