using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("CopyFormComponent")]
public partial class CopyFormComponent
{
    [Key]
    public int Id { get; set; }

    public int? CopyFormId { get; set; }

    public int? FormComponentId { get; set; }

    public string? Name { get; set; }

    [ForeignKey("CopyFormId")]
    [InverseProperty("CopyFormComponents")]
    public virtual CopyForm? CopyForm { get; set; }

    [ForeignKey("FormComponentId")]
    [InverseProperty("CopyFormComponents")]
    public virtual FormComponent? FormComponent { get; set; }

    [InverseProperty("CopyFormComponent")]
    public virtual ICollection<Result> Results { get; set; } = new List<Result>();
}
