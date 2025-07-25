using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("SingleSelection")]
public partial class SingleSelection
{
    [Key]
    public int Id { get; set; }

    [InverseProperty("SingleSelection")]
    public virtual ICollection<ElementSingleSelection> ElementSingleSelections { get; set; } = new List<ElementSingleSelection>();

    [ForeignKey("Id")]
    [InverseProperty("SingleSelection")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
