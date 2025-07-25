using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Dependent")]
public partial class Dependent
{
    [Key]
    public int Id { get; set; }

    public int? EventId { get; set; }

    public int? PageId { get; set; }

    [ForeignKey("EventId")]
    [InverseProperty("Dependents")]
    public virtual Event? Event { get; set; }

    [ForeignKey("PageId")]
    [InverseProperty("Dependents")]
    public virtual Page? Page { get; set; }
}
