using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Result")]
public partial class Result
{
    [Key]
    public int Id { get; set; }

    public int? CopyFormComponentId { get; set; }

    public string? Value { get; set; }

    [ForeignKey("CopyFormComponentId")]
    [InverseProperty("Results")]
    public virtual CopyFormComponent? CopyFormComponent { get; set; }
}
