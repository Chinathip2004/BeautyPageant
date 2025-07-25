using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementBirthDate")]
public partial class ElementBirthDate
{
    [Key]
    public int Id { get; set; }

    public int? BirthDateId { get; set; }

    [ForeignKey("BirthDateId")]
    [InverseProperty("ElementBirthDates")]
    public virtual BirthDate? BirthDate { get; set; }
}
