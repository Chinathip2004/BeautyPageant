using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Beauty.Models;

[Table("TextField")]
public partial class TextField
{
    [Key]
    public int Id { get; set; }

    public string? Value { get; set; }

    [InverseProperty("TextField")]
    public virtual ICollection<ElementTextField> ElementTextFields { get; set; } = new List<ElementTextField>();

    [ForeignKey("Id")]
    [InverseProperty("TextField")]
    public virtual FormComponent IdNavigation { get; set; } = null!;
}
