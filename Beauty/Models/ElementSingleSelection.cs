using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("ElementSingleSelection")]
public partial class ElementSingleSelection
{
    [Key]
    public int Id { get; set; }

    public int? SingleSelectionId { get; set; }

    public string? Value { get; set; }

    [ForeignKey("SingleSelectionId")]
    [InverseProperty("ElementSingleSelections")]
    public virtual SingleSelection? SingleSelection { get; set; }
}
