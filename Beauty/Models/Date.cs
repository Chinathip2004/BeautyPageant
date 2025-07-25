using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("Date")]
public partial class Date
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("Date")]
    public virtual ICollection<ElementDate> ElementDates { get; set; } = new List<ElementDate>();

    [ForeignKey("Id")]
    [InverseProperty("Date")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
