using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("BirthDate")]
public partial class BirthDate
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("BirthDate")]
    public virtual ICollection<ElementBirthDate> ElementBirthDates { get; set; } = new List<ElementBirthDate>();

    [ForeignKey("Id")]
    [InverseProperty("BirthDate")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
