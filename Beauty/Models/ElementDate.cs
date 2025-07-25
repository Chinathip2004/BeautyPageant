using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementDate")]
public partial class ElementDate
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    public int? DateId { get; set; }

    [ForeignKey("DateId")]
    [InverseProperty("ElementDates")]
    public virtual Date? Date { get; set; }
}
